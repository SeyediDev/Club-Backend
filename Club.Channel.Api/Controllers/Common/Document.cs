using Club.Application.Features.Common.Commands.Documents;

namespace Club.Web.Controllers.Common;

[AppRoute("common", "[controller]")]
[Tags("common/document")]
public class DocumentController : AppControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<int?>> AddDocument([FromBody] AddDocumentCommand command)
    {
        return TypedResults.Ok(await Sender.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<NoContent> RemoveDocument(int id)
    {
        await Sender.Send(new RemoveDocumentCommand() { DocumentId = id });
        return TypedResults.NoContent();
    }
}
