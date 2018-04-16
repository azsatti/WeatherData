namespace EnvironmentData
{
    using System;
    using Interfaces;
    using Properties;
    using Utility;

    public class WeatherService : IWeatherService
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly IPrintHelper PrintHelper = new PrintHelper();

        public void Execute()
        {
            try
            {
                var weatherApi = new WeatherApiProcessor();
                var stortStationsList = weatherApi.GetStations(Settings.Default.RiverName);

                foreach (var station in stortStationsList)
                {
                    PrintHelper.PrintToConsole(weatherApi.GetStationReadingsResult(station.Notation));
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message); // Log the error
                PrintHelper.Print("Something went wrong, please check logs", false);
            }
        }
    }
}
