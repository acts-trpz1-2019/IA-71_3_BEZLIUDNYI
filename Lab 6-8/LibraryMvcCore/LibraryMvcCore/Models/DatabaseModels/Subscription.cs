using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;
using LibraryMvcCore.Helpers;
using Microsoft.AspNetCore.Http;

namespace LibraryMvcCore.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }

        [Required]
        public string SubscriberId { get; set; }

        public virtual SubscriptionType Type { get; set; }

        [Required]
        public DateTime Date { get; private set; } = DateTime.Now;

        [Required]
        public int Duration { get; set; }

    }
}