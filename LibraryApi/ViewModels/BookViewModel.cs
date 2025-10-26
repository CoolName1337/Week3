using System.ComponentModel.DataAnnotations;

namespace LibraryApi.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
