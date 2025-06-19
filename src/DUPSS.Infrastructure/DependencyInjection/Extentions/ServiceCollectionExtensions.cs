using DUPSS.Domain.Repositories;
using DUPSS.Infrastructure.Data;
using DUPSS.Infrastructure.DbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DUPSS.Infrastructure.DependencyInjection.Extentions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceService(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<DUPSSContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("default"))
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



		return services;
    }
	public static IServiceCollection AddIdentityService(this IServiceCollection services)
	{
		// Add Identity
		services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
		{
			// User settings
			options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
			options.User.RequireUniqueEmail = true;
			// Password settings
			options.Password.RequireDigit = true;
			options.Password.RequireLowercase = true;
			options.Password.RequireNonAlphanumeric = true;
			options.Password.RequireUppercase = true;
			options.Password.RequiredLength = 6;
			options.Password.RequiredUniqueChars = 1;
			// Lockout settings
			options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
			options.Lockout.MaxFailedAccessAttempts = 5;
		})
			.AddEntityFrameworkStores<DUPSSContext>()
		.AddDefaultTokenProviders();

		return services;
	}
	public static IServiceCollection AddAuthenticationAuthorizationService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(
				options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidIssuer = configuration["Authentication:JwtSettings:Issuer"],
					ValidAudience = configuration["Authentication:JwtSettings:Audience"],
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:JwtSettings:Secret"]!))
				};
			});
		return services;
	}

}
