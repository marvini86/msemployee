using Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MsEmployee.Application.DTO;
using MsEmployee.Application.UseCases.CreateEmployee;
using MsEmployee.Application.UseCases.ListEmployee;
using MsEmployee.Domain.Entity;
using MsEmployee.Infrastrucuture.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsEmployee.Test
{
    public class EntityDTOUnitTest
    {
        private static readonly string ID = "id";
        private static readonly string NAME = "name";
        private static readonly string DOCUMENT_NUMBER = "doc";
        private static readonly string DEPARTMENT = "dep";
        private static readonly DateTime HIRING_DATE = DateTime.Now;

        [Fact]
        public async Task TestEntity()
        {
            var employee = new Employee { Id = ID, Name = NAME, DocumentNumber = DOCUMENT_NUMBER, Department = DEPARTMENT, HiringDate = HIRING_DATE  };

            Assert.NotNull(employee);
        }


        [Fact]
        public async Task TestDTO()
        {
            var employee = new EmployeeDTO { Name = NAME, DocumentNumber = DOCUMENT_NUMBER, Department = DEPARTMENT, HiringDate = HIRING_DATE };

            Assert.NotNull(employee);
        }


    }
}
