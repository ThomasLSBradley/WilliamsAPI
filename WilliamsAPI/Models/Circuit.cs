using System.Text.Json.Serialization;

namespace WilliamsAPI.Models
{
    public class Circuit
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Altitude { get; set; }
        public string Url { get; set; }
    }
}
