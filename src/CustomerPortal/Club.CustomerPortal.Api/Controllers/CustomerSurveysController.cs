using Neo.Endpoint.Controller;
using Club.CustomerPortal.Application.Features.Surveys.Commands;
using Club.CustomerPortal.Application.Features.Surveys.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Club.CustomerPortal.Api.Controllers;

[Route("api/customer/surveys")]
[Tags("customer/surveys")]
[ApiController]
[Authorize]
public class CustomerSurveysController : AppControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetSurveysQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveysQueryResponse>> GetSurveys([FromQuery] GetSurveysQuery query)
    {
        var response = await Sender.Send(query);
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetSurveyByIdQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetSurveyByIdQueryResponse>> GetById(string id)
    {
        var query = new GetSurveyByIdQuery { Id = id };
        var response = await Sender.Send(query);
        return Ok(response);
    }

    [HttpPost("{id}/submit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Submit(string id, [FromBody] SubmitSurveyCommand command)
    {
        command.SurveyId = id;
        await Sender.Send(command);
        return Ok();
    }

    [HttpGet("my-responses")]
    [ProducesResponseType(typeof(GetMySurveyResponsesQueryResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<GetMySurveyResponsesQueryResponse>> GetMyResponses(
        [FromQuery] GetMySurveyResponsesQuery query)
    {
        var response = await Sender.Send(query);
        return Ok(response);
    }
}

