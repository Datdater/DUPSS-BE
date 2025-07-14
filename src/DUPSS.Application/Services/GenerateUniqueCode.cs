using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Domain.Commons;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Services
{
    public class GenerateUniqueCode : IGenerateUniqueCode
    {
        public async Task<string> GenerateUniqueCodeAsync<TEntity>(
            IGenericRepository<TEntity> repository,
            Func<TEntity, string?> codeSelector,
            int length = 7
        )
            where TEntity : BaseEntity
        {
            string code;
            bool codeExists;
            int maxAttempts = 3;
            int attempts = 0;
            do
            {
                code = GenerateRandomCode(length);
                codeExists = repository
                    .GetQueryable()
                    .AsEnumerable()
                    .Any(e => codeSelector(e) == code);
                attempts++;
            } while (codeExists && attempts < maxAttempts);

            if (codeExists)
            {
                throw new Exception(
                    $"Failed to generate a unique code for {typeof(TEntity).Name} after multiple attempts."
                );
            }
            return code;
        }

        private static string GenerateRandomCode(int length = 5)
        {
            const string chars = "0123456789";
            var random = new Random();
            var code = new string(
                Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()
            );
            return code;
        }
    }
}
