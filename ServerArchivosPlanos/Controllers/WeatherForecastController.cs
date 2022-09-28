using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Share.Data;
using Share.Models.Context;

namespace ServerArchivosPlanos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ProsisDBvContext _dBvContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ProsisDBvContext dBvContext)
        {
            _logger = logger;
            _dBvContext = dBvContext;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {                                  
            string.IsNullOrEmpty("");          
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("delegation")]
        public async Task<TypeDelegacion[]?> GetTypeDelegacion()
        {
           return await _dBvContext.TypeDelegacions.ToArrayAsync(); 
        }

    }
}
