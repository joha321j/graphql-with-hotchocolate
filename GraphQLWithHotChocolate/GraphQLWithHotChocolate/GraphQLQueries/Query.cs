using BookStore.Models;

namespace GraphQLWithHotChocolate.GraphQLQueries;

public class Query
{
    private readonly IHttpClientFactory _httpClientFactory;

    public Query(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<List<Book>?> GetObjects(string endpoint = "/books")
    {
        var client = _httpClientFactory.CreateClient("BookStore");

        return await client.GetFromJsonAsync<List<Book>>(endpoint);
    }
}