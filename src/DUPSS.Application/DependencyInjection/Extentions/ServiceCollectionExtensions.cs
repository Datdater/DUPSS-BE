using Application.Services;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Behaviors;
using DUPSS.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DUPSS.Application.DependencyInjection.Extentions;

public static class ServiceCollectionExtensions
{
    public static void AddConfigureMediatR(this IServiceCollection services) =>
        services
            .AddMediatR(config => config.RegisterServicesFromAssembly(AssemblyReference.Assembly))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
            .AddValidatorsFromAssemblies([AssemblyReference.Assembly], includeInternalTypes: true);

    public static void AddConfigureAutoMapper(this IServiceCollection services) =>
    services.AddAutoMapper(AssemblyReference.Assembly);


    public static void AddConfigureServiceCollection(this IServiceCollection services) =>
        services
            .AddHttpContextAccessor()
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IEmailService, EmailService>()
            .AddScoped<IClaimService, ClaimService>()
            .AddScoped<IGenerateUniqueCode, GenerateUniqueCode>();
}
