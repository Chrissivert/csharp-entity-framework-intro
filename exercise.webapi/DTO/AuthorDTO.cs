using System.Text.Json.Serialization;

namespace exercise.webapi.Models
{

    // DTO of author, meaning it represents what data to send
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
