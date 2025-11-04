using Club.Domain.Entities.Common;

namespace Club.Web.Controllers.Test;

[AppRoute("test", "[controller]")]
[Tags("test")]
public class TestController(ICommandRepository<Document, int> documentCommandRepository) : AppControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<EntityTableInfo>> RunTest([FromBody] string testNumber)
    {
        var tinfo = documentCommandRepository.UnitOfWork.GetEntityTableInfo(typeof(Document));
        await Task.CompletedTask;
        return TypedResults.Ok(tinfo);
    }
}
