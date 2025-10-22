using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Dtos
{
    public class AuthorDto
    {
        [Required(ErrorMessage = "The author's name is required")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The date of birth is required")]
        public DateTime DateOfBirth { get; set; }
    }
}
