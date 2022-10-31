
using MediatR;
using MsEmployee.Application.DTO;
using MsEmployee.Domain.Entity;

namespace MsEmployee.Application.UseCases.CreateEmployee
{
    public class CreateEmployeeCommand : EmployeeDTO, IRequest<CreateEmployeeCommandResponse>
    {
    }
}
