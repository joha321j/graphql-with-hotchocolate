using GraphQLWithHotChocolate.Context;
using GraphQLWithHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithHotChocolate.GraphQLQueries;

public class Query
{
    private readonly BookContext _context;

    public Query(BookContext context)
    {
        _context = context;
    }

    public List<Book>? GetBooks()
    {
        var books = _context.Books?.Include(b => b.Author).AsNoTracking();
        return books?.ToList();

    }

    public List<Author>? GetAuthors()
    {
        var authors = _context.Authors?.Include(a => a.Books).AsNoTracking();

        return authors?.ToList();
    }
}