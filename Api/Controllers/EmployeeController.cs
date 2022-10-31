using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MsEmployee.Application.DTO;
using MsEmployee.Application.UseCases.CreateEmployee;
using MsEmployee.Application.UseCases.ListEmployee;
using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ListEmployeeCommand());
            return new OkObjectResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand
                                                               command)
        {
            var commandResult = await _mediator.Send(command);

            return (!commandResult.Success) ? new BadRequestObjectResult(commandResult) : new CreatedResult(string.Empty, commandResult);
        }
    }
}
