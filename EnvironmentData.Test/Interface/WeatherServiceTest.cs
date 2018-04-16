namespace EnvironmentData.Test.Interface
{
    using System.Collections.Generic;
    using System.Linq;
    using EnvironmentData.Models;
    using FluentAssertions;
    using Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class WeatherServiceTest
    {
        [Test]
        public void Test()
        {
            var list = new List<Station>
            {
                new Station
                {
                Label = "Label",
                Notation = "A001",
                RiverName = "Stort",
                WiskiId = "A001"
                }
            };

            var mock = new Mock<IWeatherService>();
            mock.Setup(m => m.GetStations("Stort")).Returns(It.IsAny<IEnumerable<Station>>());
            mock.Verify();

            mock.Setup(m => m.GetStations("Stort")).Returns(list);
            mock.Verify();
        }

        [Test]
        [TestCase("Stort", ExpectedResult = 5)]
        [TestCase("Cherwell", ExpectedResult = 9)]
        public int Test_Station_Count(string stort)
        {
           var weatherApiProcessor = new WeatherService();
           return weatherApiProcessor.GetStations(stort).Count();
        }

        [Test]
        public void Test_Station_Count_Fail_Test()
        {
            var weatherApiProcessor = new WeatherService();
            weatherApiProcessor.GetStations("Cherwell").Count().Should().NotBe(10);
        }

        [Test]
        public void Test_StationReadingResult()
        {
            var weatherApiProcessor = new WeatherService();
            var result = weatherApiProcessor.GetStationReadingsResult("5151TH");
            result.StationName.Should().Be("Sawbridgeworth");
        }
    }
}
