using User = Club.Domain.Entities.Common.User;

namespace Club.Domain.Repository;

public interface IUserQueryRepository : IQueryRepository<User, int>
{
    Task<User?> GetByMobileAsync(long mobile, int countryCode, CancellationToken cancellationToken);
}
