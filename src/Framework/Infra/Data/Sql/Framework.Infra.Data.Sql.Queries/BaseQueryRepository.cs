﻿using Framework.Core.Contracts.Data.Queries;

namespace Framework.Infra.Data.Sql.Queries;
public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;
    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
