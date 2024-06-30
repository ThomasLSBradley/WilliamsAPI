using WilliamsAPI.Models;

namespace WilliamsAPI.DAL
{
    public interface IRepository
    {
        public Dictionary<int, Circuit> CircuitsById { get; set; }
        public Dictionary<int, Driver> DriversById { get; set; }
        public Dictionary<int, DriverStanding> DriverStandingsById { get; set; }
        public IEnumerable<LapTime> LapTimes { get; set; }
        public Dictionary<int, Race> RacesById { get; set; }

        public void InitCache();
    }
}
