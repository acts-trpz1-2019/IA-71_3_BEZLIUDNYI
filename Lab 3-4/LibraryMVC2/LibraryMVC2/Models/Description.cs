using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class Description
    {
        public Description()
        {
            TitledInfoList = new List<TitledInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string TargetName { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        public virtual IList<TitledInfo> TitledInfoList { get; set; }
    }
}