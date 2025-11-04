namespace Club.CustomerPortal.Application.Extensions;

/// <summary>
/// Extension methods برای IRequesterUser
/// </summary>
public static class RequesterUserExtensions
{
    /// <summary>
    /// دریافت UserId با exception اگر User login نکرده باشد
    /// </summary>
    public static int GetUserId(this IRequesterUser requesterUser)
    {
        if (!requesterUser.Id.HasValue)
        {
            throw new UnauthorizedAccessException("کاربر احراز هویت نشده است");
        }
        
        return requesterUser.Id.Value;
    }
    
    /// <summary>
    /// دریافت UserId با null اگر User login نکرده باشد
    /// </summary>
    public static int? GetUserIdOrNull(this IRequesterUser requesterUser)
    {
        return requesterUser.Id;
    }
}
