using Microsoft.EntityFrameworkCore;
using UnitOfWork.Repository;
using UnitOfWork.Repository.Interfaces;
using UnitOfWork.UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork;

internal class UnitOfWork<TContext>(TContext context) : IRepositoryFactory, IUnitOfWork<TContext>
    where TContext : DbContext, IDisposable
{
    private Dictionary<Type, object>? repositories;

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class
    {
        repositories ??= [];

        Type? type = typeof(TEntity);
        if (!repositories.ContainsKey(type))
        {
            repositories[type] = new Repository<TEntity>(Context);
        }

        return (IRepository<TEntity>)repositories[type];
    }

    public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>()
        where TEntity : class
    {
        repositories ??= [];

        Type? type = typeof(TEntity);
        if (!repositories.ContainsKey(type))
        {
            repositories[type] = new RepositoryAsync<TEntity>(Context);
        }

        return (IRepositoryAsync<TEntity>)repositories[type];
    }

    public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>()
        where TEntity : class
    {
        repositories ??= [];

        Type? type = typeof(TEntity);
        if (!repositories.ContainsKey(type))
        {
            repositories[type] = new RepositoryReadOnly<TEntity>(Context);
        }

        return (IRepositoryReadOnly<TEntity>)repositories[type];
    }

    public TContext Context { get; } = context ?? throw new ArgumentNullException(nameof(context));

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Context?.Dispose();
    }
}
