namespace EnvironmentData.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IWeatherApi
    {
        IEnumerable<Station> GetStations(string riverName);

        IEnumerable<StationReading> GetStationReadings(string stationRef);

        StationReadingResult GetStationReadingsResult(string stationRef);
    }
}
