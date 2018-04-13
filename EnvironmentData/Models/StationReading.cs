namespace EnvironmentData.Models
{
    using System;
    using Newtonsoft.Json;

    public class StationReading
    {
        [JsonConstructor]
        public StationReading()
        {
        }

        public StationReading(DateTime readingDateTime, double? value, Measure measure)
        {
            this.ReadingDateTime = readingDateTime;
            this.Value = value;
            this.Measurement = measure;
        }

        [JsonProperty("dateTime")]
        public DateTime ReadingDateTime { get; set; }

        public double? Value { get; set; }

        [JsonProperty("measure")]
        public Measure Measurement { get; set; }

        public class Measure
        {
            public Station Station { get; set; }

            public string StationReference { get; set; }

            public string UnitName { get; set; }

            public string ValueType { get; set; }
        }
    }
}
