using GraphQLWithHotChocolate.Context;
using GraphQLWithHotChocolate.GraphQLQueries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddGraphQLServer()
    .AddType<GenreType>()
    .AddQueryType<Query>();

builder.Services.AddDbContext<BookContext>(context =>
{
    context.UseSqlite("Data Source=BookServer");
});

var app = builder.Build();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<BookContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
await BogusData.SeedData(context);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapGraphQL();


app.Run();