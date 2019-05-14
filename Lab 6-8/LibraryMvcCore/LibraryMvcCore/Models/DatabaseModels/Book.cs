using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Models
{
    public class Book
    {
        public Book()
        {
            BookGenres = new List<BookGenre>();
        }

        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string BookName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }

        [NotMapped]
        public ICollection<Genre> Genres
        {
            get
            {
                return BookGenres.Where(bg => bg.BookId == BookId).Select(bg => bg.Genre).ToList();
            }
        }
        
        public virtual ICollection<BookGenre> BookGenres { get; set; }

        [Required]
        public virtual SubscriptionType SubscriptionType { get; set; }

        public DateTime PublishingTime { get; private set; } = DateTime.Now;

        [Required]
        public string CoverFilePath { get; set; }

        [Required]
        public string ContentFilePath { get; set; }

        public string Description { get; set; }
    
    }
}