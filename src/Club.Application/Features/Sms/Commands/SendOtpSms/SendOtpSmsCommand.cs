using Neo.Domain.Features.Sms.Dto;

namespace Club.Application.Features.Sms.Commands.SendOtpSms;

/// <summary>
/// Command for sending OTP SMS
/// </summary>
public record SendOtpSmsCommand(string Mobile, string Message) : IRequest<bool>
{
    /// <summary>
    /// Converts to OtpSmsDto
    /// </summary>
    public OtpSmsDto ToDto() => new(Mobile, Message);
}

