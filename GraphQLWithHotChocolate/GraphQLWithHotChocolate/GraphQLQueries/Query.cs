using GraphQLWithHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithHotChocolate.GraphQLQueries;

public class Query
{
    private readonly DbContext _context;

    public Query(DbContext context)
    {
        _context = context;
    }

    public List<Book> GetBooks()
    {
        return new List<Book>
        {
            new()
            {
                Title = "C# in depth",
                Rating = 5,
                Summary = "Good book, bro.",
                Genre = Genre.Fantasy
            }
        };
    }

    public List<Author> GetAuthors()
    {
        return new List<Author>();
    }
}