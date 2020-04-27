using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManagementSystem.Infra.Injections.InjectionTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagementSystem.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDependencyTest _dependencyTest;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDependencyTest dependencyTest)
        {
            _logger = logger;
            _dependencyTest = dependencyTest;
        }
        /*public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        //public IEnumerable<WeatherForecast> Get([FromServices] IDependencyTest dependencyTest)
        {
            _dependencyTest.Test();
            //dependencyTest.Test();
            _logger.LogInformation("Logger Test");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
