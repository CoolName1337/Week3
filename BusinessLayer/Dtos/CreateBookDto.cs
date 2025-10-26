using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dtos
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The publication year is required")]
        public int PublishedYear { get; set; }
        [Required(ErrorMessage = "The author's id is required")]
        public int AuthorId { get; set; }
    }
}
