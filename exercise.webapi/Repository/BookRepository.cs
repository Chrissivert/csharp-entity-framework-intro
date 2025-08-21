using exercise.webapi.Data;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise.webapi.Repository
{
    public class BookRepository: IBookRepository
    {
        DataContext _db;
        
        public BookRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<Book> CreateBook(Book book)
        {
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var book = await _db.Books.FindAsync(bookId);
            if (book == null) return false;

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _db.Books.Include(b => b.Author).ToListAsync();

        }

        public async Task<Book> UpdateBook(Book book)
        {
            _db.Books.Update(book);
            await _db.SaveChangesAsync();
            return book;
        }
    }
}
