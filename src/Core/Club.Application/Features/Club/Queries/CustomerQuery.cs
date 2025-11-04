namespace Club.Application.Features.Common.Queries;

public record CustomerQuery() : IRequest<CustomerQueryResponse?>
{
    public string CustomerId { get; set; } = null!;
    public bool GetParametersValues { get; set; }
    public bool GetAssets { get; set; }
}

public record CustomerQueryResponse
{
    public string? FirstName { get; internal set; }
    public string? LastName { get; internal set; }
    public DateTime? BirthDate { get; internal set; }
}

public class CustomerQueryHandler(
    ICustomerService customerService
    //, IQueryRepository<Customer, int> customerRepository
    ) : IRequestHandler<CustomerQuery, CustomerQueryResponse?>
{
    public async Task<CustomerQueryResponse?> Handle(CustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? customer = await customerService.GetCustomer(request.CustomerId, false, null, cancellationToken);
        if(customer == null) return null;
        //TODO
        return new CustomerQueryResponse
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            BirthDate = customer.BirthDate
        };
    }
}
