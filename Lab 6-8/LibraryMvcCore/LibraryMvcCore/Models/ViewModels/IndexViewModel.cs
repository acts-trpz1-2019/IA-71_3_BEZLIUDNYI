using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class IndexViewModel
    {
        public Description Description { get; set; }
        public int TextBooksCount { get; set; }
        public int AudioBooksCount { get; set; }
        public IEnumerable<IndexBookSet> BookSets { get; set; }
    }

    public class IndexBookSet
    {
        public IList<string> Info { get; set; }
        public string ActionLink { get; set; }
        public IEnumerable<TextBook> TextBooks { get; set; }
        public IEnumerable<AudioBook> AudioBooks { get; set; }
        public string Type { get; set; }
    }
}
