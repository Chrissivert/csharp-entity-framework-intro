using exercise.webapi.Models;
using exercise.webapi.Repository;

namespace exercise.webapi.Endpoints
{
    public static class BookApi
    {
        public static void ConfigureBooksApi(this WebApplication app)
        {
            app.MapGet("/books", GetBooks);
            app.MapPost("/books", CreateBook);
            app.MapPut("/books/{id}", UpdateBook);
            app.MapDelete("/books/{id}", DeleteBook);
        }

        private static async Task<IResult> GetBooks(IBookRepository repo)
        {
            var books = await repo.GetAllBooks();
            var bookDTOs = books.Select(b => new BookDTO
        {
            Id = b.Id,
            Title = b.Title,
            AuthorId = b.AuthorId,
            AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
        });
            return TypedResults.Ok(bookDTOs);
        }

        private static async Task<IResult> CreateBook(Book book, IBookRepository repo)
        {
            var created = await repo.CreateBook(book);
            return TypedResults.Created($"/books/{created.Id}", created);
        }

        private static async Task<IResult> UpdateBook(int id, Book book, IBookRepository repo)
        {
            book.Id = id;
            var updated = await repo.UpdateBook(book);
            return TypedResults.Ok(updated);
        }

        private static async Task<IResult> DeleteBook(int id, IBookRepository repo)
        {
            var deleted = await repo.DeleteBook(id);
            return deleted ? TypedResults.Ok() : TypedResults.NotFound();
        }

    }
}
