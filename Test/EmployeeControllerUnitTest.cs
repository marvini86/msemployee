using Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MsEmployee.Application.UseCases.CreateEmployee;
using MsEmployee.Application.UseCases.ListEmployee;
using MsEmployee.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsEmployee.Test
{
    public class EmployeeControllerUnitTest
    {
        private readonly Mock<IMediator> mediator;


        public EmployeeControllerUnitTest()
        {
            mediator = new Mock<IMediator>();
        }


        /* [Fact]
        public async Task Test_List_Employee()
        {

            var controller = new EmployeeController(mediator.Object);
            mediator.Setup(m => m.Send(It.IsAny<ListEmployeeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ListEmployeeCommandResponse { Employees = new List<Employee>() });

            var response = controller.Get();

            var result = Assert.IsType<OkObjectResult>(response.Result);
            
            Assert.Equal(200, result.StatusCode);
        }


        [Fact]
        public async Task Test_Should_Create_Employee()
        {
            var controller = new EmployeeController(mediator.Object);
            
            mediator.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateEmployeeCommandResponse { Success = true, Response = "Employee created succesfully" });

            var response = controller.Create(new CreateEmployeeCommand());

            var result = Assert.IsType<CreatedResult>(response.Result);

            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Test_Should_Fail_Create_Employee()
        {
            var controller = new EmployeeController(mediator.Object);

            mediator.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new CreateEmployeeCommandResponse { Success = false, Response = "Error while creating employee" });

            var response = controller.Create(new CreateEmployeeCommand());

            var result = Assert.IsType<BadRequestObjectResult>(response.Result);

            Assert.Equal(400, result.StatusCode);
        } */


    }
}
