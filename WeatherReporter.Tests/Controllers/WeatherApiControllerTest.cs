using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReporter;
using WeatherReporter.Controllers;
using Moq;
using BusinessLayer;
using BusinessLayer.Dto;
using Newtonsoft.Json;

namespace WeatherReporter.Tests.Controllers
{
    [TestClass]
    public class WeatherApiControllerTest
    {
        [TestMethod]
        public void TestGetRetrievesWeatherReport()
        {
            const string result = "{'result':'GoodWeather'}";

            // Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(ws => ws.GetWeatherData(It.IsAny<WeatherQueryParameters>())).Returns(result);
            var controller = new WeatherApiController(mockWeatherService.Object);

            // Act
            object returnValue = controller.Get(new WeatherQueryParameters());

            object expectedResult = JsonConvert.DeserializeObject<dynamic>(result);

            var expectedResultString = expectedResult.ToString().Replace("\r\n", string.Empty);

            var returnValueString = returnValue.ToString().Replace("\r\n", string.Empty);

            // Assert
            Assert.AreEqual(expectedResultString, returnValueString);
        }

        [ExpectedException(typeof(HttpResponseException))]
        [TestMethod]
        public void TestGetByIdThrowWhenDataCannotBeRetrievedFromExternalService()
        {
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(ws => ws.GetWeatherData(It.IsAny<WeatherQueryParameters>())).Throws<HttpRequestException>();
            var controller = new WeatherApiController(mockWeatherService.Object);

            controller.Get(new WeatherQueryParameters());
        }
    }
}
