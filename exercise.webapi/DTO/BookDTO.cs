using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.webapi.Models
{

    // DTO of book, meaning it represents what data to send
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        // No cycle created due to BookDTO not calling AuthorDTO
    }
    
}
