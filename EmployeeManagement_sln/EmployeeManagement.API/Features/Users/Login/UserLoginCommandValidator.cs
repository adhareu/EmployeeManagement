
using FluentValidation;
using Microsoft.AspNetCore.Identity.Data;

namespace EmployeeManagement.API.Features.Users.Login
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator() {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("User Name can not be null or empty");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password can not be null or empty");
            RuleFor(x => new { x.UserName, x.Password }).CustomAsync(async (property, context, cancellationToken) =>
            {
                if(property.UserName != "admin" || property.Password != "admin")
                {
                    context.AddFailure("Invalid username or password."); return;
                }

            });
        }
    }
}
