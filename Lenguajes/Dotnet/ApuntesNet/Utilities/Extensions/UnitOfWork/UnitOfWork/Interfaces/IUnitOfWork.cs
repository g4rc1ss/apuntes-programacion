using Microsoft.EntityFrameworkCore;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.UnitOfWork.Interfaces;

/// <summary>
/// Defini los metodos de Unit Of Work
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Obtiene el repositorio de la entidad
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;

    /// <summary>
    /// Obtiene el repositorio de la entidad asincrono
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>()
        where TEntity : class;
    IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>()
        where TEntity : class;

    /// <summary>
    /// Realiza el commit
    /// </summary>
    /// <returns></returns>
    int SaveChanges();

    /// <summary>
    /// Realiza el commit asincrono
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
}

/// <summary>
///
/// </summary>
/// <typeparam name="TContext"></typeparam>
public interface IUnitOfWork<TContext> : IUnitOfWork
    where TContext : DbContext
{
    TContext Context { get; }
}
