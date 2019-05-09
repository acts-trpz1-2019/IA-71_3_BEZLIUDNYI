using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class SubscriptionType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}