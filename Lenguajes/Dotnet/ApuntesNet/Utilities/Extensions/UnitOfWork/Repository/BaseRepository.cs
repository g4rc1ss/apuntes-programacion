using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.Repository;

internal abstract class BaseRepository<T> : IReadRepository<T>
    where T : class
{
    public readonly DbContext dbContext;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepository(DbContext context)
    {
        dbContext = context ?? throw new ArgumentException(nameof(context));
        _dbSet = dbContext.Set<T>();
    }

    public DbContext GetContext()
    {
        return dbContext;
    }

    public virtual IQueryable<T> Query(string sql, params object[] parameters)
    {
        return _dbSet.FromSqlRaw(sql, parameters);
    }

    public T Search(params object[] keyValues)
    {
        return _dbSet.Find(keyValues);
    }

    public T SelectSingle(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true,
        IQueryable<T> queryCustom = null,
        bool ignoreQueryFilter = false
    )
    {
        IQueryable<T> query = null;
        if (queryCustom == null)
        {
            string? sql = string.Empty;
            query = !string.IsNullOrEmpty(sql) ? _dbSet.FromSqlRaw(sql) : _dbSet;
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

        return orderBy != null ? orderBy(query).FirstOrDefault() : query.FirstOrDefault();
    }
}
