using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class MainCatalogViewModel
    {
        public string SearchString { get; set; }
        public Genre SelectedGenre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<TextBook> TextBooks { get; set; }
        public IEnumerable<AudioBook> AudioBooks { get; set; }
        public Description Description { get; set; }
    }
}
