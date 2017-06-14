using BusinessLayer;
using BusinessLayer.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeatherReporter.Controllers
{
    public class WeatherApiController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherApiController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        
        public object Get([FromUri]WeatherQueryParameters queryParameters)
        {
            try
            {
                return JsonConvert.DeserializeObject<dynamic>(_weatherService.GetWeatherData(queryParameters));
            }
            catch (HttpRequestException)
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                message.Content = new StringContent("Error contacting external service.");
                throw new HttpResponseException(message);
            }

        }
    }
}
