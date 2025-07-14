using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>()
        where T : BaseEntity;

    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}
