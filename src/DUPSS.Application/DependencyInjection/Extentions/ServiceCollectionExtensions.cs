using DUPSS.Application.Behaviors;
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
            .AddValidatorsFromAssemblies(
                [AssemblyReference.Assembly],
                includeInternalTypes: true
            );

    public static void AddConfigureAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(opts => opts.AddMaps(AssemblyReference.Assembly));

}
