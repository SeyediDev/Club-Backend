using Club.Domain.Entities.Customers.Enums;
using Club.Domain.Features.ScoringRules;

namespace Club.Domain.Features;

public interface IProductOrServiceService
{
    [Telemetry]
    Task<PurchaseProductOrServiceResponse> PurchaseProductOrService(PurchaseProductOrServiceRequest request, CancellationToken cancellationToken);
}

public record PurchaseProductOrServiceRequest
{
    public string CustomerId { get; set; } = null!;
    public int TenantProductOrServiceId { get; set; }
    public int Quantity { get; set; } = 1;
}

public record PurchaseProductOrServiceResponse
{
    public string CustomerId { get; set; } = null!;
    public int TenantProductOrServiceId { get; set; }
    public int Quantity { get; set; }
    public long? PointsAwarded { get; set; }
    public decimal TotalPrice { get; set; }
}

internal class ProductOrServiceService(
    ILogger<ProductOrServiceService> logger,
    ICustomerService customerService,
    IEventService eventService,
    IScoringRuleService scoringRuleService,
    ICommandRepository<CustomerTransaction, long> customerTransactionCmdRepo,
    ICommandRepository<Product, int> productServiceCmdRepo
    ) : IProductOrServiceService
{
    /// <summary>
    /// مشتری خرید محصول سازمان را انجام می‌دهد
    /// در این حالت مشتری امتیاز کسب می‌کند (نه امتیاز می‌پردازد)
    /// </summary>
    public async Task<PurchaseProductOrServiceResponse> PurchaseProductOrService(PurchaseProductOrServiceRequest request, CancellationToken cancellationToken)
    {
        // Get customer
        Customer? customer = await customerService.GetCustomer(request.CustomerId, false, null, cancellationToken)
            ?? throw new NullReferenceException(nameof(customer)); // TODO 404

        // Get product/service
        Product? product = await productServiceCmdRepo.FirstOrDefaultAsync(
            x => x.Id == request.TenantProductOrServiceId, cancellationToken)
            ?? throw new NullReferenceException("محصول یافت نشد"); // TODO 404

        if (!product.IsActive)
            throw new InvalidOperationException("محصول فعال نیست"); // TODO 400

        // Record event
        EventResponse eventResponse = await eventService.RecordEventAsync(
            new(TriggerType.PurchaseProductOrService, request.CustomerId, null)
            {
                TenantProductOrServiceId = request.TenantProductOrServiceId
            }, cancellationToken);

        // Award points if configured
        long? pointsAwarded = null;
        if (product.PointsEarnable.HasValue && product.PointsEarnable.Value > 0)
        {
            // TODO: Determine which point to award (may need to query point configuration)
            // For now, assuming a default point exists
            IEnumerable<CustomerTransaction> customerBalances = await customerService.GetCustomerPointBalances(customer.Id, product.TenantId, cancellationToken);
            
            // Find the first available point
            var firstPointBalance = customerBalances.FirstOrDefault();
            if (firstPointBalance != null)
            {
                long pointsToAward = product.PointsEarnable.Value * request.Quantity;
                
                CustomerTransaction creditTransaction = new()
                {
                    TransactionType = CustomerTransactionType.Credit,
                    Credit = pointsToAward,
                    Balance = firstPointBalance.Balance + pointsToAward,
                    TenantId = product.TenantId,
                    CustomerId = customer.Id,
                    PointId = firstPointBalance.PointId,
                    EventLogId = eventResponse.EventLogId,
                };
                customerTransactionCmdRepo.Add(creditTransaction);
                await customerTransactionCmdRepo.UnitOfWork.SaveChangesAsync(cancellationToken);
                
                pointsAwarded = pointsToAward;
                logger.LogInformation("Awarded {Points} points for product/service purchase", pointsToAward);
            }
        }

        // Update product/service statistics
        product.PurchaseCount += request.Quantity;
        if (product.Price.HasValue)
        {
            product.TotalRevenue += product.Price.Value * request.Quantity;
        }
        productServiceCmdRepo.Update(product);
        await productServiceCmdRepo.UnitOfWork.SaveChangesAsync(cancellationToken);

        // Trigger scoring rules
        await scoringRuleService.ScoringAnalysis(
            new(TriggerType.PurchaseProductOrService, eventResponse.Customer, eventResponse.EventLogId, null)
            {
                TenantProductOrServiceId = product.Id
            }, cancellationToken);

        decimal totalPrice = product.Price.HasValue ? product.Price.Value * request.Quantity : 0;
        
        return new PurchaseProductOrServiceResponse
        {
            CustomerId = request.CustomerId,
            TenantProductOrServiceId = request.TenantProductOrServiceId,
            Quantity = request.Quantity,
            PointsAwarded = pointsAwarded,
            TotalPrice = totalPrice
        };
    }
}
