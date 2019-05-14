using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class DeleteGenreViewModel
    {
        public string GenreName { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Название жанра")]
        public SelectList GenreNames { get; set; }
    }
}
