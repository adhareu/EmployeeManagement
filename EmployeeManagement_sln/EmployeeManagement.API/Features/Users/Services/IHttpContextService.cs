namespace EmployeeManagement.API.Features.Users.Services
{
    public interface IHttpContextService
    {
        string GenerateAccessToken(string username);
        string GenerateRefreshToken();
        void SetRefreshTokenCookie(string refreshToken);
        string GetRefreshTokenFromCookie();
    }
}
