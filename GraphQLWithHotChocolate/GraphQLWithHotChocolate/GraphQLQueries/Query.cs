using GraphQLWithHotChocolate.Context;
using GraphQLWithHotChocolate.Models;

namespace GraphQLWithHotChocolate.GraphQLQueries;

public class Query
{
    private readonly List<Author> _authors;
    private readonly List<Book> _books;

    public Query()
    {
        _authors = BogusData.CreateData();
        _books = new List<Book>();

        _authors.ForEach(a => _books.AddRange(a.Books));
    }

    public List<Book> GetBooks()
    {
        return _books;
    }

    public List<Author> GetAuthors()
    {
        return _authors;
    }
}