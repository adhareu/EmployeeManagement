
using FluentValidation;

namespace EmployeeManagement.API.Features.Designations.Commands.Delete
{

    public class DeleteDesignationCommandValidator : AbstractValidator<DeleteDesignationCommand>
    {
       
        public DeleteDesignationCommandValidator()
        {
            
            CascadeMode = CascadeMode.Stop;
           
        }
    }
}
