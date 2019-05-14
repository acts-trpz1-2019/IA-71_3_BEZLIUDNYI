using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class AudioBookInputViewModel : BookInputViewModel
    {
        [Required(ErrorMessage = "Поле является необходимым")]
        [Display(Name = "Время прочтения")]
        public int ReadingTime { get; set; }
    }
}
