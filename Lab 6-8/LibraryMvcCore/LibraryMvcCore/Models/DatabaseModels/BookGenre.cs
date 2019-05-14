using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
