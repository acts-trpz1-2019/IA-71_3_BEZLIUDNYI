using LibraryMvcCore.Helpers;
using LibraryMvcCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LibraryMvcCore.Extensions;


namespace LibraryMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
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
                ActionLink = Url.Action("BookCatalogByGenre", "Catalog", new { genreId = db.Genres.FirstOrDefault(g => g.Name == "Книги о программировании").GenreId, selectionType = "text" }),
                Info = new List<string> { "Мы поможем вам развиваться", "Книги о программировании" },
                TextBooks = programmingBooksList,
                Type = "text"
            };

            IndexBookSet audioBooksSet = new IndexBookSet
            {
                ActionLink = Url.Action("BookCatalog", "Catalog", new { selectionType = "audio" }),
                Info = new List<string> { "Неудобно читать - слушайте", "Более 1000 аудиокниг для взрослых и детей" },
                AudioBooks = audioBooksList,
                Type = "audio"
            };

            IndexViewModel ivm = new IndexViewModel
            {
                Description = db.Descriptions.FirstOrDefault(d => d.TargetName == "LibNet Description"),
                BookSets = new List<IndexBookSet> { newBooksSet, programmingBooksSet, audioBooksSet },
                TextBooksCount = textBooks.Count(),
                AudioBooksCount = audioBooks.Count()
            };

            return View(ivm);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AdminHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Subscription()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            SubscriptionType defaultType = db.SubscriptionTypes.FirstOrDefault(s => s.Name == "Бесплатно");
            List<SubscriptionType> subscriptionTypes = db.SubscriptionTypes
                                                            .OrderBy(t => t.Price)
                                                            .Except(new SubscriptionType[] { defaultType })
                                                            .ToList();
            List<string> subscriptionTypeNames = subscriptionTypes.Select(x => x.Name).ToList();

            SubscriptionForm form = new SubscriptionForm
            {
                SubscriptionTypes = new SelectList(subscriptionTypeNames)
            };
            SubscriptionInputViewModel sivm = new SubscriptionInputViewModel
            {
                SubscriptionForm = form,
                SubscriptionTypes = subscriptionTypes
            };

            return View(sivm);
        }

        [HttpPost]
        public IActionResult Subscription(SubscriptionInputViewModel sivm)
        {
            Subscription newSubscription = new Subscription
            {
                SubscriberId = User.GetUserId(),
                Type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == sivm.SubscriptionForm.SelectedType),
                Duration = sivm.SubscriptionForm.Duration
            };
            Subscription oldSubscription = UserHelper.GetUserSubscription(User, db);
            if (oldSubscription == null)
            {
                db.Subscriptions.Add(newSubscription);
            }
            else
            {
                db.Subscriptions.Remove(oldSubscription);
                db.Subscriptions.Add(newSubscription);

            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DashBoard()
        {
            return View("~/Views/Shared/InProgess.cshtml");
        }
    }
}