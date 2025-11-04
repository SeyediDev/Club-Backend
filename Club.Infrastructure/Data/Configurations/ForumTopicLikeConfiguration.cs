using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Club.Domain.Entities.Forum;

namespace Club.Infrastructure.Data.Configurations;

internal class ForumTopicLikeConfiguration : IEntityTypeConfiguration<ForumTopicLike>
{
    public void Configure(EntityTypeBuilder<ForumTopicLike> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.LikedDate)
            .IsRequired()
            .HasColumnType("datetime");

        // Relationships
        entity.HasOne(d => d.Topic)
            .WithMany(p => p.Likes)
            .HasForeignKey(d => d.TopicId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ForumTopicLike_ForumTopic");

        entity.HasOne(d => d.Customer)
            .WithMany()
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_ForumTopicLike_Customer");

        // Indexes - جلوگیری از لایک مجدد
        entity.HasIndex(e => new { e.TopicId, e.CustomerId })
            .IsUnique()
            .HasDatabaseName("IX_ForumTopicLike_Topic_Customer_Unique");
    }
}

