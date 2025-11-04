using Club.Application.Features.Common.Queries;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Club.Web.Controllers.Common;

[AppRoute("common", "[controller]")]
[Tags("common/faq")]
public class FaqController : AppControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(FaqQueryResponse), StatusCodes.Status200OK)]
    public async Task<Ok<FaqQueryResponse>> GetFaq([FromHeader(Name = "x-app-name"), BindRequired] string appName)
    {
        FaqQuery query = new();
        return TypedResults.Ok(await Sender.Send(query));
    }
}
