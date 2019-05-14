using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class TextBookInputViewModel : BookInputViewModel
    {
        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Количество страниц")]
        public int Pages { get; set; }
    }
}
