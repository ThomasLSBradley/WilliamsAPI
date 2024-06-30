namespace WilliamsAPI.Models.JsonSourceModels
{
    public class RaceSource
    {
        public required int raceId { get; set; }
        public required int year { get; set; }
        public required int round { get; set; }
        public required int circuitId { get; set; }
        public required string name { get; set; }
        public required DateOnly date { get; set; }
        public required TimeOnly? time { get; set; }
        public required string url { get; set; }
        public required DateOnly? fp1_date { get; set; }
        public required TimeOnly? fp1_time { get; set; }
        public required DateOnly? fp2_date { get; set; }
        public required TimeOnly? fp2_time { get; set; }
        public required DateOnly? fp3_date { get; set; }
        public required TimeOnly? fp3_time { get; set; }
        public required DateOnly? quali_date { get; set; }
        public required TimeOnly? quali_time { get; set; }
        public required DateOnly? sprint_date { get; set; }
        public required TimeOnly? sprint_time { get; set; }
    }
}
