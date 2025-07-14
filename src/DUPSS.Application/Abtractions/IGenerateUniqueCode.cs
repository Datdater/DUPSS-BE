using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Abtractions
{
    public interface IGenerateUniqueCode
    {
        Task<string> GenerateUniqueCodeAsync<TEntity>(
            IGenericRepository<TEntity> repository,
            Func<TEntity, string?> codeSelector,
            int length = 7
        )
            where TEntity : BaseEntity;
    }
}
