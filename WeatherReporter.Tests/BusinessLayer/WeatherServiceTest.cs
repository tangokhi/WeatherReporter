using BusinessLayer;
using BusinessLayer.Dto;
using BusinessLayer.Libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WeatherReporter.Tests.BusinessLayer
{
    [TestClass]
    public class WeatherServiceTest
    {
        private const string cityCountry = "London,UK";

        private const string expectedResult = "{'result':'GoodWeather'}";

        [TestMethod]
        public void GetWeatherDataSuccessfullyRetrievesData()
        {
            var mockWeatherClient = new Mock<IWeatherClient>();
            mockWeatherClient.Setup(c => c.GetWeather(cityCountry)).Returns(expectedResult);

            var weatherService = new WeatherService(mockWeatherClient.Object);

            string result = weatherService.GetWeatherData(new WeatherQueryParameters { CityCountry = cityCountry });

            Assert.AreEqual(expectedResult, result);

        }
    }
}
