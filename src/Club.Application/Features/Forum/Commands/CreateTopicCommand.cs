using System.ComponentModel.DataAnnotations;

namespace Club.Application.Features.Forum.Commands;

/// <summary>
/// ایجاد موضوع جدید در انجمن
/// </summary>
public record CreateTopicCommand : IRequest<int>
{
    [Required]
    public int TenantId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = null!;
    
    [Required]
    [MaxLength(10000)]
    public string Content { get; set; } = null!;
    
    [MaxLength(100)]
    public string? Category { get; set; }
    
    [MaxLength(500)]
    public string? Tags { get; set; }
    
    public int? ProductId { get; set; }
}

public class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator(IMultiLingualService multiLingual)
    {
        RuleFor(x => x.TenantId).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Content).NotEmpty().MaximumLength(10000);
    }
}

public class CreateTopicCommandHandler(
    IClubUnitOfWorkCommand unitOfWork
) : IRequestHandler<CreateTopicCommand, int>
{
    public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        const long topicPoints = 15;

        var topic = new ForumTopic
        {
            TenantId = request.TenantId,
            CustomerId = request.CustomerId,
            Title = request.Title,
            Content = request.Content,
            Category = request.Category,
            Tags = request.Tags,
            ProductId = request.ProductId,
            ViewsCount = 0,
            PostsCount = 0,
            LikesCount = 0
        };

        unitOfWork.Repository<ForumTopic, int>().Add(topic);

        // اعطای امتیاز
        var customerRepo = unitOfWork.Repository<Customer, int>();
        var customer = await customerRepo.GetAsync(request.CustomerId, cancellationToken);
        if (customer != null)
        {
            customer.CurrentPointsBalance = (customer.CurrentPointsBalance ?? 0) + topicPoints;
            customer.TotalPointsEarned = (customer.TotalPointsEarned ?? 0) + topicPoints;
            customerRepo.Update(customer);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return topic.Id;
    }
}



