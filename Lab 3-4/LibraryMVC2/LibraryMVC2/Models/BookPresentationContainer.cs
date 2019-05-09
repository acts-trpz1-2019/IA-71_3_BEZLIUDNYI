using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class BookPresentationContainer
    {
        public TextBookPresentation TextBookPresentation { get; set; }
        public AudioBookPresentation AudioBookPresentation { get; set; }
        public string Type { get; set; }
    }
}