namespace EnvironmentData.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IWeatherService
    {
        IEnumerable<Station> GetStations(string riverName);

        IEnumerable<StationReading> GetStationReadings(string stationRef);

        StationReadingResult GetStationReadingsResult(string stationRef);

        void Execute();
    }
}
