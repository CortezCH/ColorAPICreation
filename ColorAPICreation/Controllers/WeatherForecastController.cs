using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorAPICreation.Controllers
{
    // API controllers make heavy use of attributes.
    // These attributes do the following:
    // - Tell .Net this controller is to be treated as an API
    // - Set the route to get an endpoint
    // - Set the HTTP method (GET, PUT, etc.) to be used on that endpoint
    // - Plus much much mote


    [ApiController]
    // Route above the class helps us to set the base URL
    // This on in particular sets the base URL
    // to match the name of the controller
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //Each method inside an API represents a different endpoint
        //We can set the HTTP method, as well as the name of the enpoint
        //using attributes.

        //When there is nothind specifying the route,
        //this defaults to the base url
        //API methods will automatically convert any object you return into JSON 
        //And it will turn any array or list you retunf into an array of JSON objects
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
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
