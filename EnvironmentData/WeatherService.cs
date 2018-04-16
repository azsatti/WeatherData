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
    /// has methods which will return API data. 
    /// </summary>
    public class WeatherService : IWeatherService
    {
        #region Private members
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly IPrintHelper PrintHelper = new PrintHelper();
        private readonly ICommonHelper _commonHelper;
        #endregion

        #region Constructor
        public WeatherService()
        {
            this._commonHelper = new CommonHelper(); //// auto-faq or structure map could be used instead but with limited time skipping it.
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

        public void Execute()
        {
            try
            {
                var stortStationsList = this.GetStations(Settings.Default.RiverName);

                foreach (var station in stortStationsList)
                {
                    PrintHelper.PrintToConsole(this.GetStationReadingsResult(station.Notation));
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message); // Log the error
                PrintHelper.Print("Something went wrong, please check logs", false);
            }
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
