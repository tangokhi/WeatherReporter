using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BusinessLayer.Libraries
{
    public sealed class WeatherClient : IWeatherClient
    {
        private bool _isDisposed;

        private readonly IConfigurationMap _configurationMap;

        private readonly HttpClient _client = new HttpClient();

        // URL is hardcode must be read from config.
        private const string _url = "http://api.openweathermap.org/data/2.5/forecast/daily?APPID=39c35f311c64c8b265d5a23d5d9b6d5b&units=metric&cnt=5&q=";

        public WeatherClient(IConfigurationMap configurationMap)
        {
            _configurationMap = configurationMap;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _client.Dispose();
            _isDisposed = true;
        }

        public string GetWeather(string cityCountry)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            try
            {
                string url = ApiUrlBuilder.BuildUrl(_configurationMap, cityCountry);
                HttpResponseMessage response = _client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }

            // Log any errors
            return null;

        }
    }
}
