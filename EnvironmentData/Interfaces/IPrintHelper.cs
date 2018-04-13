namespace EnvironmentData.Interfaces
{
    using Models;

    public interface IPrintHelper
    {
        void PrintToConsole(StationReadingResult stationReading);
    }
}
