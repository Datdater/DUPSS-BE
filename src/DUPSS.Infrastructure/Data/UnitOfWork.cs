using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;
using DUPSS.Domain.Repositories;
using DUPSS.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore.Storage;

namespace DUPSS.Infrastructure.Data
{
    public class UnitOfWork(DUPSSContext context) : IUnitOfWork
    {
        private Hashtable? _repository;
        private IDbContextTransaction? _transaction;

        public IGenericRepository<T> Repository<T>()
            where T : BaseEntity
        {
            _repository ??= new Hashtable();

            var type = typeof(T).Name;

            if (_repository.ContainsKey(type))
                return (IGenericRepository<T>)_repository[type]!;

            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(T)),
                context
            );
            _repository.Add(type, repositoryInstance);

            return (IGenericRepository<T>)_repository[type]!;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            context.Dispose();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction has not been started.");
            }

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction has not been started.");
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
