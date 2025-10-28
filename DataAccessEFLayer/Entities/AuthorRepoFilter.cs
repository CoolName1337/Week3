
namespace DataAccessEFLayer.Entities
{
    public class AuthorRepoFilter
    {
        public int? BookId { get; set; }
        public string? AuthorName { get; set; }
        public string? BookTitle { get; set; }
        public DateOnly? BirthAfter { get; set; }
    }
}
