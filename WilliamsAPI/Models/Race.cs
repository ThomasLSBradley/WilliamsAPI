using System.Text.Json.Serialization;

namespace WilliamsAPI.Models
{
    public class Race
    {
        public int Year { get; set; }
        public int Round { get; set; }
        public Circuit? Circuit { get; set; }
        public string Name { get; set; }
        public DateTime RaceDateTime { get; set; }
        public string Url { get; set; }
        public DateTime? Fp1DateTime { get; set; }
        public DateTime? Fp2DateTime { get; set; }
        public DateTime? Fp3DateTime { get; set; }
        public DateTime? QualiDateTime { get; set; }
        public DateTime? SprintDateTime { get; set; }
    }
}
