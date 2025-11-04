namespace Club.Domain.Constants;

public class ClubRoles : Neo.Domain.Constants.Roles
{
    public static string Manager => nameof(Manager);
    public static string MarketingManager => nameof(MarketingManager);
    public static string FinanceManager => nameof(FinanceManager);
    public static string Analyst => nameof(Analyst);
}
