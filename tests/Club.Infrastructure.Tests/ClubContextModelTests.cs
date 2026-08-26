using Club.Domain.Entities.Channels;
using Club.Infrastructure.Data.Repository.Club;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Club.Infrastructure.Tests;

public sealed class ClubContextModelTests
{
    [Fact]
    public void Model_Should_Map_Only_One_EventChannel_Entity()
    {
        var options = new DbContextOptionsBuilder<ClubContextQuery>()
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClubModelValidation")
            .Options;

        using var context = new ClubContextQuery(options);

        var eventChannelEntities = context.Model
            .GetEntityTypes()
            .Where(entityType => entityType.ClrType.Name == nameof(EventChannel))
            .ToList();

        eventChannelEntities.Should().ContainSingle();
        eventChannelEntities[0].ClrType.Should().Be<EventChannel>();
        eventChannelEntities[0].GetSchema().Should().Be("CoreConfig");
        eventChannelEntities[0].GetTableName().Should().Be("EventChannels");
    }
}
