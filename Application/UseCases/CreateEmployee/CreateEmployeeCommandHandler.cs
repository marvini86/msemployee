
using MediatR;
using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;
 
namespace MsEmployee.Application.UseCases.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeCommandResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<CreateEmployeeCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await CreateEmployee(request);
                return new CreateEmployeeCommandResponse { Success = true, Response = "Employee created succesfully" };
            }
            catch (Exception)
            {
                return new CreateEmployeeCommandResponse { Success = false, Response = "Error while creating employee" };
            }
        }


        private async Task CreateEmployee(CreateEmployeeCommand request)
        {
            await _employeeRepository.Create(CreateEmployeeEntityObject(request));
        }


        private bool IsValidObject(CreateEmployeeCommand request)
        {
            return (!string.IsNullOrEmpty(request.DocumentNumber) && !string.IsNullOrEmpty(request.Name) && !string.IsNullOrEmpty(request.Department));
        }
        private Employee CreateEmployeeEntityObject(CreateEmployeeCommand request)
        {
            Employee employee = null;

            if (IsValidObject(request))
            {
                employee =  new Employee
                {
                    Name = request.Name,
                    DocumentNumber = request.DocumentNumber,
                    Department = request.Department,
                    HiringDate = request.HiringDate
                };
            }

            return employee;
            
        }

    }
}

