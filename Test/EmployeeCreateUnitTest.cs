using MediatR;
using Moq;
using MsEmployee.Application.UseCases.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsEmployee.Test
{
    public class EmployeeCreateUnitTest
    {

        [Fact]
        public async Task Should_Test_HandlerAsync()
        {
            var mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<CreateEmployeeCommandResponse>());

            //Act
            await mediator.Object.Send(new CreateEmployeeCommand());

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<CreateEmployeeCommand>(), It.IsAny<CancellationToken>()));
        }

    }
}
