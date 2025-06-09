using HSMS.API.DependencyInjection.Options;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace HSMS.API.DependencyInjection.Extentions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
    }

    public static void UseSwaggerConfig(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "HSMS API V1");
            c.DisplayRequestDuration();
            c.EnableTryItOutByDefault();
            c.DocExpansion(DocExpansion.None);
        });

        app.MapGet("/", () => Results.Redirect("swagger/index.html")).WithTags(string.Empty);
    }
}
