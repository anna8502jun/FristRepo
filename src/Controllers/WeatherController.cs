using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using dotnet_api_project.Services;
using dotnet_api_project.Models;
namespace dotnet_api_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        /// <summary>
        /// Gets all weather forecasts.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
        public IActionResult GetWeather()
        {
            try
            {
                var forecasts = _weatherService.GetAllForecasts();
                return Ok(forecasts);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving forecasts.");
            }
        }

        /// <summary>
        /// Gets a weather forecast by ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WeatherForecast), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetWeatherById(int id)
        {
            try
            {
                var forecast = _weatherService.GetForecastById(id);
                if (forecast == null)
                {
                    return NotFound();
                }
                return Ok(forecast);
            }
            catch
            {
                return StatusCode(500, "An error occurred while retrieving the forecast.");
            }
        }

        /// <summary>
        /// Creates a new weather forecast.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(WeatherForecast), 201)]
        [ProducesResponseType(400)]
        public IActionResult CreateWeather([FromBody] WeatherForecast forecast)
        {
            if (forecast == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var createdForecast = _weatherService.AddForecast(forecast);
                return CreatedAtAction(nameof(GetWeatherById), new { id = createdForecast.Id }, createdForecast);
            }
            catch
            {
                return StatusCode(500, "An error occurred while creating the forecast.");
            }
        }

        /// <summary>
        /// Updates an existing weather forecast.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateWeather(int id, [FromBody] WeatherForecast forecast)
        {
            if (forecast == null || id != forecast.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updated = _weatherService.UpdateForecast(id, forecast);
                if (updated == -1)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "An error occurred while updating the forecast.");
            }
        }

        /// <summary>
        /// Deletes a weather forecast.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWeather(int id)
        {
            try
            {
                var deleted = _weatherService.DeleteForecast(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return StatusCode(500, "An error occurred while deleting the forecast.");
            }
        }
    }
}