using DUPSS.API.Middlewares;
using DUPSS.Application.DependencyInjection.Extentions;
using DUPSS.Infrastructure.DbContext;
using DUPSS.Infrastructure.DependencyInjection.Extentions;
using HSMS.API.DependencyInjection.Extentions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var serviceCollection = builder.Services;
        serviceCollection
            .AddSwaggerGenNewtonsoftSupport()
            .AddFluentValidationRulesToSwagger()
            .AddEndpointsApiExplorer()
            .AddSwagger();
        serviceCollection.AddTransient<ExceptionHandlingMiddleware>();

        // MediatR
        serviceCollection.AddConfigureMediatR();

        // AutoMapper
        serviceCollection.AddConfigureAutoMapper();

        // CollectionServices
        serviceCollection.AddPersistenceService(configuration);

        // Add services to the container.
        builder.Services.AddDbContext<DUPSSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("default"))
        );
        // Add Identity
        builder
            .Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;

                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DUPSSContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseSwaggerConfig();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
