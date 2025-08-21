using exercise.webapi.Data;
using exercise.webapi.Endpoints;
using exercise.webapi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL instead of InMemoryDatabase
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build(); // Build app first

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (!context.Authors.Any())
    {
        Seeder seeder = new Seeder();
        context.Authors.AddRange(seeder.Authors);
        context.Books.AddRange(seeder.Books);
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureBooksApi();
app.Run();
