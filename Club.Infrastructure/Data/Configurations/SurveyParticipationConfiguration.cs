using Club.Domain.Entities.Surveys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Club.Infrastructure.Data.Configurations;

public class SurveyParticipationConfiguration : IEntityTypeConfiguration<SurveyParticipation>
{
    public void Configure(EntityTypeBuilder<SurveyParticipation> entity)
    {
        entity.ToTable("SurveyParticipations");

        entity.HasKey(e => e.Id);

        entity.Property(e => e.ParticipationDate)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("getutcdate()");

        entity.Property(e => e.PointsEarned)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(e => e.Comment)
            .HasMaxLength(1000);

        // Relationships
        entity.HasOne(d => d.Survey)
            .WithMany(p => p.Participations)
            .HasForeignKey(d => d.SurveyId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entity.HasOne(d => d.Customer)
            .WithMany()
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        entity.HasOne(d => d.SelectedItem)
            .WithMany(i => i.Participations)
            .HasForeignKey(d => d.SelectedItemId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Indexes
        entity.HasIndex(e => e.SurveyId);
        entity.HasIndex(e => e.CustomerId);
        entity.HasIndex(e => new { e.SurveyId, e.CustomerId })
            .IsUnique(); // هر مشتری فقط یکبار در هر نظرسنجی شرکت کند
        entity.HasIndex(e => e.ParticipationDate);
    }
}



