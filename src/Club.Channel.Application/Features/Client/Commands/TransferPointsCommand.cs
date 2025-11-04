using Neo.Domain.Features.Multilingual;

namespace Club.Channel.Application.Features.Client.Commands;

/// <summary>
/// درخواست انتقال امتیاز بین دو مشتری
/// </summary>
public record TransferPointsCommand : IRequest<TransferPointsResponse>
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
    [MaxLength(15)]
    public string SourceCustomerMobile { get; set; } = null!;

    /// <summary>
    /// شماره موبایل مشتری مقصد (گیرنده)
    /// </summary>
    [Required]
    [MaxLength(15)]
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
    [Range(1, long.MaxValue, ErrorMessage = "مقدار انتقال باید بیشتر از صفر باشد")]
    public long Amount { get; set; }

    /// <summary>
    /// شناسه کانال رویداد
    /// </summary>
    [Required]
    public int EventChannelId { get; set; }

    /// <summary>
    /// توضیحات (اختیاری)
    /// </summary>
    [MaxLength(500)]
    public string? Description { get; set; }
}

public record TransferPointsResponse
{
    public long SourceTransactionId { get; set; }
    public long DestinationTransactionId { get; set; }
    public long EventLogId { get; set; }
    public long AmountTransferred { get; set; }
    public long? CommissionCharged { get; set; }
    public string Message { get; set; } = "انتقال امتیاز با موفقیت انجام شد";
}

public class TransferPointsCommandValidator : AbstractValidator<TransferPointsCommand>
{
    public TransferPointsCommandValidator(IMultiLingualService multiLingual)
    {
        RuleFor(x => x.TenantId)
            .GreaterThan(0)
            .WithMessage("شناسه سازمان الزامی است");

        RuleFor(x => x.SourceCustomerMobile)
            .NotEmpty()
            .WithMessage("شماره موبایل مبدا الزامی است")
            .Matches(@"^09\d{9}$")
            .WithMessage("شماره موبایل مبدا نامعتبر است");

        RuleFor(x => x.DestinationCustomerMobile)
            .NotEmpty()
            .WithMessage("شماره موبایل مقصد الزامی است")
            .Matches(@"^09\d{9}$")
            .WithMessage("شماره موبایل مقصد نامعتبر است")
            .NotEqual(x => x.SourceCustomerMobile)
            .WithMessage("مشتری مبدا و مقصد نمی‌توانند یکسان باشند");

        RuleFor(x => x.PointId)
            .GreaterThan(0)
            .WithMessage("شناسه امتیاز الزامی است");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("مقدار انتقال باید بیشتر از صفر باشد");

        RuleFor(x => x.EventChannelId)
            .GreaterThan(0)
            .WithMessage("شناسه کانال رویداد الزامی است");
    }
}

public class TransferPointsCommandHandler(IPointTransferService pointTransferService)
    : IRequestHandler<TransferPointsCommand, TransferPointsResponse>
{
    public async Task<TransferPointsResponse> Handle(TransferPointsCommand request, CancellationToken cancellationToken)
    {
        var transferRequest = new PointTransferRequest
        {
            TenantId = request.TenantId,
            SourceCustomerMobile = request.SourceCustomerMobile,
            DestinationCustomerMobile = request.DestinationCustomerMobile,
            PointId = request.PointId,
            Amount = request.Amount,
            EventChannelId = request.EventChannelId,
            Description = request.Description
        };

        var result = await pointTransferService.TransferPointsAsync(transferRequest, cancellationToken);

        return new TransferPointsResponse
        {
            SourceTransactionId = result.SourceTransactionId,
            DestinationTransactionId = result.DestinationTransactionId,
            EventLogId = result.EventLogId,
            AmountTransferred = result.AmountTransferred,
            CommissionCharged = result.CommissionCharged
        };
    }
}
