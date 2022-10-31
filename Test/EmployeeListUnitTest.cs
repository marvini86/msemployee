using MediatR;
using Moq;
using MsEmployee.Application.UseCases.ListEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsEmployee.Test
{
    public class EmployeeListUnitTest
    {

        [Fact]
        public async Task Should_Test_HandlerAsync()
        {
            var mediator = new Mock<IMediator>();

            mediator.Setup(m => m.Send(It.IsAny<ListEmployeeCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<ListEmployeeCommandResponse>());

            //Act
            await mediator.Object.Send(new ListEmployeeCommand());

            //Assert
            mediator.Verify(x => x.Send(It.IsAny<ListEmployeeCommand>(), It.IsAny<CancellationToken>()));
        }

    }
}
