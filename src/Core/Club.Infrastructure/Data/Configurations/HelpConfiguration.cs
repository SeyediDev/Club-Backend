using Club.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Data.Configurations;
internal class HelpConfiguration : IEntityTypeConfiguration<Help>
{
    public void Configure(EntityTypeBuilder<Help> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.CreateDate).HasColumnType("datetime");
        entity.Property(e => e.ExpireDate).HasColumnType("datetime");
        entity.Property(e => e.LastModified).HasColumnType("datetime");

    }
}
