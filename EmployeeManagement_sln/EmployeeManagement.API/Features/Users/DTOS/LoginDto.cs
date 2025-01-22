namespace EmployeeManagement.API.Features.Users.DTOS
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
