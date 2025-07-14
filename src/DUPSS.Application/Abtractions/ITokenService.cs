namespace DUPSS.Application.Abtractions;

public interface ITokenService
{
	string GenerateAccessToken(string userId, string role);
	string GenerateRefreshToken();
	bool ValidateAccessToken(string token, string userId, string role);
	bool ValidateRefreshToken(string token);
	(string accessToken, string refreshToken) RefreshTokens(
		string refreshToken,
		string userId,
		string role
	);
}
