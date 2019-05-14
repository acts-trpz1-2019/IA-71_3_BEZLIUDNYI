using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class BookInputContainerViewModel
    {
        public TextBookInputViewModel TextBookPresentation { get; set; }
        public AudioBookInputViewModel AudioBookPresentation { get; set; }
        public string Type { get; set; }
    }
}
