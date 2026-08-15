using Neo.Domain.Repository;
using Club.Domain.Repository;

namespace Club.Infrastructure.Data.Repository.Club;

/// <summary>
/// Extension methods for IClubUnitOfWorkCommand and IClubUnitOfWorkQuery to access repositories
/// </summary>
public static class ClubUnitOfWorkExtensions
{
    /// <summary>
    /// Gets a command repository for the specified entity type
    /// </summary>
    public static ICommandRepository<TEntity, TKey> Repository<TEntity, TKey>(
        this IClubUnitOfWorkCommand unitOfWork)
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct
    {
        return new CommandClubEntityRepository<TEntity, TKey>(unitOfWork);
    }

    /// <summary>
    /// Gets a query repository for the specified entity type
    /// </summary>
    public static IQueryRepository<TEntity, TKey> Repository<TEntity, TKey>(
        this IClubUnitOfWorkQuery unitOfWork)
        where TEntity : class, IEntity<TKey>, new()
        where TKey : struct
    {
        return new QueryClubEntityRepository<TEntity, TKey>(unitOfWork);
    }
}

