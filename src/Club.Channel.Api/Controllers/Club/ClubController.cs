using Club.Application.Features.Club.Commands;
using Club.Application.Features.Club.Queries;
using Club.Application.Features.Common.Queries;

namespace Club.Web.Controllers.Club;

[AppRoute("club", "[controller]")]
[Tags("club/club")]
public class ClubController : AppControllerBase
{
    [HttpPost("purchase-award")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<PurchaseAwardCommandResponse>> PurchaseAward([FromBody] PurchaseAwardCommand command)
    {
        return TypedResults.Ok(await Sender.Send(command));
    }

    [HttpGet("customer")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<CustomerQueryResponse>> GetCustomer([FromBody] CustomerQuery query)
    {
        return TypedResults.Ok(await Sender.Send(query));
    }
    
    [HttpGet("awards")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<AwardsQueryResponse>> GetAwards([FromBody] AwardsQuery query)
    {
        return TypedResults.Ok(await Sender.Send(query));
    }
}