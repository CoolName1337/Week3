using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class CreateAuthorDto
    {
        [Required(ErrorMessage = "The author's name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The date of birth is required")]
        public DateTime DateOfBirth { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}
