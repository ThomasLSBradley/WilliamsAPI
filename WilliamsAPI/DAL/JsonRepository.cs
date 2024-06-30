using WilliamsAPI.Models;
using WilliamsAPI.Models.JsonSourceModels;
using WilliamsAPI.Utils;

namespace WilliamsAPI.DAL
{
    public class JsonRepository : IRepository
    {
        public Dictionary<int, Circuit> CircuitsById { get; set; } = [];
        public Dictionary<int, Driver> DriversById { get; set; } = [];
        public Dictionary<int, DriverStanding> DriverStandingsById { get; set; } = [];
        public IEnumerable<LapTime> LapTimes { get; set; } = [];
        public Dictionary<int, Race> RacesById { get; set; } = [];

        public void InitCache()
        {
            Task.WaitAll(
                Task.Run(async () =>
                {
                    CircuitsById = (await DataSourceReader.ReadJsonAsync<IEnumerable<CircuitSource>>("circuits"))
                        .ToDictionary(c => c.circuitId, c => c.ToCircuit());
                }),
                Task.Run(async () =>
                {
                    DriversById = (await DataSourceReader.ReadJsonAsync<IEnumerable<DriverSource>>("drivers"))
                        .ToDictionary(d => d.driverId, d => d.ToDriver());
                }));

            Task.WaitAll(
                Task.Run(async () =>
                {
                    RacesById = (await DataSourceReader.ReadJsonAsync<IEnumerable<RaceSource>>("races"))
                        .ToDictionary(r => r.raceId, r => r.ToRace(
                            CircuitsById.GetValueOrDefault(r.circuitId)));
                }));

            Task.WaitAll(
                Task.Run(async () =>
                {
                    DriverStandingsById = (await DataSourceReader.ReadJsonAsync<IEnumerable<DriverStandingSource>>("driver_standings"))
                        .ToDictionary(ds => ds.driverStandingsId, ds => ds.ToDriverStanding(
                            RacesById.GetValueOrDefault(ds.raceId), 
                            DriversById.GetValueOrDefault(ds.driverId)));
                }),
                Task.Run(async () =>
                {
                    LapTimes = (await DataSourceReader.ReadJsonAsync<IEnumerable<LapTimeSource>>("lap_times"))
                        .Select(lt => lt.ToLapTime(
                            RacesById.GetValueOrDefault(lt.raceId),
                            DriversById.GetValueOrDefault(lt.driverId)));
                }));
        }
    }
}
