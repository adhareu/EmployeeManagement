using FluentValidation;

namespace EmployeeManagement.API.Common.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected BaseValidator()
        {
            // Apply CascadeMode.Stop globally for all rules in derived validators
            RuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
