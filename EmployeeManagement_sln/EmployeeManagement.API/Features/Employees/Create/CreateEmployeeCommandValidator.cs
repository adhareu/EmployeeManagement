
using System.Text.RegularExpressions;
using FluentValidation;

namespace EmployeeManagement.API.Features.Employees.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
           
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("FirstName can not be null or empty");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("LastName can not be null or empty");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("LastName can not be null or empty");

            RuleFor(p => p.JoiningDate).LessThan(p => p.DateOfBirth).WithMessage("Joining Date Can't be less than Date of Birth");
            RuleFor(p => p.JoiningDate.AddYears(18)).LessThan(p => p.DateOfBirth).WithMessage("Must be 18 years old to join");
            RuleFor(x => new { x.FirstName, x.LastName, x.Email }).CustomAsync(async (property, context, cancellationToken) =>
            {
                if (property.FirstName.Length < 1)
                {
                    context.AddFailure("The minimum length for this field is 1"); return;
                }
                if (property.FirstName.Length > 50)
                {
                    context.AddFailure("The maximum length for this field is 50"); return;
                }
                if (property.LastName.ToString().Length < 1)
                {
                    context.AddFailure("The minimum length for this field is 1"); return;
                }
                if (property.LastName.ToString().Length > 50)
                {
                    context.AddFailure("The maximum length for this field is 50"); return;
                }
                if (property.Email.ToString().Length < 1)
                {
                    context.AddFailure("The minimum length for this field is 1"); return;
                }
                if (property.Email.ToString().Length > 50)
                {
                    context.AddFailure("The maximum length for this field is 50"); return;
                }
                var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
                var regex = new Regex(pattern);
                if (!regex.IsMatch(property.Email))
                {
                    context.AddFailure("Enter Valid Email Address"); return;
                }
            });
        }
    }
}
