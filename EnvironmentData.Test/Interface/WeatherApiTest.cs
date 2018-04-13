namespace EnvironmentData.Test.Interface
{
    using System.Collections.Generic;
    using EnvironmentData.Models;
    using Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class WeatherApiTest
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

            var mock = new Mock<IWeatherApi>();
            mock.Setup(m => m.GetStations("Stort")).Returns(It.IsAny<IEnumerable<Station>>());
            mock.Verify();

            mock.Setup(m => m.GetStations("Stort")).Returns(list);
            mock.Verify();
        }
    }
}
