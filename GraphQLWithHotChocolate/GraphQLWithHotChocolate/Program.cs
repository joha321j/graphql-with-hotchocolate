using GraphQLWithHotChocolate.Context;
using GraphQLWithHotChocolate.GraphQLQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddGraphQLServer()
    .AddType<GenreType>()
    .AddQueryType<Query>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapGraphQL();


app.Run();