using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.Repository;

internal class Repository<T>(DbContext context) : BaseRepository<T>(context), IRepository<T>
    where T : class
{
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Add(params T[] entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Add(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Delete(T entity)
    {
        T? existing = _dbSet.Find(entity);
        if (existing != null)
        {
            _dbSet.Remove(existing);
        }
    }

    public void Delete(object id)
    {
        TypeInfo? typeInfo = typeof(T).GetTypeInfo();
        IProperty? key = dbContext
            .Model.FindEntityType(typeInfo)
            .FindPrimaryKey()
            .Properties.FirstOrDefault();
        PropertyInfo? property = typeInfo.GetProperty(key?.Name);
        if (property != null)
        {
            T? entity = Activator.CreateInstance<T>();
            property.SetValue(entity, id);
            dbContext.Entry(entity).State = EntityState.Deleted;
        }
        else
        {
            T? entity = _dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }

    public void Delete(params T[] entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Delete(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Update(params T[] entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Dispose()
    {
        dbContext?.Dispose();
    }

    public virtual int Count(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? _dbSet.Count() : _dbSet.Count(predicate);
    }

    public virtual long LongCount(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? _dbSet.LongCount() : _dbSet.LongCount(predicate);
    }

    public virtual TK Max<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null ? _dbSet.Max(selector) : _dbSet.Where(predicate).Max(selector);
    }

    public virtual TK Min<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null ? _dbSet.Min(selector) : _dbSet.Where(predicate).Min(selector);
    }

    public virtual decimal Average(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null
            ? _dbSet.Average(selector)
            : _dbSet.Where(predicate).Average(selector);
    }

    public virtual decimal Sum(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null ? _dbSet.Sum(selector) : _dbSet.Where(predicate).Sum(selector);
    }

    public bool Exists(Expression<Func<T, bool>> selector = null)
    {
        return selector == null ? _dbSet.Any() : _dbSet.Any(selector);
    }
}
