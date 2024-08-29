using Common.Persistance.Elastic.Queries;
namespace Common.Persistance.Elastic.Models;
public class SearchByQueryParameters
{
    public string IndexName { get; set; }
    public int From { get; set; }
    public int Size { get; set; }
    public Order Order { get; set; } // asc, desc
    public IEnumerable<DynamicFilter>? Filters { get; set; }

    public SearchByQueryParameters()
    {
        IndexName = string.Empty;
        Order = new() { Field = string.Empty, Type = "asc" };
        Filters = Array.Empty<DynamicFilter>();
    }

    public SearchByQueryParameters(string indexName, int from, int size, IEnumerable<DynamicFilter> filters)
    {
        IndexName = indexName;
        From = from;
        Size = size;
        Filters = filters;
    }
}
