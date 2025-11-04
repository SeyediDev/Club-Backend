using System.ComponentModel.DataAnnotations;

namespace Club.Application.Features.Forum.Commands;

/// <summary>
/// ایجاد پست (پاسخ) در انجمن
/// </summary>
public record CreatePostCommand : IRequest<int>
{
    [Required]
    public int TopicId { get; set; }
    
    [Required]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(10000)]
    public string Content { get; set; } = null!;
    
    public int? ParentPostId { get; set; }
}

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator(IMultiLingualService multiLingual)
    {
        RuleFor(x => x.TopicId).NotEmpty();
        RuleFor(x => x.CustomerId).NotEmpty();
        RuleFor(x => x.Content).NotEmpty().MaximumLength(10000);
    }
}

public class CreatePostCommandHandler(
    IClubUnitOfWorkCommand unitOfWork
) : IRequestHandler<CreatePostCommand, int>
{
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        const long postPoints = 5;

        var topicRepo = unitOfWork.Repository<ForumTopic, int>();
        var topic = await topicRepo.GetAsync(request.TopicId, cancellationToken);
        
        if (topic == null)
            throw new System.ComponentModel.DataAnnotations.ValidationException("موضوع یافت نشد");

        if (topic.IsLocked)
            throw new System.ComponentModel.DataAnnotations.ValidationException("موضوع قفل شده است");

        var post = new ForumPost
        {
            TopicId = request.TopicId,
            CustomerId = request.CustomerId,
            Content = request.Content,
            ParentPostId = request.ParentPostId,
            PointsEarned = postPoints,
            LikesCount = 0,
            IsApproved = true
        };

        unitOfWork.Repository<ForumPost, int>().Add(post);

        // به‌روزرسانی تعداد پست‌ها
        topic.PostsCount++;
        topicRepo.Update(topic);

        // اعطای امتیاز
        var customerRepo = unitOfWork.Repository<Customer, int>();
        var customer = await customerRepo.GetAsync(request.CustomerId, cancellationToken);
        if (customer != null)
        {
            customer.CurrentPointsBalance = (customer.CurrentPointsBalance ?? 0) + postPoints;
            customer.TotalPointsEarned = (customer.TotalPointsEarned ?? 0) + postPoints;
            customerRepo.Update(customer);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}



