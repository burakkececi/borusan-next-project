namespace Common.Persistance.Elastic.Queries;
public class ElasticQuery
{
    public int From { get; set; }
    public int Size { get; set; }
    public Order Order { get; set; }
    public IEnumerable<DynamicFilter>? Filters { get; set; }
}
public class DynamicFilter
{
    public FilterType Type { get; set; }
    public string? Field { get; set; }
    public string? Value { get; set; }
    public object? From { get; set; }
    public object? To { get; set; }
}

public class Order
{
    public string Field { get; set; }
    public string Type { get; set; } // asc, desc
}

public enum FilterType
{
    Term,
    DateRange,
    Range
}
