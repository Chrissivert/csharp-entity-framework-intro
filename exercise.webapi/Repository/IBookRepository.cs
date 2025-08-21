using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();
        public Task<Book> UpdateBook(Book book);
        public Task<bool> DeleteBook(int bookId);
        public Task<Book> CreateBook(Book book);
    }
}
