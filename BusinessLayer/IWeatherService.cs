using BusinessLayer.Dto;

namespace BusinessLayer
{
    public interface IWeatherService
    {
        string GetWeatherData(WeatherQueryParameters weatherQueryParameters);
        
    }
}
