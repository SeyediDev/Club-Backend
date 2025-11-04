using Club.Application.Features.Account.Commands.LoginUser;
using Club.Application.Features.Account.Commands.Refresh;
using Club.Application.Features.Account.Commands.VerifyLogin;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Club.Web.Controllers;

[VersionRoute("[controller]")]
public class AccountController : AppControllerBase
{
    [HttpPost("login")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<LoginUserCommandResponse> LoginUser([FromBody] LoginUserCommand command, [FromHeader(Name = "x-app-name"), BindRequired] string appName)
    {
        return await Sender.Send(command);
    }

    [HttpPost("verify")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<VerifyLoginCommandResponse>> VerifyLoginUser([FromBody] VerifyLoginCommand command, [FromHeader(Name = "x-app-name"), BindRequired] string appName)
    {
        return TypedResults.Ok(await Sender.Send(command));
    }

    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<RefreshTokenCommandResponse>> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        return TypedResults.Ok(await Sender.Send(command));
    }
}
