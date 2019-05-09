using LibraryMVC2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC2.Helpers;
using System.Data.Entity;

namespace LibraryMVC2.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<TextBook> textBooks = db.TextBooks;
            IEnumerable<AudioBook> audioBooks = db.AudioBooks; 
                      
            IEnumerable<TextBook> newBooksList = textBooks
                    .Where(b => BooksFilteringHelper.BookIsNew(b, 30))
                    .Take(10)
                    .OrderBy(b => b.BookName);
            
            IEnumerable<TextBook> programmingBooksList = textBooks
                    .Where(b => BooksFilteringHelper.GenresContains(b.Genres, "Книги о программировании"))
                    .Take(10)
                    .OrderBy(b => b.BookName);

            IEnumerable<AudioBook> audioBooksList = audioBooks
                    .Take(10)
                    .OrderBy(b => b.BookName);

            IndexBookSet newBooksSet = new IndexBookSet
            {
                ActionLink = Url.Action("BookCatalogBySet", "Catalog", new { setName = "novelty", selectionType = "text" }),
                Info = new List<string> { "Мы добавляем лучшие новинки", "+100 книг каждый день. Модные авторы и эксклюзивные издательства" },
                TextBooks = newBooksList,
                Type = "text"
            };

            IndexBookSet programmingBooksSet = new IndexBookSet
            {
                ActionLink = Url.Action("BookCatalogByGenre", "Catalog", new { genreId = db.Genres.FirstOrDefault(g => g.Name == "Книги о программировании").Id, selectionType = "text" }),
                Info = new List<string> { "Мы поможем вам развиваться", "Книги о программировании" },
                TextBooks = programmingBooksList,
                Type = "text"
            };

            IndexBookSet audioBooksSet = new IndexBookSet
            {
                ActionLink = Url.Action("BookCatalog", "Catalog", new { selectionType = "audio" }),
                Info = new List<string> { "Неудобно читать - слушайте", "Более 11 000 аудиокниг для взрослых и детей" },
                AudioBooks = audioBooksList,
                Type = "audio"
            };

            LibraryInfoViewModel livm = new LibraryInfoViewModel
            {
                Description = db.Descriptions.FirstOrDefault(d => d.TargetName == "LibNet Description"),
                BookSets = new List<IndexBookSet> { newBooksSet, programmingBooksSet, audioBooksSet }
            };

            return View(livm);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Subscription()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            SubscriptionType defaultType = db.SubscriptionTypes.FirstOrDefault(s => s.Name == "Бесплатно");
            List<SubscriptionType> subscriptionTypes = LibraryInfoHelper
                                                            .GetSubscriptionTypes()
                                                            .Except(new SubscriptionType[] { defaultType })
                                                            .ToList();
            List<string> subscriptionTypeNames = subscriptionTypes.Select(x => x.Name).ToList();

            SubscriptionForm form = new SubscriptionForm
            {
                SubscriptionTypes = new SelectList(subscriptionTypeNames)
            };
            SubscriptionViewModel svm = new SubscriptionViewModel
            {
                SubscriptionForm = form,
                SubscriptionTypes = subscriptionTypes
            };

            return View(svm);
        }

        [HttpPost]
        public ActionResult Subscription(SubscriptionViewModel svm)
        {
            Subscription newSubscription = new Subscription
            {
                Type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == svm.SubscriptionForm.SelectedType),
                Duration = svm.SubscriptionForm.Duration
            };
            Subscription oldSubscription = UserHelper.GetUserSubscription(db);
            if(oldSubscription == null)
            {
                db.Subscriptions.Add(newSubscription);
            }
            else
            {
                db.Entry(oldSubscription).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}