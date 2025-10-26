namespace DataAccessLayer.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}
