namespace Club.Application.Features.Common.Commands;

public record PutNotificationCommand : IRequest<Unit>
{
    public int? Id { get; set; }
}

public class PutNotificationCommandHandler(IRequesterUser user,
    ICommandRepository<Domain.Entities.Common.Notification, int> commandRepository) : IRequestHandler<PutNotificationCommand, Unit>
{
    public async Task<Unit> Handle(PutNotificationCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.HasValue)
        {
            await commandRepository.ExecuteUpdateAsync(x => x.UserId == user.Id!.Value
                                    && x.Id == request.Id!.Value
                                    && !x.IsDeleted,
                                    update => update.SetProperty(u => u.IsRead, true), cancellationToken);
        }
        else
        {
            await commandRepository.ExecuteUpdateAsync(x => x.UserId == user.Id!.Value
                                   && !x.IsDeleted,
                                   update => update.SetProperty(u => u.IsRead, true), cancellationToken);
        }

        await commandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
