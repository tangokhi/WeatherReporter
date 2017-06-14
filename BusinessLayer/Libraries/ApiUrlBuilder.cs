using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Libraries
{
    public static class ApiUrlBuilder
    {
        public static string BuildUrl(IConfigurationMap configurationMap, string cityCountry)
        {
            string urlBase = configurationMap.RetrieveValue("WeatherApiurl");
            string apiKey = configurationMap.RetrieveValue("WeatherApikey");
            string url = $"{urlBase}?APPID={apiKey}&units=metric&cnt=5&q={cityCountry}";
            return url;
        }
    }
}
