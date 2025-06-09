using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HSMS.API.DependencyInjection.Options;

public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "HSMS API",
                Version = "v1",
                Description = "HSMS API Documentation",
            }
        );

        options.MapType<DateOnly>(() =>
            new() { Format = "date", Example = new OpenApiString(DateOnly.MinValue.ToString()) }
        );

        options.CustomSchemaIds(type => type.ToString().Replace("+", "."));
        options.AddSecurityDefinition(
            "Bearer",
            new OpenApiSecurityScheme
            {
                Description = "Please enter token",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
            }
        );

        options.AddSecurityRequirement(
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    new List<string> { }
                },
            }
        );
    }
}
