using Microsoft.EntityFrameworkCore;
using UnitOfWork.Repository;
using UnitOfWork.Repository.Interfaces;
using UnitOfWork.UnitOfWork.Interfaces;

namespace UnitOfWork.UnitOfWork;

internal class UnitOfWork<TContext>(TContext context) : IRepositoryFactory, IUnitOfWork<TContext>
    where TContext : DbContext, IDisposable
{
    private Dictionary<Type, object>? _repositories;

    public IRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class
    {
        _repositories ??= [];

        Type? type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<TEntity>(Context);
        }

        return (IRepository<TEntity>)_repositories[type];
    }

    public IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>()
        where TEntity : class
    {
        _repositories ??= [];

        Type? type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new RepositoryAsync<TEntity>(Context);
        }

        return (IRepositoryAsync<TEntity>)_repositories[type];
    }

    public IRepositoryReadOnly<TEntity> GetReadOnlyRepository<TEntity>()
        where TEntity : class
    {
        _repositories ??= [];

        Type? type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new RepositoryReadOnly<TEntity>(Context);
        }

        return (IRepositoryReadOnly<TEntity>)_repositories[type];
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
