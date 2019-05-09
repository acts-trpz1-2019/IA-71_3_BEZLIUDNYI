using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class TitledInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<string> InfoBlocks { get; set; }
        public string InfoBlocksString
        {
            get { return string.Join("|", InfoBlocks); }
            set { InfoBlocks = value.Split('|').ToList(); }
        }
    }
}