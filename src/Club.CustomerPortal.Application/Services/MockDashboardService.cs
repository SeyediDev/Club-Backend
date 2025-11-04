using Club.CustomerPortal.Application.Interfaces;

namespace Club.CustomerPortal.Application.Services;

public class MockDashboardService : IDashboardService
{
    public Task<DashboardStatsDto> GetDashboardStatsAsync(int customerId, CancellationToken cancellationToken = default)
    {
        var stats = new DashboardStatsDto
        {
            TotalPoints = 15000,
            AvailablePoints = 12500,
            CurrentLevel = "طلایی",
            TotalReferrals = 5,
            LeaderboardPosition = 2,
            TotalRewardsPurchased = 3,
            PointsEarnedThisMonth = 2500,
            RecentActivities = new List<RecentActivityDto>
            {
                new() { Title = "خرید محصول", Description = "دریافت 500 امتیاز", OccurredAt = DateTime.Now.AddHours(-2), Type = "Points" },
                new() { Title = "معرفی دوست", Description = "دریافت 1000 امتیاز", OccurredAt = DateTime.Now.AddDays(-1), Type = "Referral" }
            }
        };

        return Task.FromResult(stats);
    }
}

