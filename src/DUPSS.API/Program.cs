using DUPSS.API.Middlewares;
using DUPSS.Application.Commons;
using DUPSS.Application.DependencyInjection.Extentions;
using DUPSS.Infrastructure.DependencyInjection.Extentions;
using HSMS.API.DependencyInjection.Extentions;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;


namespace DUPSS.API
{
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

			builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));


			// MediatR
			serviceCollection.AddConfigureMediatR();

            // AutoMapper
            serviceCollection.AddConfigureAutoMapper();

            // Services
            serviceCollection.AddConfigureServiceCollection();

            // CollectionServices
            serviceCollection.AddPersistenceService(configuration);
            //Identity 
			builder.Services.AddIdentityService();
            //Authentication 
			builder.Services.AddAuthenticationAuthorizationService(configuration);


			builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseSwaggerConfig();

			app.UseHttpsRedirection();

			app.UseAuthentication();


			app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
