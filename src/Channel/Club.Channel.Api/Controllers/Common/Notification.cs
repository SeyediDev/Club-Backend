using Club.Application.Features.Common.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Club.Web.Controllers.Common.Notification
{
    [AppRoute("common", "[controller]")]
    [Tags("common/notification")]
    [Authorize(Roles = "doctor, member")]
    public class NotificationController : AppControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(NotificationQueryResponse), StatusCodes.Status200OK)]
        public async Task<Ok<NotificationQueryResponse>> GetNotifications([FromHeader(Name = "x-app-name"), BindRequired] string appName,[FromQuery] NotificationQuery query)
        {
            return TypedResults.Ok(await Sender.Send(query));
        }

        [HttpGet("count")]
        [ProducesResponseType(typeof(NotificationCountResponse), StatusCodes.Status200OK)]
        public async Task<Ok<NotificationCountResponse>> GetCounts([FromHeader(Name = "x-app-name"), BindRequired] string appName,[FromQuery] NotificationCountQuery query)
        {
            return TypedResults.Ok(await Sender.Send(query));
        }


        [HttpPut("mark-read")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
        public async Task<Ok> PostItem([FromHeader(Name = "x-app-name"), BindRequired] string appName, [FromBody] PutNotificationCommand command)
        {
           await Sender.Send(command);
            return TypedResults.Ok();
        }


    }
}
