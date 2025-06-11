using Microsoft.EntityFrameworkCore;
using UnitOfWork.Repository.Interfaces;

namespace UnitOfWork.Repository;

internal class RepositoryReadOnly<T>(DbContext context)
    : BaseRepository<T>(context),
        IRepositoryReadOnly<T>
    where T : class { }
