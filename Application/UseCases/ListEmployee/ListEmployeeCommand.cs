
using MediatR;
using MsEmployee.Domain.Entity;
using System.Collections.Generic;

namespace MsEmployee.Application.UseCases.ListEmployee
{
    public class ListEmployeeCommand: IRequest<ListEmployeeCommandResponse>
    {
    }
}
