namespace EnvironmentData.Models
{
    using Newtonsoft.Json;

    public class Station
    {
        [JsonConstructor]
        public Station()
        {
        }

        public Station(string label, string wiskiId, string notation, string riverName)
        {
            this.Label = label;
            this.WiskiId = wiskiId;
            this.Notation = notation;
            this.RiverName = riverName;
        }

        public string Label { get; set; }

        public string WiskiId { get; set; }

        public string Notation { get; set; }

        public string RiverName { get; set; }
    }
}
