using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Designations.Create
{

    public class CreateDesignationCommandValidator : AbstractValidator<CreateDesignationCommand>
    {
        private readonly IDesignationQueryRepository _designationQueryRepository;
        public CreateDesignationCommandValidator(IDesignationQueryRepository designationRepository)
        {
            _designationQueryRepository = designationRepository;
            RuleLevelCascadeMode = CascadeMode.Stop;
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
                var isNameExists = await _designationQueryRepository.IsExists(null, property.Name, cancellationToken);
                if (isNameExists)
                {
                    context.AddFailure("Name already exists"); return;
                }

            });
        }
    }
}
