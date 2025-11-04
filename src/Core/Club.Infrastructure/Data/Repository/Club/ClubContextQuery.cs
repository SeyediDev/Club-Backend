using System.Reflection;
using Club.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Club.Infrastructure.Data.Repository.Club;

public partial class ClubContextQuery(DbContextOptions<ClubContextQuery> options)
    : ClubContext<ClubContextQuery>(options), IClubUnitOfWorkQuery
{
    protected override Assembly ContextAssembly => typeof(ClubContextQuery).Assembly;
}
