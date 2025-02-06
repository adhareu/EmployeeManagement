using EmployeeManagement.API.Features.Departments.Repositories.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Departments.Update
{

    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        public UpdateDepartmentCommandValidator(IDepartmentQueryRepository departmentRepository)
        {
            _departmentQueryRepository = departmentRepository;
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be null or empty");

            RuleFor(x => new { x.Id, x.Name }).CustomAsync(async (property, context, cancellationToken) =>
            {
                if (property.Name.Length < 1)
                {
                    context.AddFailure("The minimum length for this field is 1"); return;
                }
                if (property.Name.Length > 50)
                {
                    context.AddFailure("The maximum length for this field is 50"); return;
                }
                var isNameExists = await _departmentQueryRepository.IsExists(property.Id, property.Name, cancellationToken);
                if (isNameExists)
                {
                    context.AddFailure("Name already exists"); return;
                }

            });
        }
    }
}
