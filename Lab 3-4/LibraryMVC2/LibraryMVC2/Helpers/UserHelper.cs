using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LibraryMVC2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Security.Principal;

namespace LibraryMVC2.Helpers
{
    public class UserHelper
    {
        public static SubscriptionType GetUserSubscriptionType()
        {
            using (var db = new BookStoreContext())
            {
                SubscriptionType defaultType = db.SubscriptionTypes.First(s => s.Name == "Бесплатно");
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return defaultType;
                }
                Subscription subscription = GetUserSubscription(db);
                if(subscription == null || SubscriptionExpired(subscription, db))
                {
                    return defaultType;
                }
                SubscriptionType type = subscription.Type;
                return type;
            }
        }

        public static Subscription GetUserSubscription(BookStoreContext db)
        {       
            string userId = HttpContext.Current.User.Identity.GetUserId();
            Subscription subscription = db.Subscriptions.FirstOrDefault(s => s.SubscriberId == userId);
            return subscription;
        }

        public static bool SubscriptionExpired(Subscription s, BookStoreContext db)
        {
            return s.Date.AddMonths(s.Duration) < DateTime.Now;
        }

        public static ApplicationUser GetApplicationUser()
        {
            using (var context = new ApplicationDbContext())
            {
                string userId = HttpContext.Current.User.Identity.GetUserId();
                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
                var user = userManager.FindById(userId);
                return user;
            }
        }
    }
}