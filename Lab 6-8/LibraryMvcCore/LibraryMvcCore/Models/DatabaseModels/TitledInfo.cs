using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Models
{
    public class TitledInfo
    {
        public int TitledInfoId { get; set; }
        public string Title { get; set; }
        public IList<string> ContentBlocks { get; set; }

        public virtual Description Description { get; set; }
    }
}