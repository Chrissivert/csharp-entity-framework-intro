using System.Text.Json.Serialization;

namespace exercise.webapi.Models
{

    // Model of author, meaning it represents the attributes and relations
    // in the database, NOT what is sent
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        // public List<BookDTO> Books { get; set; }
    }
}
