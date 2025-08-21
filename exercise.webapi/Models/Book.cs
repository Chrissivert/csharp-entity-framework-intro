using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.webapi.Models
{

    // Model of book, meaning it represents the attributes and relations
    // in the database, NOT what is sent
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
