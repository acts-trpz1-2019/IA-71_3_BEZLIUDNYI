using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class BookInfoContainer
    {
        public TextBook TextBook { get; set; }
        public AudioBook AudioBook { get; set; }
        public string Type { get; set; }
    }
}