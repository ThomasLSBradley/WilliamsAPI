using System.Text.Json.Serialization;

namespace WilliamsAPI.Models
{
    public class DriverStanding
    {
        public Race? Race { get; set; }
        public Driver? Driver { get; set; }
        public float? Points { get; set; }
        public int Position { get; set; }
        public int Wins { get; set; }
}
}
