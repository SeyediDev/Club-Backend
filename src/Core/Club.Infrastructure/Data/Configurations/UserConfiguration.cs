using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using User = Club.Domain.Entities.Common.User;

namespace Club.Infrastructure.Data.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasKey(e => e.Id).HasName("Id");

        entity.Property(e => e.CreateDate).HasColumnType("datetime");
        entity.Property(e => e.ExpireDate).HasColumnType("datetime");
        
        // Index on Mobile for faster login lookup
        entity.HasIndex(e => e.Mobile)
            .HasDatabaseName("IX_Users_Mobile")
            .IsUnique();
    }
}
