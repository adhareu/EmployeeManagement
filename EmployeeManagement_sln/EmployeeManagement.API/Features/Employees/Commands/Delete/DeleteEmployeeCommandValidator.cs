
using FluentValidation;

namespace EmployeeManagement.API.Features.Employees.Commands.Delete
{

    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
       
        public DeleteEmployeeCommandValidator()
        {
            
            CascadeMode = CascadeMode.Stop;
           
        }
    }
}
