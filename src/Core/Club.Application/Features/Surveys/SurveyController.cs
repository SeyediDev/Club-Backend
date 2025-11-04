using Club.Application.Features.Surveys.Commands;
using Club.Application.Features.Surveys.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Club.Application.Features.Surveys;

[ApiController]
[Route("api/[controller]")]
[Tags("surveys")]
public class SurveyController : ControllerBase
{
    private readonly IMediator _mediator;

    public SurveyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت لیست نظرسنجی‌ها
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<SurveyDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSurveys([FromQuery] int? tenantId, [FromQuery] SurveyType? surveyType, [FromQuery] bool? isActive)
    {
        var query = new GetSurveysQuery
        {
            TenantId = tenantId,
            SurveyType = surveyType,
            IsActive = isActive
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// دریافت جزئیات یک نظرسنجی
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SurveyDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSurveyById(int id, [FromQuery] int? customerId)
    {
        var query = new GetSurveyByIdQuery
        {
            Id = id,
            CustomerId = customerId
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// دریافت نظرسنجی‌های فعال برای مشتری
    /// </summary>
    [HttpGet("active")]
    [ProducesResponseType(typeof(List<ActiveSurveyDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetActiveSurveys([FromQuery] int tenantId, [FromQuery] int? customerId, [FromQuery] SurveyType? surveyType)
    {
        var query = new GetActiveSurveysQuery
        {
            TenantId = tenantId,
            CustomerId = customerId,
            SurveyType = surveyType
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// ایجاد نظرسنجی جدید
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetSurveyById), new { id = result }, result);
    }

    /// <summary>
    /// ویرایش نظرسنجی
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSurvey(int id, [FromBody] UpdateSurveyCommand command)
    {
        if (id != command.Id)
            return BadRequest("شناسه نظرسنجی با داده ارسالی مطابقت ندارد");

        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// حذف نظرسنجی
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSurvey(int id)
    {
        var command = new DeleteSurveyCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// شرکت در نظرسنجی (رأی دادن)
    /// </summary>
    [HttpPost("{surveyId}/participate")]
    [ProducesResponseType(typeof(ParticipateSurveyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Participate(int surveyId, [FromBody] ParticipateSurveyRequest request)
    {
        var command = new ParticipateSurveyCommand
        {
            SurveyId = surveyId,
            CustomerId = request.CustomerId,
            SelectedItemId = request.SelectedItemId,
            Comment = request.Comment
        };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

public record ParticipateSurveyRequest
{
    public int CustomerId { get; set; }
    public int SelectedItemId { get; set; }
    public string? Comment { get; set; }
}



