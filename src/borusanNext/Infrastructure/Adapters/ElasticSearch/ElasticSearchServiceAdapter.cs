using Application.Services.ElasticSearch;
using Common.Persistance.Elastic.Queries;
using Elasticsearch.Net;
using NArchitecture.Core.ElasticSearch.Constants;
using NArchitecture.Core.ElasticSearch.Models;
using Nest;
using Nest.JsonNetSerializer;
using Newtonsoft.Json;

namespace Infrastructure.Adapters.Elastic;

public class ElasticSearchServiceAdapter : IElasticSearch
{
    private readonly ConnectionSettings _connectionSettings;

    public ElasticSearchServiceAdapter(ElasticSearchConfig configuration)
    {
        try
        {
            SingleNodeConnectionPool pool = new(new Uri(configuration.ConnectionString));
            _connectionSettings = new ConnectionSettings(
                pool,
                sourceSerializer: (builtInSerializer, connectionSettings) =>
                    new JsonNetSerializer(
                        builtInSerializer,
                        connectionSettings,
                        jsonSerializerSettingsFactory: () =>
                            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
                    )
            )
            .BasicAuthentication(configuration.UserName, configuration.Password)
            .DisableDirectStreaming(true)
            .EnableApiVersioningHeader()
            .OnRequestCompleted(response =>
            {
                Console.WriteLine($"Request to {response.Uri} took {response.TcpStats}");
                if (!response.Success)
                {
                    Console.WriteLine($"Error: {response.HttpStatusCode}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error initializing ElasticClient: {ex.Message}");
            throw;
        }
    }

    public IReadOnlyDictionary<IndexName, IndexState> GetIndexList()
    {
        ElasticClient elasticClient = new(_connectionSettings);
        return elasticClient.Indices.Get(new GetIndexRequest(Indices.All)).Indices;
    }

    public async Task<IElasticSearchResult> InsertManyAsync(string indexName, object[] items)
    {
        ElasticClient elasticClient = getElasticClient(indexName);
        await elasticClient.BulkAsync(a => a.Index(indexName).IndexMany(items));

        return new ElasticSearchResult();
    }

    public async Task<IElasticSearchResult> CreateNewIndexAsync(IndexModel indexModel)
    {
        ElasticClient elasticClient = getElasticClient(indexModel.IndexName);
        if (elasticClient.Indices.Exists(indexModel.IndexName).Exists)
            return new ElasticSearchResult(success: false, message: ElasticSearchMessages.IndexAlreadyExists);

        CreateIndexResponse? response = await elasticClient.Indices.CreateAsync(
            indexModel.IndexName,
            selector: se =>
                se.Settings(a => a.NumberOfReplicas(indexModel.NumberOfReplicas).NumberOfShards(indexModel.NumberOfShards))
                    .Aliases(x => x.Alias(indexModel.AliasName))
        );

        return new ElasticSearchResult(
            response.IsValid,
            message: response.IsValid ? ElasticSearchMessages.Success : response.ServerError.Error.Reason
        );
    }

    public async Task<IElasticSearchResult> DeleteByElasticIdAsync(ElasticSearchModel model)
    {
        ElasticClient elasticClient = getElasticClient(model.IndexName);
        DeleteResponse? response = await elasticClient.DeleteAsync<object>(
            model.ElasticId,
            selector: x => x.Index(model.IndexName)
        );
        return new ElasticSearchResult(
            response.IsValid,
            message: response.IsValid ? ElasticSearchMessages.Success : response.ServerError.Error.Reason
        );
    }

    public async Task<List<ElasticSearchGetModel<T>>> GetAllSearch<T>(SearchParameters parameters)
        where T : class
    {
        ElasticClient elasticClient = getElasticClient(parameters.IndexName);
        ISearchResponse<T>? searchResponse = await elasticClient.SearchAsync<T>(s =>
            s.Index(Indices.Index(parameters.IndexName)).From(parameters.From).Size(parameters.Size)
        );

        var list = searchResponse.Hits.Select(x => new ElasticSearchGetModel<T> { ElasticId = x.Id, Item = x.Source }).ToList();

        return list;
    }

    public async Task<List<ElasticSearchGetModel<T>>> GetSearchByField<T>(SearchByFieldParameters fieldParameters)
        where T : class
    {
        ElasticClient elasticClient = getElasticClient(fieldParameters.IndexName);
        ISearchResponse<T>? searchResponse = await elasticClient.SearchAsync<T>(s =>
            s.Index(fieldParameters.IndexName).From(fieldParameters.From).Size(fieldParameters.Size)
        );

        var list = searchResponse.Hits.Select(x => new ElasticSearchGetModel<T> { ElasticId = x.Id, Item = x.Source }).ToList();
        return list;
    }

    public async Task<List<ElasticSearchGetModel<T>>> GetSearchBySimpleQueryString<T>(Common.Persistance.Elastic.Models.SearchByQueryParameters queryParameters)
     where T : class
    {
        ElasticClient elasticClient = getElasticClient(queryParameters.IndexName);

        if (elasticClient == null)
        {
            throw new InvalidOperationException("Failed to initialize the Elastic client.");
        }

        var dynamicQuery = new List<QueryContainer>();

        if (queryParameters.Queries?.Any() == true)
        {
            foreach (var item in queryParameters.Queries)
            {
                dynamicQuery.Add(Query<T>.Match(m => m.Field(new Field(item.Field)).Query(item.Value)));
            }
        }

        if (queryParameters.Filters?.Any() == true)
        {
            foreach (var filter in queryParameters.Filters)
            {
                switch (filter.Type)
                {
                    case FilterType.Term:
                        dynamicQuery.Add(new TermQuery
                        {
                            Field = $"{filter.Field}.enum",
                            Value = filter.Value
                        });
                        break;

                    case FilterType.DateRange:
                        dynamicQuery.Add(Query<T>.DateRange(dr => dr
                            .Field(filter.Field)
                            .GreaterThanOrEquals(DateTime.Now.AddDays(-Convert.ToInt64(filter.From!.ToString()!)))));
                        break;

                    case FilterType.Range:
                        if (filter.From != null && filter.To != null)
                        {
                            dynamicQuery.Add(Query<T>.Range(r => r
                                .Field(filter.Field)
                                .GreaterThanOrEquals(Convert.ToDouble(filter.From.ToString()))
                                .LessThanOrEquals(Convert.ToDouble(filter.To.ToString()))));
                        }
                        else if (filter.From != null)
                        {
                            dynamicQuery.Add(Query<T>.Range(r => r
                                .Field(filter.Field)
                                .GreaterThanOrEquals(Convert.ToDouble(filter.From.ToString()))));
                        }
                        else if (filter.To != null)
                        {
                            dynamicQuery.Add(Query<T>.Range(r => r
                                .Field(filter.Field)
                                .LessThanOrEquals(Convert.ToDouble(filter.To.ToString()))));
                        }
                        break;

                    default:
                        dynamicQuery.Add(Query<T>.Term(filter.Field, filter.Value));
                        break;
                }
            }
        }

        var searchResponse = await elasticClient.SearchAsync<T>(s => s
            .Index(queryParameters.IndexName)
            .From(queryParameters.From)
            .Size(queryParameters.Size)
            .Sort(sort => sort
                .Field(field => field.Field(queryParameters.Order.Field)
                    .Order(queryParameters.Order.Type == "asc" ? SortOrder.Ascending : SortOrder.Descending)))
            .Query(q => q.Bool(b => b.Must(dynamicQuery.ToArray()))));

        if (searchResponse == null || !searchResponse.IsValid)
        {
            var errorMessage = searchResponse?.ServerError?.ToString() ?? "Unknown error";
            var statusCode = searchResponse?.ApiCall?.HttpStatusCode;
            var debugInformation = searchResponse?.DebugInformation;

            throw new InvalidOperationException($"Search query failed. Status Code: {statusCode}. Error: {errorMessage}. Debug Info: {debugInformation}");
        }

        return searchResponse.Hits.Select(hit => new ElasticSearchGetModel<T>
        {
            ElasticId = hit.Id,
            Item = hit.Source
        }).ToList();
    }


    public async Task<IElasticSearchResult> InsertAsync(ElasticSearchInsertUpdateModel model)
    {
        ElasticClient elasticClient = getElasticClient(model.IndexName);

        IndexResponse? response = await elasticClient.IndexAsync(
            model.Item,
            selector: i => i.Index(model.IndexName).Id(model.ElasticId).Refresh(Refresh.True)
        );

        return new ElasticSearchResult(
            response.IsValid,
            message: response.IsValid ? ElasticSearchMessages.Success : response.ServerError.Error.Reason
        );
    }

    public async Task<IElasticSearchResult> UpdateByElasticIdAsync(ElasticSearchInsertUpdateModel model)
    {
        ElasticClient elasticClient = getElasticClient(model.IndexName);
        UpdateResponse<object>? response = await elasticClient.UpdateAsync<object>(
            model.ElasticId,
            selector: u => u.Index(model.IndexName).Doc(model.Item)
        );
        return new ElasticSearchResult(
            response.IsValid,
            message: response.IsValid ? ElasticSearchMessages.Success : response.ServerError.Error.Reason
        );
    }

    private ElasticClient getElasticClient(string indexName)
    {
        if (string.IsNullOrEmpty(indexName))
            throw new ArgumentNullException(indexName, message: ElasticSearchMessages.IndexNameCannotBeNullOrEmpty);

        return new ElasticClient(_connectionSettings);
    }
}