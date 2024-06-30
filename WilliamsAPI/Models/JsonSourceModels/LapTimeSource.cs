namespace WilliamsAPI.Models.JsonSourceModels
{
    public class LapTimeSource
    {
        public required int raceId { get; set; }
        public required int driverId { get; set; }
        public required int lap { get; set; }
        public required int position { get; set; }
        public required string time { get; set; }
        public required double milliseconds { get; set; }
    }
}
