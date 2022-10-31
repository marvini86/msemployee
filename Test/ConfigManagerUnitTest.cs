using Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MsEmployee.Application.UseCases.CreateEmployee;
using MsEmployee.Application.UseCases.ListEmployee;
using MsEmployee.Infrastrucuture.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsEmployee.Test
{
    public class ConfigManagerUnitTest
    {
        private static readonly string KEY = "key";
        private static readonly string VALUE = "0";

        [Fact]
        public async Task Test()
        {
            var config = new ConfigManager();


            config.Set(KEY, VALUE);

            Assert.Equal(VALUE, config.Get(KEY));
        }


    }
}
