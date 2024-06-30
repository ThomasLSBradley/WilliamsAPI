using WilliamsAPI.DAL;
using WilliamsAPI.Models;
using WilliamsAPI.Models.PostModels;

namespace WilliamsAPI.Core
{
    public class DataQueryManager
    {
        private IRepository repository;
        public DataQueryManager(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<T> GetDataQueryResult<T>(DataQuery query)
        {
            var items = GetItems<T>();

            return items.Where(query.WhereClause).GroupBy(query.GroupByClause);
        }

        public IEnumerable<T> GetItems<T>()
        {
            if (typeof(T).IsAssignableFrom(typeof(Circuit)))
            {
                return repository.CircuitsById.Values.Cast<T>();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Driver)))
            {
                return repository.DriversById.Values.Cast<T>();
            }
            else if (typeof(T).IsAssignableFrom(typeof(DriverStanding)))
            {
                return repository.DriverStandingsById.Values.Cast<T>();
            }
            else if (typeof(T).IsAssignableFrom(typeof(LapTime)))
            {
                return repository.LapTimes.Cast<T>();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Race)))
            {
                return repository.RacesById.Values.Cast<T>();
            }

            return [];
        }
    }
}
