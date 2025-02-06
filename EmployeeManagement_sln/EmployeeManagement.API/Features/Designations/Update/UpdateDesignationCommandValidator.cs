using EmployeeManagement.API.Features.Designations.Repositories.Queries;
using FluentValidation;

namespace EmployeeManagement.API.Features.Designations.Update
{

    public class UpdateDesignationCommandValidator : AbstractValidator<UpdateDesignationCommand>
    {
        private readonly IDesignationQueryRepository _DesignationQueryRepository;
        public UpdateDesignationCommandValidator(IDesignationQueryRepository DesignationRepository)
        {
            _DesignationQueryRepository = DesignationRepository;
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
                var isNameExists = await _DesignationQueryRepository.IsExists(property.Id, property.Name, cancellationToken);
                if (isNameExists)
                {
                    context.AddFailure("Name already exists"); return;
                }

            });
        }
    }
}
