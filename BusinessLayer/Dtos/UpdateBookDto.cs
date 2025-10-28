using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The publication year is required")]
        public int PublishedYear { get; set; }
        public int? AuthorId { get; set; }
    }
}
