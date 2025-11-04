using Neo.Infrastructure.Data.Repository.Ef;
using Club.Domain.Repository;

namespace Club.Infrastructure.Data.Repository.Club;

public class CommandClubEntityRepository<TEntity, TKey>(IClubUnitOfWorkCommand commandUnitOfWork)
    : EfCommandRepository<TEntity, TKey, IClubUnitOfWorkCommand>(commandUnitOfWork)
    where TEntity : class, IEntity<TKey>, new()
    where TKey : struct
{
}

public class QueryClubEntityRepository<TEntity, TKey>(IClubUnitOfWorkQuery queryUnitOfWork)
    : EfQueryRepository<TEntity, TKey, IClubUnitOfWorkQuery>(queryUnitOfWork)
    where TEntity : class, IEntity<TKey>, new()
    where TKey : struct
{
}