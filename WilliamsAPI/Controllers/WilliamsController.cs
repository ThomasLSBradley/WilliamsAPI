using Microsoft.AspNetCore.Mvc;
using WilliamsAPI.Core;
using WilliamsAPI.DAL;
using WilliamsAPI.Models;
using WilliamsAPI.Models.PostModels;
using WilliamsAPI.Utils;

namespace WilliamsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WilliamsController : ControllerBase
    {
        private DataQueryManager dataQueryManager;
        public WilliamsController(DataQueryManager dataQueryManager)
        {
            this.dataQueryManager = dataQueryManager;
        }

        [HttpPost("circuit")]
        public IEnumerable<Circuit> GetCircuits([FromBody] DataQuery query)
        {
            return dataQueryManager.GetDataQueryResult<Circuit>(query);
        }

        [HttpPost("driver")]
        public IEnumerable<Driver> GetDrivers([FromBody] DataQuery query)
        {
            return dataQueryManager.GetDataQueryResult<Driver>(query);
        }

        [HttpPost("driverStanding")]
        public IEnumerable<DriverStanding> GetDriverStandings([FromBody] DataQuery query)
        {
            return dataQueryManager.GetDataQueryResult<DriverStanding>(query);
        }

        [HttpPost("lapTime")]
        public IEnumerable<LapTime> GetLapTimes([FromBody] DataQuery query)
        {
            return dataQueryManager.GetDataQueryResult<LapTime>(query);
        }

        [HttpPost("race")]
        public IEnumerable<Race> GetRaces([FromBody] DataQuery query)
        {
            return dataQueryManager.GetDataQueryResult<Race>(query);
        }
    }
}
