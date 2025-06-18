namespace HSMS.API.DependencyInjection.Extentions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        return services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                }
            );
        });
    }

    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
    {
        return app.UseCors("CorsPolicy");
    }
}
