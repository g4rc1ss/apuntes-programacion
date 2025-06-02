namespace UnitOfWork.Repository.Interfaces;

public interface IRepositoryReadOnly<T> : IReadRepository<T>
    where T : class { }
