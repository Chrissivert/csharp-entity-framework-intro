// using exercise.webapi.Models;
// using exercise.webapi.Repository;

// public static class AuthorApi
// {
//     public static async Task<IResult> GetAuthorById(IAuthorRepository repo, int id)
//     {
//         var author = await repo.GetAuthorById(id);
//         if (author == null) return TypedResults.NotFound();

//         var authorDTO = new AuthorDTO
//         {
//             Id = author.Id,
//             FirstName = author.FirstName,
//             LastName = author.LastName,
//             Books = author.Books.Select(b => new BookDTO
//             {
//                 Id = b.Id,
//                 Title = b.Title,
//                 AuthorId = author.Id,
//                 AuthorName = $"{author.FirstName} {author.LastName}"
//             }).ToList()
//         };

//         return TypedResults.Ok(authorDTO);
//     }
// }
