using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFLayer.Entities
{
    public class BookRepoFilter
    {
        public int? AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? BookTitle { get; set; }
        public int? PublishedAfter { get; set; }
    }
}
