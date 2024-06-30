namespace WilliamsAPI.Models.PostModels
{
    public class DataQuery
    {
        public required WhereClause? WhereClause { get; set; }
        public required GroupByClause? GroupByClause { get; set; }
    }

    public class WhereClause
    {
        public required string Field { get; set; }
        public required ComparisonOperator Operator { get; set; }
        public required string Value { get; set; }
    }

    public class GroupByClause
    {
        public required string Field { get; set; }
        public required AggregationMethod AggregationMethod { get; set; }
        public required Dictionary<string, AggregationMethod>? Overloads { get; set; } = [];
    }

    public enum ComparisonOperator
    {
        EqualTo,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        NotEqualTo,
    }

    public enum AggregationMethod
    {
        Sum,
        Min,
        Max,
    }
}
