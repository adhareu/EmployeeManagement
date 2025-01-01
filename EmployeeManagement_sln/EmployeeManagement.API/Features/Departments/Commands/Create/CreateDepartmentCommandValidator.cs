
using EmployeeManagement.API.Infrastructure.Repositories.Departments.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Departments.Commands.Create
{

    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;
        public CreateDepartmentCommandValidator(IDepartmentQueryRepository departmentRepository)
        {
            _departmentQueryRepository = departmentRepository;
            CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name can not be null or empty");

            RuleFor(x => new { x.Name }).CustomAsync(async (property, context, cancellationToken) =>
            {
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
