using Club.Application.Features.Admin.File.Commands;
using Club.Application.Features.Admin.File.Queries;
using MediatR;

namespace Club.Web.Controllers.Admin.Common;

[AdminRoute("[controller]")]
[Tags("admin/file")]
public class FileController : AppControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Created<Unit>> CreateImage([FromBody] AddFileCommand command)
    {
        Unit unit = await Sender.Send(command);
        return TypedResults.Created(string.Empty, unit);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<FileQueryResponse>> GetFiles([FromQuery] FileQuery query)
    {
        return TypedResults.Ok(await Sender.Send(query));
    }
}
