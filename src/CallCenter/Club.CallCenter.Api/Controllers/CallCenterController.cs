using Club.Application.Features.CallCenter.Commands;
using Club.Application.Features.CallCenter.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Club.CallCenter.Api.Controllers;

[ApiController]
[Route("api/v1/call-center")]
[Authorize]
public class CallCenterController : ControllerBase
{
    private readonly IMediator _mediator;

    public CallCenterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// جستجوی مشتریان
    /// </summary>
    [HttpGet("customers/search")]
    public async Task<ActionResult<SearchCustomersQueryResponse>> SearchCustomers(
        [FromQuery] SearchCustomersQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// دریافت اطلاعات کامل مشتری
    /// </summary>
    [HttpGet("customers/{customerTenantId}/details")]
    public async Task<ActionResult<CustomerDetailsDto>> GetCustomerDetails(
        int customerTenantId,
        [FromQuery] bool includeInteractions = true,
        [FromQuery] int? interactionsPageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetCustomerDetailsQuery
        {
            CustomerTenantId = customerTenantId,
            IncludeInteractions = includeInteractions,
            InteractionsPageSize = interactionsPageSize
        };

        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// دریافت لیست تعاملات
    /// </summary>
    [HttpGet("interactions")]
    public async Task<ActionResult<GetCustomerInteractionsQueryResponse>> GetInteractions(
        [FromQuery] GetCustomerInteractionsQuery query,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// دریافت جزئیات یک تعامل
    /// </summary>
    [HttpGet("interactions/{interactionId}")]
    public async Task<ActionResult<CustomerInteractionDetailDto>> GetInteraction(
        long interactionId,
        CancellationToken cancellationToken)
    {
        var query = new GetCustomerInteractionByIdQuery(interactionId);
        var result = await _mediator.Send(query, cancellationToken);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// ایجاد تعامل جدید
    /// </summary>
    [HttpPost("interactions")]
    public async Task<ActionResult<long>> CreateInteraction(
        [FromBody] CreateCustomerInteractionCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetInteraction), new { interactionId = result }, result);
    }

    /// <summary>
    /// به‌روزرسانی تعامل
    /// </summary>
    [HttpPut("interactions/{interactionId}")]
    public async Task<IActionResult> UpdateInteraction(
        long interactionId,
        [FromBody] UpdateCustomerInteractionCommand command,
        CancellationToken cancellationToken)
    {
        var updateCommand = command with { InteractionId = interactionId };
        await _mediator.Send(updateCommand, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// دریافت آمار داشبورد مشتری (مشابه پرتال مشتریان)
    /// </summary>
    [HttpGet("customers/{customerTenantId}/dashboard-stats")]
    public async Task<ActionResult<GetCustomerDashboardStatsQueryResponse>> GetCustomerDashboardStats(
        int customerTenantId,
        CancellationToken cancellationToken)
    {
        var query = new GetCustomerDashboardStatsQuery
        {
            CustomerTenantId = customerTenantId
        };
        var result = await _mediator.Send(query, cancellationToken);
        return Ok(result);
    }
}

