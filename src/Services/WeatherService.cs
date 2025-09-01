using System.Collections.Generic;
using System.Linq;
using dotnet_api_project.Models;
namespace dotnet_api_project.Services
{
    public class WeatherService
    {
        private readonly List<WeatherForecast> _forecasts = new List<WeatherForecast>();

        public IEnumerable<WeatherForecast> GetAllForecasts()
        {
            return _forecasts;
        }

        public WeatherForecast? GetForecastById(int id)
        {
            return _forecasts.FirstOrDefault(f => f.Id == id);
        }

        public WeatherForecast AddForecast(WeatherForecast forecast)
        {
            forecast.Id = _forecasts.Count > 0 ? _forecasts.Max(f => f.Id) + 1 : 1;

            _forecasts.Add(forecast);

            return _forecasts[_forecasts.Count - 1];
        }

        public int UpdateForecast(int id, WeatherForecast updatedForecast)
        {
            var index = _forecasts.FindIndex(f => f.Id == id);
            if (index != -1)
            {
                _forecasts[index] = updatedForecast;
            }
            return index;
        }

        public bool DeleteForecast(int id)
        {
            var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
            if (forecast != null)
            {
                _forecasts.Remove(forecast);
                return true;
            }
            return false;        
        }
    }
}