using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DUPSS.Application.Abtractions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DUPSS.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly Dictionary<string, DateTime> _refreshTokens = new();

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(string userId, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(
            _configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT key not configured")
        );

        var claims = new List<Claim> { new(ClaimTypes.NameIdentifier, userId) };

        claims.Add(new Claim(ClaimTypes.Role, role));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(_configuration["Jwt:AccessTokenExpiryMinutes"] ?? "30")
            ),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        var refreshToken = Convert.ToBase64String(randomNumber);

        // Store refresh token with expiry (can be replaced with database storage)
        _refreshTokens[refreshToken] = DateTime.UtcNow.AddDays(
            Convert.ToDouble(_configuration["Jwt:RefreshTokenExpiryDays"] ?? "7")
        );

        return refreshToken;
    }

	public bool ValidateAccessToken(string token, string userId, string role)
	{
		userId = string.Empty;
		role = string.Empty;

		try
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(
				_configuration["Jwt:Key"]
					?? throw new InvalidOperationException("JWT key not configured")
			);

			tokenHandler.ValidateToken(
				token,
				new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = true,
					ValidIssuer = _configuration["Jwt:Issuer"],
					ValidateAudience = true,
					ValidAudience = _configuration["Jwt:Audience"],
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
				},
				out var validatedToken
			);

			var jwtToken = (JwtSecurityToken)validatedToken;
			userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
			role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value;

			return true;
		}
		catch
		{
			return false;
		}
	}

    public bool ValidateRefreshToken(string token)
    {
        if (!_refreshTokens.TryGetValue(token, out var expiry))
            return false;

        if (expiry < DateTime.UtcNow)
        {
            _refreshTokens.Remove(token);
            return false;
        }

        return true;
    }

    public (string accessToken, string refreshToken) RefreshTokens(
        string refreshToken,
		string userId,
        string role
    )
    {
        if (!ValidateRefreshToken(refreshToken))
            throw new InvalidOperationException("Invalid or expired refresh token");

        // Remove the old refresh token
        _refreshTokens.Remove(refreshToken);

        // Generate new tokens
        string newAccessToken = GenerateAccessToken(userId, role);
        string newRefreshToken = GenerateRefreshToken();

        return (newAccessToken, newRefreshToken);
    }
}
