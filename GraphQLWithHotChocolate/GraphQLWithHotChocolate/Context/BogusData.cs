using Bogus;
using GraphQLWithHotChocolate.Models;

namespace GraphQLWithHotChocolate.Context;

public static class BogusData
{
    public static List<Author> CreateData()
    {
        var authors = CreateAuthors();

        return authors.Generate(10);
    }

    private static Faker<Author> CreateAuthors()
    {
        var authors = new Faker<Author>()
            .RuleFor(o => o.Id, f => ++f.IndexVariable)
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.Books, CreateBooks);
        return authors;
    }

    private static List<Book> CreateBooks(Faker f)
    {
        var books = new Faker<Book>()
            .RuleFor(o => o.Id, fa => ++fa.IndexVariable)
            .RuleFor(b => b.Rating, fa => fa.Random.Number(1, 5))
            .RuleFor(b => b.Summary, fa => fa.Lorem.Sentence())
            .RuleFor(b => b.Genre, fa => fa.PickRandom<Genre>())
            .RuleFor(b => b.Title, fa => fa.Company.CompanyName())
            .Generate(f.Random.Number(1, 10));

        return books;
    }
}