namespace DUPSS.Application.Abtractions;

public interface ITokenService
{
	string GenerateAccessToken(Guid userId, string role);
	string GenerateRefreshToken();
	bool ValidateAccessToken(string token, Guid userId, string role);
	bool ValidateRefreshToken(string token);
	(string accessToken, string refreshToken) RefreshTokens(
		string refreshToken,
		Guid userId,
		string role
	);
}
