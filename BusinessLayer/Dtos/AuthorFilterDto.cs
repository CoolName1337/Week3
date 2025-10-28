
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class AuthorFilterDto
    {
        [Range(0, int.MaxValue)]
        public int? BookId { get; set; }
        public string? AuthorName { get; set; }
        public string? BookTitle { get; set; }
        public DateOnly? BirthAfter { get; set; }

        // Переопределил для логирования
        public override string ToString()
        {
            string filtersString = 
                (BookId.HasValue ? $"\n\tBookID : {BookId.Value}" : "") +
                (AuthorName != null ? $"\n\tAuthorName : {AuthorName}" : "") +
                (BookTitle != null ? $"\n\tBookTitle : {BookTitle}" : "") +
                (BirthAfter.HasValue ? $"\n\tBirthAfter : {BirthAfter.Value}" : "");

            return filtersString;    
        }
    }
}
