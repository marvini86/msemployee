
using Moq;
using MsEmployee.Application.UseCases.ListEmployee;
using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Repository;


namespace MsEmployee.Test
{
    public class EmployeeListCommandUnitTest
    {
        private readonly Mock<ListEmployeeCommand> command;
        private readonly Mock<IEmployeeRepository> repository;


        public EmployeeListCommandUnitTest()
        {
            command = new Mock<ListEmployeeCommand>();
            repository = new Mock<IEmployeeRepository>();
        }


        [Fact]
        public async Task Test_Handler()
        {
            var handler = new ListEmployeeCommandHandler(repository.Object);

            repository.Setup(m => m.Get()).Returns(Task.FromResult<IEnumerable<Employee>>(new List<Employee>()));

            var response = await handler.Handle(command.Object, CancellationToken.None);

            Assert.NotNull(response.Employees);
        }

    

    }
}
