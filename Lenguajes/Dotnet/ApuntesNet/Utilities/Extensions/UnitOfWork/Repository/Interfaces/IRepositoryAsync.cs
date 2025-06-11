using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace UnitOfWork.Repository.Interfaces;

/// <summary>
/// Define los metodos asincronos de repositorio que añaden, modifican ,eliminan y buscan
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepositoryAsync<T>
    where T : class
{
    /// <summary>
    /// Devuelve el contexto
    /// </summary>
    /// <returns></returns>
    DbContext GetContext();

    /// <summary>
    /// Devuelve una entidad a partir de los parametros
    /// </summary>
    /// <param name="predicate">se le indica el predicado por ejemplo x=>x.Baja==0</param>
    /// <param name="orderBy">order de la consulta</param>
    /// <param name="include">lista de include que debe devolver por ejemplo p=>p.Usuarios</param>
    /// <param name="disableTracking">activar o deshabilitar el tracking</param>
    /// <param name="queryCustom">Se le puede indicar un query inicial, por ejemplo para join</param>
    /// <param name="ignoreQueryFilter">activa o desactiva ignorar la query global para el tenant y baja</param>
    /// <returns></returns>
    Task<T> SingleAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true,
        IQueryable<T> queryCustom = null,
        bool ignoreQueryFilter = false
    );

    /// <summary>
    /// Obtiene una lista a apartir del predicado
    /// </summary>
    /// <param name="predicate">se le indica el predicado por ejemplo x=>x.Baja==0</param></param>
    /// <returns></returns>
    IAsyncEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Añade una entidad al contexto
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Añade una lista de entidades
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Modifica en el contexto una entidad
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Nos devuelve el numero de registros a partir de un predicado
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

    /// <summary>
    /// Nos devuelve el numero de registros en un long a partir de un predicado
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<long> LongCountAsync(Expression<Func<T, bool>> predicate = null);

    /// <summary>
    /// Nos devuelve el Max de los registros seleccionados
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<TK> MaxAsync<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    );

    /// <summary>
    /// Devuelve el Min de los registros seleccionadod
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <param name="predicate"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<TK> MinAsync<TK>(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, TK>> selector = null
    );

    /// <summary>
    /// Devueve la media de los registros seleccionados
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<decimal> AverageAsync(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    );

    /// <summary>
    /// Devuelve la suma de los registros seleccionado
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<decimal> SumAsync(
        Expression<Func<T, bool>> predicate = null,
        Expression<Func<T, decimal>> selector = null
    );

    /// <summary>
    /// Nos indica si existe algñun registro
    /// </summary>
    /// <param name="selector"></param>
    /// <returns></returns>
    Task<bool> ExistsAsync(Expression<Func<T, bool>> selector = null);
}
