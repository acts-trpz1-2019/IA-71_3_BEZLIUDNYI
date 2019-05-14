using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.Models
{
    public class SubscriptionInputViewModel
    {
        public IEnumerable<SubscriptionType> SubscriptionTypes { get; set; }
        public SubscriptionForm SubscriptionForm { get; set; }
    }

    public class SubscriptionForm
    {
        public SubscriptionForm()
        {
            Duration = 1;
        }

        [Required(ErrorMessage = "Поле является необходимым")]
        [Range(1, 12)]
        [Display(Name = "Длительность подписки")]
        public int Duration { get; set; }

        [Display(Name = "Тип подписки")]
        public string SelectedType { get; set; }

        public SelectList SubscriptionTypes { get; set; }
    }
}
