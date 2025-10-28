using DataAccessEFLayer.Entities;

namespace BusinessLayer.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}
