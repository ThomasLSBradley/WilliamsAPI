namespace WilliamsAPI.Models.JsonSourceModels
{
    public class CircuitSource
    {
        public required int circuitId { get; set; }
        public required string circuitRef { get; set; }
        public required string name { get; set; }
        public required string location { get; set; }
        public required string country { get; set; }
        public required float lat { get; set; }
        public required float lng { get; set; }
        public required int alt { get; set; }
        public required string url { get; set; }
    }
}
