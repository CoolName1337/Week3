using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos
{
    public class BookDto
    {
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The publication year is required")]
        public int PublishedYear { get; set; }
        [Required(ErrorMessage = "The author's id is required")]
        public int AuthorId { get; set; }
    }
}
