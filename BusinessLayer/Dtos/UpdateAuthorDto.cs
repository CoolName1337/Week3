using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "The author's name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The date of birth is required")]
        public DateOnly DateOfBirth { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}
