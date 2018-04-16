namespace EnvironmentData
{
    using System;
    using Autofac;
    using Interfaces;
    using Properties;
    using Utility;
    
    public class Program
    {
        private static readonly IPrintHelper PrintHelper = new PrintHelper();

        public static void Main(string[] args)
        {
            LoggingHelper.Initialize();
            PrintHelper.Print($"---River --- {Settings.Default.RiverName}--- ", true);
            StartWeatherService();
            PrintHelper.Print("Press enter to close...", false);
            Console.ReadLine();
        }

        private static void StartWeatherService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WeatherService>().As<IWeatherService>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var application = scope.Resolve<IWeatherService>();
                application.Execute();
            }
        }
    }
}
