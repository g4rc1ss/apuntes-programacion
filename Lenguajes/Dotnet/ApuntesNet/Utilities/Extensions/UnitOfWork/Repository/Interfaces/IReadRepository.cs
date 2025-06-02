using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace UnitOfWork.Repository.Interfaces;

/// <summary>
/// Implementa los métodos de lectura del repositorio
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IReadRepository<T>
    where T : class
{
    /// <summary>
    /// Devuelve el contexto de base de datos
    /// </summary>
    /// <returns></returns>
    DbContext GetContext();

    /// <summary>
    /// Ejecuta una raw sql
    /// </summary>
    /// <param name="sql">sql a ejecutar</param>
    /// <param name="parameters">array de parametros de la consulta</param>
    /// <returns></returns>
    IQueryable<T> Query(string sql, params object[] parameters);

    /// <summary>
    /// Devuelve la entidad que cumple con la clave proimaria que se le pasa por parametro
    /// </summary>
    /// <param name="keyValues"></param>
    /// <returns></returns>
    T Search(params object[] keyValues);

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
    T SelectSingle(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        bool disableTracking = true,
        IQueryable<T> queryCustom = null,
        bool ignoreQueryFilter = false
    );
}
