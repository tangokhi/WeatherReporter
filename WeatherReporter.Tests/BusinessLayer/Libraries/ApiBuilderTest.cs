using BusinessLayer.Libraries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WeatherReporter.Tests.BusinessLayer.Libraries
{
    [TestClass]
    public class ApiBuilderTest
    {
        [TestMethod]
        public void BuildUrlSuccessfullyCreatesUrl()
        {
            const string city = "London";
            var mockConfigurationMap = new Mock<IConfigurationMap>();

            mockConfigurationMap.Setup(c => c.RetrieveValue("WeatherApiurl")).Returns("http://localhost");
            mockConfigurationMap.Setup(c => c.RetrieveValue("WeatherApikey")).Returns("key");

            string expectedUrl = string.Format("http://localhost?APPID=key&units=metric&cnt=5&q={0}", city);

            Assert.AreEqual(expectedUrl, ApiUrlBuilder.BuildUrl(mockConfigurationMap.Object, city));
        }
    }
}
