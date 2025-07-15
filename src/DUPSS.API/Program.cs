using DUPSS.API.Middlewares;
using DUPSS.Application.Commons;
using DUPSS.Application.DependencyInjection.Extentions;
using DUPSS.Infrastructure.DependencyInjection.Extentions;
using HSMS.API.DependencyInjection.Extentions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Newtonsoft.Json.Converters;

namespace DUPSS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;
            var serviceCollection = builder.Services;

            // Swagger
            serviceCollection
                .AddSwaggerGenNewtonsoftSupport()
                .AddFluentValidationRulesToSwagger()
                .AddEndpointsApiExplorer()
                .AddSwagger();

            // Middleware
            serviceCollection.AddTransient<ExceptionHandlingMiddleware>();

            // Email Settings
            builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            // Controllers + JSON enum as string
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

            // Services
            serviceCollection.AddConfigureServiceCollection();

            // Infrastructure
            serviceCollection.AddPersistenceService(configuration);

            // Identity
            builder.Services.AddIdentityService();

            // Authentication & Authorization
            builder.Services.AddAuthenticationAuthorizationService(configuration);

            // OpenAPI
            builder.Services.AddOpenApi();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                );
            });

            var app = builder.Build();

            // Swagger
            app.UseSwaggerConfig();
            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
