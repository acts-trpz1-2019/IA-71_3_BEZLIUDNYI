using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Security.Principal;
using System.Web;
using LibraryMVC2.Helpers;

namespace LibraryMVC2.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        public string SubscriberId { get; private set; } = HttpContext.Current.User.Identity.GetUserId();

        [Required]
        public virtual SubscriptionType Type { get; set; }

        [Required]
        public DateTime Date { get; private set; } = DateTime.Now;

        [Required]
        public int Duration { get; set; }

    }
}