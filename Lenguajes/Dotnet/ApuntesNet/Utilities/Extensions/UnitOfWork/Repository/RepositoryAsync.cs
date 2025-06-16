using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.Repository;

internal class RepositoryAsync<T> : IRepositoryAsync<T>
    where T : class
{
    protected readonly DbContext dbContext;
    protected readonly DbSet<T> dbSet;

    public RepositoryAsync(DbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.Set<T>();
    }

    public DbContext GetContext()
    {
        return dbContext;
    }

    public Task<T> SingleAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true,
        IQueryable<T> queryCustom = null,
        bool ignoreQueryFilter = false
    )
    {
        IQueryable<T> query;
        if (queryCustom == null)
        {
            string? sql = string.Empty;
            query = !string.IsNullOrEmpty(sql) ? dbSet.FromSqlRaw(sql) : dbSet;
        }
        else
        {
            query = queryCustom;
        }
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (ignoreQueryFilter)
        {
            query = query.IgnoreQueryFilters();
        }

        return orderBy != null
            ? orderBy(query).SingleOrDefaultAsync()
            : query.SingleOrDefaultAsync();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        EntityEntry<T>? addEntity = await dbSet.AddAsync(entity, cancellationToken);
        return addEntity.Entity;
    }

    public Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        return dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? dbSet.CountAsync() : dbSet.CountAsync(predicate);
    }

    public virtual Task<long> LongCountAsync(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? dbSet.LongCountAsync() : dbSet.LongCountAsync(predicate);
    }

    public virtual Task<TK> MaxAsync<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null
            ? dbSet.MaxAsync(selector)
            : dbSet.Where(predicate).MaxAsync(selector);
    }

    public virtual Task<TK> MinAsync<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null
            ? dbSet.MinAsync(selector)
            : dbSet.Where(predicate).MaxAsync(selector);
    }

    public virtual Task<decimal> AverageAsync(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null
            ? dbSet.AverageAsync(selector)
            : dbSet.Where(predicate).AverageAsync(selector);
    }

    public virtual Task<decimal> SumAsync(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null
            ? dbSet.SumAsync(selector)
            : dbSet.Where(predicate).SumAsync(selector);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> selector = null)
    {
        return selector == null ? dbSet.AnyAsync() : dbSet.AnyAsync(selector);
    }

    public IAsyncEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return dbSet.Where(predicate).AsAsyncEnumerable();
    }
}
