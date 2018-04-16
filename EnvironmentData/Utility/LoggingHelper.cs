namespace EnvironmentData.Utility
{
    public static class LoggingHelper
    {
        public static void Initialize()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
