namespace EmployeeManagement.API.Features.Users.Commands.Login
{
    public class UserLoginCommand
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
