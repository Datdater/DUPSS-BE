using DUPSS.Domain.Commons;
using DUPSS.Domain.Repositories;
using DUPSS.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Infrastructure.Data
{
    public class GenericRepository<T>(DUPSSContext context) : IGenericRepository<T>
    where T : BaseEntity
    {
        public IQueryable<T> GetQueryable()
        {
            return context.Set<T>();
        }

        

        public async Task<T?> GetByIdAsync(string id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        

        

        public async Task<int> CountAsync()
        {
            return await context.Set<T>().CountAsync();
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        
    }
}
