
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Dtos
{
    public class BookFilterDto
    {
        [Range(0, int.MaxValue)]
        public int? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? BookTitle { get; set; }
        public int? PublishedAfter { get; set; }

        // Переопределил для логирования
        public override string ToString()
        {
            string filtersString =
                (AuthorId.HasValue ? $"\n\tAuthorID : {AuthorId.Value}" : "") +
                (AuthorName != null ? $"\n\tAuthorName : {AuthorName}" : "") +
                (BookTitle != null ? $"\n\tBookTitle : {BookTitle}" : "") +
                (PublishedAfter.HasValue ? $"\n\tPublishedAfter : {PublishedAfter.Value}" : "");

            return filtersString;
        }
    }
}
