namespace GraphQLWithHotChocolate.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    public string Summary { get; set; }

    public int Rating { get; set; }

    public Genre Genre { get; set; }

    public Author Author { get; set; }
}