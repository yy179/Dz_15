using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_15.Models
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
        public Guid GenreId { get; set; }
        public GenreEntity Genre { get; set; }
        public int PublishedYear { get; set; }
    }
}
