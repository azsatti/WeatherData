namespace EnvironmentData.Utility
{
    using System;
    using ConsoleTables;
    using Interfaces;
    using Models;

    /// <summary>
    /// This class will print to console in a nice format. 
    /// The nugget package used is from <see cref="https://github.com/khalidabuhakmeh/ConsoleTables"/>
    /// </summary>
    public class PrintHelper : IPrintHelper
    {
        public void PrintToConsole(StationReadingResult stationReading)
        {
            var table = new ConsoleTable("Station Name", stationReading.StationName);
            table.AddRow("Min Reading was : ", stationReading.MinValue + " on " + (stationReading.DateMinValue?.ToString(Constants.UkDateTimeFormat) ?? " Date Unavailable") + " " + stationReading.UnitName)
                .AddRow("Max Reading was : ", stationReading.MaxValue + " on " + (stationReading.DateMaxValue?.ToString(Constants.UkDateTimeFormat) ?? " Date Unavailable") + " " + stationReading.UnitName)
                .AddRow("Avg Reading is : ", (stationReading.AvgValue.HasValue ? Math.Round(stationReading.AvgValue.Value, 3) : double.NaN) + " " + stationReading.UnitName);
            table.Write(Format.Minimal);
            Console.WriteLine(Environment.NewLine);
        }

        public void Print(string message, bool newLineAfter)
        {
            Console.WriteLine(message);

            if (newLineAfter)
            {
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
