using System;

namespace BusinessLayer.Libraries
{
    public interface IWeatherClient : IDisposable
    {
        string GetWeather(string cityCountry);
    }
}
