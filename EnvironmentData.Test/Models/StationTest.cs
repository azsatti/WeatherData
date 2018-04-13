namespace EnvironmentData.Test.Models
{
    using EnvironmentData.Models;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class StationTest
    {
        [Test]
        public void TestConstructor()
        {
            var station = new Station("Sawbridgeworth", "A001", "A001", "Stort");

            Assert.AreEqual("Sawbridgeworth", station.Label);
            Assert.AreEqual("A001", station.Notation);
            Assert.AreEqual("Stort", station.RiverName);
            Assert.AreEqual("A001", station.WiskiId);
        }

        [Test]
        public void TestSerialisation()
        {
            var station = new Station("Sawbridgeworth", "A001", "A001", "Stort");

            var result = JsonConvert.SerializeObject(station);
            var roundtripped = JsonConvert.DeserializeObject<Station>(result);

            Assert.AreEqual(
                @"{""Label"":""Sawbridgeworth"",""WiskiId"":""A001"",""Notation"":""A001"",""RiverName"":""Stort""}",
                result);
            Assert.AreEqual("A001", station.Notation);
            Assert.AreEqual("Stort", roundtripped.RiverName);
        }
    }
}
