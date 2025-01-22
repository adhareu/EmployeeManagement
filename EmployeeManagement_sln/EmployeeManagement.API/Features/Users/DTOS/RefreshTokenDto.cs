namespace EmployeeManagement.API.Features.Users.DTOS
{
    public class RefreshTokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
