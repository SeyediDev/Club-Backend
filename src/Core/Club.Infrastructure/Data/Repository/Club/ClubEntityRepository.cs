using Neo.Infrastructure.Data.Repository.Ef;
using Neo.Domain.Repository;
using Club.Domain.Repository;

namespace Club.Infrastructure.Data.Repository.Club;

public class CommandClubEntityRepository<TEntity>(IClubUnitOfWorkCommand commandUnitOfWork)
	: CommandClubEntityRepository<TEntity, int>(commandUnitOfWork), ICommandRepository<TEntity>
	where TEntity : class, IEntity<int>, new()
{
}

public class CommandClubEntityRepositoryL<TEntity>(IClubUnitOfWorkCommand commandUnitOfWork)
    : CommandClubEntityRepository<TEntity, long>(commandUnitOfWork), ICommandRepositoryL<TEntity>
    where TEntity : class, IEntity<long>, new()
{
}

public class CommandClubEntityRepository<TEntity, TKey>(IClubUnitOfWorkCommand commandUnitOfWork)
    : EfCommandRepository<TEntity, TKey, IClubUnitOfWorkCommand>(commandUnitOfWork), ICommandRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
    where TKey : struct
{
}

public class QueryClubEntityRepository<TEntity>(IClubUnitOfWorkQuery queryUnitOfWork)
	: QueryClubEntityRepository<TEntity, int>(queryUnitOfWork), IQueryRepository<TEntity>
	where TEntity : class, IEntity<int>, new()
{
}

public class QueryClubEntityRepositoryL<TEntity>(IClubUnitOfWorkQuery queryUnitOfWork)
    : QueryClubEntityRepository<TEntity, long>(queryUnitOfWork), IQueryRepositoryL<TEntity>
    where TEntity : class, IEntity<long>, new()
{
}

public class QueryClubEntityRepository<TEntity, TKey>(IClubUnitOfWorkQuery queryUnitOfWork)
    : EfQueryRepository<TEntity, TKey, IClubUnitOfWorkQuery>(queryUnitOfWork), IQueryRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
    where TKey : struct
{
}