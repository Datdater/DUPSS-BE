using DUPSS.Domain.Repositories;
using DUPSS.Infrastructure.Data;
using DUPSS.Infrastructure.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DUPSS.Infrastructure.DependencyInjection.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<DUPSSContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("HSMSConnection"))
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }

   
}
