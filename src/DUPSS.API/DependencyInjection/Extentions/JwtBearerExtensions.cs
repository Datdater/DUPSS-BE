using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace HSMS.API.DependencyInjection.Extentions;

public static class JwtBearerExtensions
{
    public static IServiceCollection AddJwtBearerExtensions(this IServiceCollection services)
    {
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String("KUMOCasaaaaaaaaaaaalassSecretKey")
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = "HSMS",
                    ValidAudience = "HSMS",
                };
            });
        services.AddAuthorization();
        return services;
    }
}
