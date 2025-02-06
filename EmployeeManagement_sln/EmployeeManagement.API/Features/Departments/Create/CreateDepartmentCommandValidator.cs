using EmployeeManagement.API.Common.Validators;
using EmployeeManagement.API.Features.Departments.Repositories.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Departments.Create
{

    public class CreateDepartmentCommandValidator : BaseValidator<CreateDepartmentCommand>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        public CreateDepartmentCommandValidator(IDepartmentQueryRepository departmentRepository)
        {
            _departmentQueryRepository = departmentRepository;
           
            //RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be null or empty");

            RuleFor(x => new { x.Name }).CustomAsync(async (property, context, cancellationToken) =>
            {
                if(string.IsNullOrEmpty(property.Name.Trim()))
                {
                    context.AddFailure("Name can not be null or empty"); return;
                }
                if (property.Name.Length < 1)
                {
                    context.AddFailure("The minimum length for this field is 1"); return;
                }
                if (property.Name.Length > 50)
                {
                    context.AddFailure("The maximum length for this field is 50"); return;
                }
                var isNameExists = await _departmentQueryRepository.IsExists(null, property.Name, cancellationToken);
                if (isNameExists)
                {
                    context.AddFailure("Name already exists"); return;
                }

            });
        }
    }
}
