using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class BookInfoContainerViewModel
    {
        public TextBook TextBook { get; set; }
        public AudioBook AudioBook { get; set; }
        public bool IsAccessible { get; set; }
        public string Type { get; set; }
    }
}
