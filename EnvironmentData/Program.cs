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
            LoggingInitializer();
            Log.Info("Starting program");

            Console.WriteLine("------------------------------------------------------------- ");
            Console.WriteLine($"---------------------River ------ {Settings.Default.RiverName}-------------- ------- ");
            Console.WriteLine("------------------------------------------------------------- ");

            Console.WriteLine(Environment.NewLine);

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
                Console.WriteLine("Something went wrong, please check logs");
            }

            Log.Info("Ending program");

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }

        private static void LoggingInitializer()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
