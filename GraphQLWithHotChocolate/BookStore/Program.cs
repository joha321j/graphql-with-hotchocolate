using BookStore.Context;
using BookStore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var authors = BogusData.CreateData();
var books = new List<Book>();
authors.ForEach(a => books.AddRange(a.Books));

app.MapGet("/authors", () => authors);
app.MapGet("/books", () => books);

app.Run();