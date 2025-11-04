using Club.Channel.Application.Features.Client.Commands;

namespace Club.Web.Controllers.Events;

[AppRoute("client", "[controller]")]
[Tags("client/client")]
public class ClientController : AppControllerBase
{
    [HttpPost("add-event")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok> AddEvent([FromBody] AddEventDto dto)
    {
        EventCommand command = dto.Adapt<EventCommand>();
        await Sender.Send(command);
        return TypedResults.Ok();
    }

    [HttpPost("consume-asset")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<ConsumeAssetCommandResponse>> ConsumeAsset([FromBody] ConsumeAssetCommand command)
    {
        return TypedResults.Ok(await Sender.Send(command));
    }

    [HttpPost("transfer-points")]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status406NotAcceptable)]
    public async Task<Ok<TransferPointsResponse>> TransferPoints([FromBody] TransferPointsDto dto)
    {
        TransferPointsCommand command = dto.Adapt<TransferPointsCommand>();
        var result = await Sender.Send(command);
        return TypedResults.Ok(result);
    }
}

public record TransferPointsDto
{
    /// <summary>
    /// شناسه سازمان
    /// </summary>
    [Required]
    public int TenantId { get; set; }

    /// <summary>
    /// شماره موبایل مشتری مبدا (فرستنده)
    /// </summary>
    [Required]
    public string SourceCustomerMobile { get; set; } = null!;

    /// <summary>
    /// شماره موبایل مشتری مقصد (گیرنده)
    /// </summary>
    [Required]
    public string DestinationCustomerMobile { get; set; } = null!;

    /// <summary>
    /// شناسه نوع امتیاز
    /// </summary>
    [Required]
    public int PointId { get; set; }

    /// <summary>
    /// مقدار امتیاز برای انتقال
    /// </summary>
    [Required]
    public long Amount { get; set; }

    /// <summary>
    /// شناسه کانال رویداد
    /// </summary>
    [Required]
    public int EventChannelId { get; set; }

    /// <summary>
    /// توضیحات (اختیاری)
    /// </summary>
    public string? Description { get; set; }
}

public record AddEventDto
{
    /// <summary>
    /// شناسه سازمان
    /// </summary>
    [Required]
    public int TenantId { get; set; }
    
    /// <summary>
    /// شماره موبایل مشتری
    /// </summary>
    [Required]
    public string CustomerMobile { get; set; } = null!;
    
    /// <summary>
    /// شناسه نوع رویداد
    /// </summary>
    [Required]
    public int EventTypeId { get; set; }
    
    /// <summary>
    /// شناسه کانال رویداد
    /// </summary>
    [Required]
    public int EventChannelId { get; set; }
    
    /// <summary>
    /// پارامترهای اضافی
    /// </summary>
    public Dictionary<string, string>? Parameters { get; set; }
}
