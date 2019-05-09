using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Models
{
    public class Genre
    {

        public Genre()
        {
            Books = new List<Book>();
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [MaxLength(255, ErrorMessage = "Слишком длинное название")]
        [Display(Name = "Название")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<Book> Books { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Путь к картинке")]
        public string CoverFilePath { get; set; }
    }
}