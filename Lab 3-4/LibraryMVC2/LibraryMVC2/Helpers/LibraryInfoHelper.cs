using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryMVC2.Models;

namespace LibraryMVC2.Helpers
{
    public class LibraryInfoHelper
    {
        public static int GetBooksCount()
        {
            using(var db = new BookStoreContext())
            {
                return db.TextBooks.Count();
            }
        }

        public static int GetAudioBooksCount()
        {
            using (var db = new BookStoreContext())
            {
                return db.AudioBooks.Count();
            }
        }

        public static List<SubscriptionType> GetSubscriptionTypes()
        {
            using (var db = new BookStoreContext())
            {
                List<SubscriptionType> subscriptionTypes = db.SubscriptionTypes.OrderBy(t => t.Price).ToList();
                return subscriptionTypes;
            }
        }
    }
}