
using MediatR;
using MsEmployee.Infrastrucuture.Repository;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
 
namespace MsEmployee.Application.UseCases.ListEmployee
{
    public class ListEmployeeCommandHandler : IRequestHandler<ListEmployeeCommand, ListEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ListEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ListEmployeeCommandResponse> Handle(ListEmployeeCommand request, CancellationToken cancellationToken)
        {
            return new ListEmployeeCommandResponse { Employees = _employeeRepository.Get().Result.ToList() }; 
        }
    }
}

