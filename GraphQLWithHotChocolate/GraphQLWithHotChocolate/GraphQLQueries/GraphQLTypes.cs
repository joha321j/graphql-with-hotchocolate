using GraphQLWithHotChocolate.Models;

namespace GraphQLWithHotChocolate.GraphQLQueries;

public class BookType : ObjectType<Book>
{
}

public class AuthorType : ObjectType<Author>
{
}

public class GenreType : EnumType<Genre>
{
}