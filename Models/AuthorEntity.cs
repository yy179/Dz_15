using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_15.Models
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<BookEntity> Books { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}