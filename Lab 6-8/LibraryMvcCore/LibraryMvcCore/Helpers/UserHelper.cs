using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using LibraryMvcCore.Models;

namespace LibraryMvcCore.Helpers
{
    public class UserHelper
    {
        public static SubscriptionType GetUserSubscriptionType(ClaimsPrincipal user, ApplicationContext db)
        {
            SubscriptionType defaultType = db.SubscriptionTypes.First(s => s.Name == "Бесплатно");
            if (!user.Identity.IsAuthenticated)
            {
                return defaultType;
            }
            Subscription subscription = GetUserSubscription(user, db);
            if (subscription == null || SubscriptionExpired(subscription))
            {
                return defaultType;
            }
            SubscriptionType type = subscription.Type;
            return type;
        }

        public static Subscription GetUserSubscription(ClaimsPrincipal user, ApplicationContext db)
        {
            string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            Subscription subscription = db.Subscriptions.FirstOrDefault(s => s.SubscriberId == userId);
            return subscription;
        }

        public static bool SubscriptionExpired(Subscription s)
        {
            return s.Date.AddMonths(s.Duration) < DateTime.Now;
        }
    }
}