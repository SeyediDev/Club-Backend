using Club.Domain.Entities.Common;
using Club.Domain.Repository;
using Club.Infrastructure.Data.Repository.Club;
using Neo.Domain.Entities.Common;

namespace Club.Infrastructure.Data.Repository;
public class UserQueryRepository(IClubUnitOfWorkQuery queryUnitOfWork)
    : QueryClubEntityRepository<User, UserId>(queryUnitOfWork), IUserQueryRepository
{
    public async Task<User?> GetByMobileAsync(long mobile, int countryCode, CancellationToken cancellationToken)
    {
        return await FirstOrDefaultAsync(x => 
            x.Mobile == mobile && 
            x.CountryCode == countryCode, cancellationToken);
    }
}
