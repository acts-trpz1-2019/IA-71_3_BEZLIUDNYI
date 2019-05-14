using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Properties
{
    public class AppSettings
    {
        public static string TextBooksFilePath { get; set; }
        public static string AudioBooksFilePath { get; set; }
        public static string BookCoveringsFilePath { get; set; }
        public static string GenreCoveringsFilePath { get; set; }
        public static int PageSize { get; set; }
    }
}
