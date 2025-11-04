using Neo.Domain.Entities.Common;
using Neo.Domain.Repository;
using Neo.Infrastructure.Data.Repository.Ef;
using Club.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using User = Club.Domain.Entities.Common.User;

namespace Club.Infrastructure.Data.Repository.Club;

public abstract partial class ClubContext<TContext>(DbContextOptions<TContext> options)
    : EfDbContext<TContext>(options), IUnitOfWork
    where TContext : DbContext
{
    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<CultureTerm> CultureTerms { get; set; }

    public virtual DbSet<Language> Language { get; set; }

    //public virtual DbSet<FaqType> Type { get; set; }

    public virtual DbSet<Faq> Faq { get; set; }
    public virtual DbSet<Help> Help { get; set; }

    // Survey entities
    public virtual DbSet<Survey> Surveys { get; set; }
    public virtual DbSet<SurveyItem> SurveyItems { get; set; }
    public virtual DbSet<SurveyParticipation> SurveyParticipations { get; set; }

    // Feedback entities
    public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
    public virtual DbSet<FeedbackComment> FeedbackComments { get; set; }
    public virtual DbSet<FeedbackAttachment> FeedbackAttachments { get; set; }
    public virtual DbSet<FeedbackLike> FeedbackLikes { get; set; }

    // Forum entities
    public virtual DbSet<ForumTopic> ForumTopics { get; set; }
    public virtual DbSet<ForumPost> ForumPosts { get; set; }
    public virtual DbSet<ForumTopicLike> ForumTopicLikes { get; set; }
    public virtual DbSet<ForumPostLike> ForumPostLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Apply all entity configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClubContext<>).Assembly);
    }
}
