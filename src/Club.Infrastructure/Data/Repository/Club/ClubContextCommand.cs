using Club.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Club.Infrastructure.Data.Repository.Club;

public partial class ClubContextCommand(DbContextOptions<ClubContextCommand> options)
    : ClubContext<ClubContextCommand>(options), IClubUnitOfWorkCommand
{
    protected override Assembly ContextAssembly => typeof(ClubContextCommand).Assembly;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
