using System.Linq.Expressions;

namespace UnitOfWork.Repository.Interfaces;

/// <summary>
/// Define los metodos de repositorio que añaden, modifican o eliminan
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> : IReadRepository<T>, IDisposable
    where T : class
{
    void Add(T entity);
    void Add(params T[] entities);
    void Add(IEnumerable<T> entities);
    void Delete(T entity);
    void Delete(object id);
    void Delete(params T[] entities);
    void Delete(IEnumerable<T> entities);
    void Update(T entity);
    void Update(params T[] entities);
    void Update(IEnumerable<T> entities);
    int Count(Expression<Func<T, bool>> predicate = null);
    long LongCount(Expression<Func<T, bool>> predicate = null);
    TK Max<TK>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TK>> selector = null);
    TK Min<TK>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TK>> selector = null);
    decimal Average(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    );
    decimal Sum(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    );
    bool Exists(Expression<Func<T, bool>> selector = null);
}
