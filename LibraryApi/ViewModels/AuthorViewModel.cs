using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}
