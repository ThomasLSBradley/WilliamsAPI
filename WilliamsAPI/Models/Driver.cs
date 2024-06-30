using System.Text.Json.Serialization;

namespace WilliamsAPI.Models
{
    public class Driver
    {
        public string? Number { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateOnly Dob { get; set; }
        public string Nationality { get; set; }
        public string Url { get; set; }
}
}
