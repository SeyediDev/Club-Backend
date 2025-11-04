using Club.Application.Features.Common.Queries;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Club.Web.Controllers.Common;

[AppRoute("common", "[controller]")]
[Tags("common/help")]
public class HelpController : AppControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(HelpQueryResponse), StatusCodes.Status200OK)]
    public async Task<Ok<HelpQueryResponse>> GetHelp([FromHeader(Name = "x-app-name"), BindRequired] string appName)
    {
        HelpQuery query = new();
        return TypedResults.Ok(await Sender.Send(query));
    }
}
