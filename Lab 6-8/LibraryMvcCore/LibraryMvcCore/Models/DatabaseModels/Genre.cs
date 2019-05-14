using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Models
{
    public class Genre
    {
        public Genre()
        {
            BookGenres = new List<BookGenre>();
        }

        [ScaffoldColumn(false)]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [MaxLength(255, ErrorMessage = "Слишком длинное название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<BookGenre> BookGenres { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Путь к картинке")]
        public string CoverFilePath { get; set; }
    }
}