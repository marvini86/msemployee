
using MsEmployee.Domain.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MsEmployee.Application.UseCases.ListEmployee
{
    public struct ListEmployeeCommandResponse
    {
        [JsonProperty("employeeList")]
        public List<Employee> Employees { get; set; }
    }
}
