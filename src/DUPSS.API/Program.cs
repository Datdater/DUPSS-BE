using DUPSS.API.Middlewares;
using DUPSS.Application.Commons;
using DUPSS.Application.DependencyInjection.Extentions;
using DUPSS.Infrastructure.DbContext;
using DUPSS.Infrastructure.DependencyInjection.Extentions;
using HSMS.API.DependencyInjection.Extentions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var serviceCollection = builder.Services;

        // Thêm CORS
        serviceCollection.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        serviceCollection
            .AddSwaggerGenNewtonsoftSupport()
            .AddFluentValidationRulesToSwagger()
            .AddEndpointsApiExplorer()
            .AddSwagger();
        serviceCollection.AddTransient<ExceptionHandlingMiddleware>();

            builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            //EnumConverter
            builder
                .Services.AddControllers()
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            // MediatR
            serviceCollection.AddConfigureMediatR();

        // AutoMapper
        serviceCollection.AddConfigureAutoMapper();

        // CollectionServices
        serviceCollection.AddPersistenceService(configuration);

        builder.Services.AddDbContext<DUPSSContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("default"))
        );

        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DUPSSContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseSwaggerConfig();
        app.UseHttpsRedirection();

        // Sử dụng CORS
        app.UseCors("AllowFrontend");

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}