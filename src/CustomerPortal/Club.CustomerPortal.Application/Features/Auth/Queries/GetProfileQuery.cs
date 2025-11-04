namespace Club.CustomerPortal.Application.Features.Auth.Queries;

public record GetProfileQuery : IRequest<GetProfileQueryResponse>;

public record GetProfileQueryResponse
{
    public required CustomerDto Customer { get; set; }
}

public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileQueryResponse>
{
    private readonly ICustomerService _customerService;
    private readonly IRequesterUser _requesterUser;

    public GetProfileQueryHandler(
        ICustomerService customerService,
        IRequesterUser requesterUser)
    {
        _customerService = customerService;
        _requesterUser = requesterUser;
    }
    
    public async Task<GetProfileQueryResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var customerId = _requesterUser.GetUserId();
        
        var customer = await _customerService.GetCustomerByIdAsync(customerId, cancellationToken);
        
        if (customer == null)
        {
            throw new InvalidOperationException("مشتری یافت نشد");
        }
        
        return new GetProfileQueryResponse
        {
            Customer = customer.Adapt<CustomerDto>()
        };
    }
}

