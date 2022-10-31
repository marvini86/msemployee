using Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MsEmployee.Application.UseCases.CreateEmployee;
using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Repository;


namespace MsEmployee.Test
{
    public class EmployeeCreateCommandUnitTest
    {
        private readonly Mock<CreateEmployeeCommand> command;
        private readonly Mock<IEmployeeRepository> repository;


        public EmployeeCreateCommandUnitTest()
        {
            command = new Mock<CreateEmployeeCommand>();
            repository = new Mock<IEmployeeRepository>();
        }


        [Fact]
        public async Task Test_Handler()
        {
            var handler = new CreateEmployeeCommandHandler(repository.Object);

            repository.Setup(m => m.Create(It.IsAny<Employee>())).Returns(Task.FromResult<Employee>(new Employee()));

            var response = await handler.Handle(
                new CreateEmployeeCommand { 
                    DocumentNumber = "DocumentNumber",
                    Name = "Name",
                    Department = "Department"
                }, 
                CancellationToken.None);

            Assert.NotNull(response);
        }

        [Fact]
        public async Task Test_Handler_Fail()
        {
            var handler = new CreateEmployeeCommandHandler(repository.Object);

            repository.Setup(m => m.Create(It.IsAny<Employee>())).Returns(It.IsAny<Task>());

            var response = await handler.Handle(command.Object, CancellationToken.None);

            Assert.NotNull(response);
        }

    }
}
