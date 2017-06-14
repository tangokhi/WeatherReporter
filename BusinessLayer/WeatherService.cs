using BusinessLayer.Dto;
using BusinessLayer.Libraries;

namespace BusinessLayer
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherClient _weatherClient;

        public WeatherService(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }

        public string GetWeatherData(WeatherQueryParameters weatherQueryParameters)
        {
            return _weatherClient.GetWeather(weatherQueryParameters.CityCountry);
        }
    }
}
