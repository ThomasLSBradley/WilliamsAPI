namespace WilliamsAPI.Models.JsonSourceModels
{
    public class DriverSource
    {
        public required int driverId { get; set; }
        public required string driverRef { get; set; }
        public required string? number { get; set; }
        public required string? code { get; set; }
        public required string forename { get; set; }
        public required string surname { get; set; }
        public required DateOnly dob { get; set; }
        public required string nationality { get; set; }
        public required string url { get; set; }
    }
}
