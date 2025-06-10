using DUPSS.API.Middlewares;
using DUPSS.Application.DependencyInjection.Extentions;
using DUPSS.Infrastructure.DbContext;
using DUPSS.Infrastructure.DependencyInjection.Extentions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var services = builder.Services;

        // Add services to the container
        services.AddControllers().AddNewtonsoftJson();

        // Add DbContext
        services.AddDbContext<DUPSSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("default")));

        // Add Identity
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DUPSSContext>()
        .AddDefaultTokenProviders();

        // Add MediatR, AutoMapper, Persistence
        services.AddConfigureMediatR();
        services.AddConfigureAutoMapper();
        services.AddPersistenceService(configuration);

        // Exception middleware
        services.AddTransient<ExceptionHandlingMiddleware>();

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "DUPSS API",
                Version = "v1"
            });
        });
        services.AddSwaggerGenNewtonsoftSupport();
        services.AddFluentValidationRulesToSwagger();

        var app = builder.Build();


        Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");

  
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "DUPSS API v1");
            c.RoutePrefix = string.Empty; 
        });

        app.UseHttpsRedirection();

        
        app.UseAuthentication(); 
        app.UseAuthorization();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
