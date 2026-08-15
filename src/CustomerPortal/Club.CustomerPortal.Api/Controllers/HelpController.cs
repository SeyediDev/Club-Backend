using Club.CustomerPortal.Application.Features.Helps.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Club.CustomerPortal.Api.Controllers;

[AppRoute("club", "customer/help")]
[Tags("customer/help")]
[ApiController]
[Authorize]
public class HelpController : AppControllerBase
{
    [HttpGet("faqs")]
    [ProducesResponseType(typeof(GetFaqsQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetFaqsQueryResponse>> GetFaqs([FromQuery] GetFaqsQuery query)
    {
        var response = await Sender.Send(query);
        return Ok(response);
    }

    [HttpGet("content")]
    [ProducesResponseType(typeof(GetHelpContentQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetHelpContentQueryResponse>> GetHelpContent([FromQuery] GetHelpContentQuery query)
    {
        var response = await Sender.Send(query);
        return Ok(response);
    }
}




