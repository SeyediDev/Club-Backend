using Club.Application.Features.ReferrerCodes.Commands;
using Club.Application.Features.ReferrerCodes.Queries;
using MediatR;

namespace Club.Web.Controllers.Club;

/// <summary>
/// کنترلر مدیریت کدهای معرف برای پیاده‌سازان صفحه وب مشتری
/// </summary>
[ApiController]
[Route("api/club/[controller]")]
public class ReferrerCodeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ReferrerCodeController> _logger;

    public ReferrerCodeController(IMediator mediator, ILogger<ReferrerCodeController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// دریافت کد معرف بر اساس شناسه
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReferrerCodeDto>> GetById(int id)
    {
        var query = new GetReferrerCodeByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return NotFound(result.ErrorMessage);
    }

    /// <summary>
    /// دریافت کد معرف بر اساس کد
    /// </summary>
    [HttpGet("by-code/{code}")]
    public async Task<ActionResult<ReferrerCodeDto>> GetByCode(string code, [FromHeader(Name = "X-Tenant-Key")] string tenantKey)
    {
        var query = new GetReferrerCodeByCodeQuery { Code = code, TenantKey = tenantKey };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return NotFound(result.ErrorMessage);
    }

    /// <summary>
    /// دریافت لیست کدهای معرف مشتری
    /// </summary>
    [HttpGet("customer/{customerId}")]
    public async Task<ActionResult<List<ReferrerCodeDto>>> GetByCustomer(int customerId, [FromHeader(Name = "X-Tenant-Key")] string tenantKey)
    {
        var query = new GetReferrerCodesByCustomerQuery { CustomerId = customerId, TenantKey = tenantKey };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return BadRequest(result.ErrorMessage);
    }

    /// <summary>
    /// دریافت لیست کدهای معرف فعال
    /// </summary>
    [HttpGet("active")]
    public async Task<ActionResult<List<ReferrerCodeDto>>> GetActive([FromHeader(Name = "X-Tenant-Key")] string tenantKey, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var query = new GetActiveReferrerCodesQuery { TenantKey = tenantKey, PageNumber = pageNumber, PageSize = pageSize };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return BadRequest(result.ErrorMessage);
    }

    /// <summary>
    /// اعتبارسنجی کد معرف
    /// </summary>
    [HttpGet("validate/{code}")]
    public async Task<ActionResult<bool>> Validate(string code, [FromHeader(Name = "X-Tenant-Key")] string tenantKey)
    {
        var query = new ValidateReferrerCodeQuery { Code = code, TenantKey = tenantKey };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return BadRequest(result.ErrorMessage);
    }

    /// <summary>
    /// دریافت آمار کد معرف
    /// </summary>
    [HttpGet("{id}/stats")]
    public async Task<ActionResult<ReferrerCodeStatsDto>> GetStats(int id)
    {
        var query = new GetReferrerCodeStatsQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result.IsSuccess)
            return Ok(result.Data);

        return NotFound(result.ErrorMessage);
    }

    /// <summary>
    /// ایجاد کد معرف جدید
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateReferrerCodeCommand command, [FromHeader(Name = "X-Tenant-Key")] string tenantKey)
    {
        command.TenantKey = tenantKey;
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result.Data);

        return BadRequest(result.ErrorMessage);
    }

    ///// <summary>
    ///// تولید کد معرف جدید
    ///// </summary>
    //[HttpPost("generate")]
    //public async Task<ActionResult<string>> Generate([FromBody] GenerateReferrerCodeCommand command, [FromHeader(Name = "X-Tenant-Key")] string tenantKey)
    //{
    //    command.TenantKey = tenantKey;
    //    var result = await _mediator.Send(command);

    //    if (result.IsSuccess)
    //        return Ok(result.Data);

    //    return BadRequest(result.ErrorMessage);
    //}

}
