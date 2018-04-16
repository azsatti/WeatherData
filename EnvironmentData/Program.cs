namespace EnvironmentData
{
    using System;
    using Interfaces;
    using Properties;
    using Utility;
    
    public class Program
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly IPrintHelper PrintHelper = new PrintHelper();

        public static void Main(string[] args)
        {
            LoggingHelper.Initialize();
            PrintHelper.Print($"---River --- {Settings.Default.RiverName}--- ", true);
            CallWeatherApi();
            PrintHelper.Print("Press enter to close...", false);
            Console.ReadLine();
        }

        private static void CallWeatherApi()
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
