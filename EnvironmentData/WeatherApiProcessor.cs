namespace EnvironmentData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using PostSharp;
    using Properties;
    using Utility;

    /// <summary>
    /// implements DI and has methods which will return API data.
    /// </summary>
    public class WeatherApiProcessor : IWeatherApi
    {
        #region Private members
        private readonly ICommonHelper _commonHelper;
        #endregion

        #region Constructor
        public WeatherApiProcessor()
        {
            this._commonHelper = new CommonHelper();
        }
        #endregion

        #region Public methods

        [LogException]
        public IEnumerable<Station> GetStations(string riverName)
        {
            var url = string.Format(Settings.Default.GetStations, riverName);
            return this._commonHelper.GetList<Station>(url);
        }

        [LogException]
        public StationReadingResult GetStationReadingsResult(string stationRef)
        {
            var searchResults = this.GetStationReadings(stationRef);

            if (searchResults == null)
            {
                return null;
            }

            var stationReadings = searchResults as IList<StationReading> ?? searchResults.ToList();
            var maxReading = stationReadings.OrderByDescending(x => x.Value).FirstOrDefault();
            var minReading = stationReadings.OrderByDescending(x => x.Value).LastOrDefault();
            var avgReading = stationReadings.Average(x => x.Value);
            var firstOrDefault = stationReadings.FirstOrDefault();

            return new StationReadingResult(firstOrDefault?.Measurement.StationReference, firstOrDefault?.Measurement.Station.Label, minReading?.Value, maxReading?.Value, minReading?.ReadingDateTime, maxReading?.ReadingDateTime, avgReading, firstOrDefault?.Measurement.UnitName);
        }

        [LogException]
        public IEnumerable<StationReading> GetStationReadings(string stationRef)
        {
            var url = string.Format(Settings.Default.GetStationReadings, stationRef, DateTime.Now.AddDays(-7).ToString(Constants.ApiDateFormat));
            return this._commonHelper.GetList<StationReading>(url);
        }

        #endregion
    }
}
