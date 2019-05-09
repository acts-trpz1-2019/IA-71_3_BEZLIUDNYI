using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class Book
    {

        public Book()
        {
            Genres = new List<Genre>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string BookName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }
        
        public virtual ICollection<Genre> Genres { get; set; }

        [Required]
        public virtual SubscriptionType SubscriptionType { get; set; }

        [Required]
        public int RateSum { get; set; } = 0;
        
        [Required]
        public int RateCount { get; set; } = 0;

        public DateTime PublishingTime { get; private set; } = DateTime.Now;

        [NotMapped]
        public int Rate
        {
            get
            {
                if (RateSum > 0 && RateCount > 0)
                {
                    return RateSum / RateCount;
                }

                return 0;
            }
        }

        [Required]
        public string CoverFilePath { get; set; }

        [Required]
        public string ContentFilePath { get; set; }

        public string Description { get; set; }
    
    }
}