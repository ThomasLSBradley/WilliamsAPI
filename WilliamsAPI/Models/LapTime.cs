using System.Text.Json.Serialization;

namespace WilliamsAPI.Models
{
    public class LapTime
    {
        public Race? Race { get; set; }
        public Driver? Driver { get; set; }
        public int Lap { get; set; }
        public int Position { get; set; }
        public double Milliseconds { get; set; }
}
}
