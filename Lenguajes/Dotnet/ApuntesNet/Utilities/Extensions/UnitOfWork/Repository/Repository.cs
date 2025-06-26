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
        dbSet.Add(entity);
    }

    public void Add(params T[] entities)
    {
        dbSet.AddRange(entities);
    }

    public void Add(IEnumerable<T> entities)
    {
        dbSet.AddRange(entities);
    }

    public void Delete(T entity)
    {
        T? existing = dbSet.Find(entity);
        if (existing != null)
        {
            dbSet.Remove(existing);
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
            T? entity = dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }

    public void Delete(params T[] entities)
    {
        dbSet.RemoveRange(entities);
    }

    public void Delete(IEnumerable<T> entities)
    {
        dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public void Update(params T[] entities)
    {
        dbSet.UpdateRange(entities);
    }

    public void Update(IEnumerable<T> entities)
    {
        dbSet.UpdateRange(entities);
    }

    public void Dispose()
    {
        dbContext?.Dispose();
    }

    public virtual int Count(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? dbSet.Count() : dbSet.Count(predicate);
    }

    public virtual long LongCount(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null ? dbSet.LongCount() : dbSet.LongCount(predicate);
    }

    public virtual TK Max<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null ? dbSet.Max(selector) : dbSet.Where(predicate).Max(selector);
    }

    public virtual TK Min<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    )
    {
        return predicate == null ? dbSet.Min(selector) : dbSet.Where(predicate).Min(selector);
    }

    public virtual decimal Average(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null
            ? dbSet.Average(selector)
            : dbSet.Where(predicate).Average(selector);
    }

    public virtual decimal Sum(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    )
    {
        return predicate == null ? dbSet.Sum(selector) : dbSet.Where(predicate).Sum(selector);
    }

    public bool Exists(Expression<Func<T, bool>> selector = null)
    {
        return selector == null ? dbSet.Any() : dbSet.Any(selector);
    }
}
