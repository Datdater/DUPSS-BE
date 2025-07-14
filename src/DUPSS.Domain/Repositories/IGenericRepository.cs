using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Repositories;

public interface IGenericRepository<T>
    where T : BaseEntity
{
    IQueryable<T> GetQueryable();
    Task<T?> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CountAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
