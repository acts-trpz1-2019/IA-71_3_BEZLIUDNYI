using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class BookInputViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [MaxLength(255, ErrorMessage = "Слишком длинное название")]
        [Display(Name = "Название")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [MaxLength(255, ErrorMessage = "Слишком длинное название")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Жанры")]
        public string GenresList { get; set; }

        [Display(Name = "Тип подписки")]
        public string SubscriptionType { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Путь к обложке")]
        public string CoverFilePath { get; set; }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Путь к файлу")]
        public string ContentFilePath { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
