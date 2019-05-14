using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Models
{
    public class Description
    {
        public Description()
        {
            TitledInfoList = new List<TitledInfo>();
        }

        public int DescriptionId { get; set; }

        [Required]
        [MaxLength(255)]
        public string TargetName { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        public virtual IList<TitledInfo> TitledInfoList { get; set; }
    }
}