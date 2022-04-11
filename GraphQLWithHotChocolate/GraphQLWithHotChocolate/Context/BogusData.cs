using Bogus;
using GraphQLWithHotChocolate.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLWithHotChocolate.Context;

public static class BogusData
{
    public static async Task SeedData(BookContext context)
    {
        if (context.Authors != null && !context.Authors.Any())
        {
            await context.Authors.AddRangeAsync(CreateData());
            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<Author> CreateData()
    {
        var authors = new Faker<Author>()
            .RuleFor(o => o.FirstName, f => f.Name.FirstName())
            .RuleFor(o => o.LastName, f => f.Name.LastName())
            .RuleFor(o => o.Books, f =>
            {
                var books = new Faker<Book>()
                    .RuleFor(b => b.Rating, fa => fa.Random.Number(1, 5))
                    .RuleFor(b => b.Summary, fa => fa.Lorem.Sentence())
                    .RuleFor(b => b.Genre, fa => fa.PickRandom<Genre>())
                    .RuleFor(b => b.Title, fa => fa.Company.CompanyName())
                    .Generate(f.Random.Number(1, 10));

                return books;
            });

        return authors.Generate(10);
    }
}