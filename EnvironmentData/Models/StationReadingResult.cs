namespace EnvironmentData.Models
{
    using System;

    public class StationReadingResult
    {
        public StationReadingResult(string stationRef, string stationName, double? minValue, double? maxValue, DateTime? dateMinValue, DateTime? dateMaxValue, double? avgValue, string unitName)
        {
            this.StationRef = stationRef;
            this.StationName = stationName;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.DateMinValue = dateMinValue;
            this.DateMaxValue = dateMaxValue;
            this.AvgValue = avgValue;
            this.UnitName = unitName;
        }

        public string StationRef { get; set; }

        public string StationName { get; set; }

        public double? MinValue { get; set; }

        public double? MaxValue { get; set; }

        public DateTime? DateMinValue { get; set; }

        public DateTime? DateMaxValue { get; set; }

        public double? AvgValue { get; set; }

        public string UnitName { get; set; }
    }
}
