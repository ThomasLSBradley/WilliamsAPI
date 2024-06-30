using WilliamsAPI.Core;
using WilliamsAPI.Models.PostModels;

namespace WilliamsAPI.Core
{
    public static class DataQueryItemsExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> items, WhereClause? clause)
        {
            if (clause == null)
            {
                return items;
            }

            var property = typeof(T).GetProperty(clause.Field);
            var value = Convert.ChangeType(clause.Value, property!.PropertyType);

            // If not numeric with a numeric operation
            if (!decimal.TryParse(clause.Value, out var numericValue)
                && clause.Operator is not ComparisonOperator.EqualTo or ComparisonOperator.NotEqualTo)
            {
                return items;
            }

            return clause.Operator switch
            {
                ComparisonOperator.EqualTo => items.Where(i => property.GetValue(i)?.Equals(value) ?? false),
                ComparisonOperator.GreaterThan => items.Where(i => Convert.ToDecimal(property.GetValue(i)) > numericValue),
                ComparisonOperator.GreaterThanOrEqual => items.Where(i => Convert.ToDecimal(property.GetValue(i)) >= numericValue),
                ComparisonOperator.LessThan => items.Where(i => Convert.ToDecimal(property.GetValue(i)) < numericValue),
                ComparisonOperator.LessThanOrEqual => items.Where(i => Convert.ToDecimal(property.GetValue(i)) <= numericValue),
                ComparisonOperator.NotEqualTo => items.Where(i => !property.GetValue(i)?.Equals(value) ?? true),
                _ => items,
            };
        }

        public static IEnumerable<T> GroupBy<T>(this IEnumerable<T> items, GroupByClause? clause)
        {
            if (clause == null)
            {
                return items;
            }

            var keyProperty = typeof(T).GetProperty(clause.Field);
            var properties = typeof(T).GetProperties();

            var groups = new Dictionary<object, object>();

            foreach (var item in items)
            {
                var propertyValue = keyProperty?.GetValue(item);

                if (propertyValue == null) continue;

                if (!groups.TryGetValue(propertyValue!, out var value))
                {
                    groups.Add(propertyValue!, item!);
                }
                else
                {
                    foreach (var property in properties)
                    {
                        var currentValue = property.GetValue(value);
                        var incomingValue = property.GetValue(item);

                        if (decimal.TryParse(currentValue!.ToString(), out var numericValue))
                        {
                            var incomingNumericValue = decimal.Parse(incomingValue!.ToString()!);
                            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                            switch (clause.AggregationMethod)
                            {
                                case AggregationMethod.Sum:
                                    property.SetValue(value, Convert.ChangeType(numericValue + incomingNumericValue, type));
                                    break;
                                case AggregationMethod.Min:
                                    property.SetValue(value, Convert.ChangeType(numericValue <= incomingNumericValue ? numericValue : incomingNumericValue, type));
                                    break;
                                case AggregationMethod.Max:
                                    property.SetValue(value, Convert.ChangeType(numericValue >= incomingNumericValue ? numericValue : incomingNumericValue, type));
                                    break;
                            }
                        }
                    }
                }
            }

            return groups.Values.Cast<T>();
        }
    }
}
