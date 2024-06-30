using WilliamsAPI.Models;
using WilliamsAPI.Models.JsonSourceModels;

namespace WilliamsAPI.Utils
{
    public static class JsonSourceExtensions
    {
        public static Circuit ToCircuit(this CircuitSource source)
        {
            return new()
            {
                Name = source.name,
                Location = source.location,
                Country = source.country,
                Latitude = source.lat,
                Longitude = source.lng,
                Altitude = source.alt,
                Url = source.url,
            };
        }

        public static Driver ToDriver(this DriverSource source)
        {
            return new()
            {
                Number = source.number,
                Forename = source.forename,
                Surname = source.surname,
                Dob = source.dob,
                Nationality = source.nationality,
                Url = source.url,
            };
        }

        public static DriverStanding ToDriverStanding(this DriverStandingSource source, Race? race, Driver? driver)
        {
            return new()
            {
                Race = race,
                Driver = driver,
                Points = source.points,
                Position = source.position,
                Wins = source.wins,
            };
        }

        public static LapTime ToLapTime(this LapTimeSource source, Race? race, Driver? driver)
        {
            return new()
            {
                Race = race,
                Driver = driver,
                Lap = source.lap,
                Position = source.position,
                Milliseconds = source.milliseconds,
            };
        }

        public static Race ToRace(this RaceSource source, Circuit? circuit)
        {
            return new()
            {
                Year = source.year,
                Round = source.round,
                Circuit = circuit,
                Name = source.name,
                RaceDateTime = source.date.ToDateTime(source.time ?? TimeOnly.MinValue),
                Url = source.url,
                Fp1DateTime = source.fp1_date != null 
                    ? ((DateOnly)source.fp1_date).ToDateTime(source.fp1_time ?? TimeOnly.MinValue) 
                    : null,
                Fp2DateTime = source.fp2_date != null
                    ? ((DateOnly)source.fp2_date).ToDateTime(source.fp2_time ?? TimeOnly.MinValue)
                    : null,
                Fp3DateTime = source.fp3_date != null
                    ? ((DateOnly)source.fp3_date).ToDateTime(source.fp3_time ?? TimeOnly.MinValue)
                    : null,
                QualiDateTime = source.quali_date != null
                    ? ((DateOnly)source.quali_date).ToDateTime(source.quali_time ?? TimeOnly.MinValue)
                    : null,
                SprintDateTime = source.sprint_date != null
                    ? ((DateOnly)source.sprint_date).ToDateTime(source.sprint_time ?? TimeOnly.MinValue)
                    : null,
            };
        }
    }
}
