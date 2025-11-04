using Neo.Endpoint.Controller;
using Club.CustomerPortal.Application.Features.Dashboard.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Club.CustomerPortal.Api.Controllers;

[Route("api/customer/dashboard")]
[Tags("customer/dashboard")]
[ApiController]
[Authorize]
public class CustomerDashboardController : AppControllerBase
{
    [HttpGet("stats")]
    [ProducesResponseType(typeof(GetDashboardStatsQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDashboardStatsQueryResponse>> GetStats()
    {
        var query = new GetDashboardStatsQuery();
        var response = await Sender.Send(query);
        return Ok(response);
    }
}

