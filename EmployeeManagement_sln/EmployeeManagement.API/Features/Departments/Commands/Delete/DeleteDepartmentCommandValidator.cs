
using FluentValidation;

namespace EmployeeManagement.API.Features.Departments.Commands.Delete
{

    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
       
        public DeleteDepartmentCommandValidator()
        {
            
            CascadeMode = CascadeMode.Stop;
           
        }
    }
}
