
using System.Text.RegularExpressions;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;
using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Employees.Update
{
   
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        private readonly IDesignationQueryRepository _designationQueryRepository;
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        public UpdateEmployeeCommandValidator(IDepartmentQueryRepository departmentQueryRepository, IDesignationQueryRepository designationQueryRepository)
        {
            _departmentQueryRepository = departmentQueryRepository;
            _designationQueryRepository = designationQueryRepository;
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("FirstName can not be null or empty");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("LastName can not be null or empty");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("LastName can not be null or empty");
            RuleFor(x => x.DepartmentId).NotEmpty().NotNull().WithMessage("Department can not be null or empty");
            RuleFor(x => x.DesignationId).NotEmpty().NotNull().WithMessage("Designation can not be null or empty");
            RuleFor(p => p.JoiningDate).LessThan(p => p.DateOfBirth).WithMessage("Joining Date Can't be less than Date of Birth");
            RuleFor(p => p.JoiningDate.AddYears(18)).LessThan(p => p.DateOfBirth).WithMessage("Must be 18 years old to join");
            RuleFor(x => new { x.FirstName, x.LastName, x.Email, x.DesignationId, x.DepartmentId }).CustomAsync(async (property, context, cancellationToken) =>
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
                if (property.DepartmentId == 0)
                {
                    context.AddFailure("Must select department"); return;
                }
                if (property.DesignationId == 0)
                {
                    context.AddFailure("Must select designation"); return;
                }
                if (_departmentQueryRepository.Get(property.DepartmentId, cancellationToken) == null)
                {
                    context.AddFailure("Must select valid department"); return;
                }
                if (_designationQueryRepository.Get(property.DesignationId, cancellationToken) == null)
                {
                    context.AddFailure("Must select valid designation"); return;
                }
            });
        }
    }
}
