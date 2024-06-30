namespace WilliamsAPI.Models.JsonSourceModels
{
    public class DriverStandingSource
    {
        public required int driverStandingsId { get; set; }
        public required int raceId { get; set; }
        public required int driverId { get; set; }
        public required float? points { get; set; }
        public required int position { get; set; }
        public required int? positionText { get; set; }
        public required int wins { get; set; }
    }
}
