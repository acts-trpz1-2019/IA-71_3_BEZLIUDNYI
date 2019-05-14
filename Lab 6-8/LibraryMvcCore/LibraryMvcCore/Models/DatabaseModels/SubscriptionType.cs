using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Models
{
    public class SubscriptionType
    {
        public int SubscriptionTypeId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}