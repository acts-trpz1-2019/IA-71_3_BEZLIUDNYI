using LibraryMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryMVC2.Helpers;
using System.Data.Entity;

namespace LibraryMVC2.Controllers
{
    public class ManageModelController : Controller
    {
        private BookStoreContext db = new BookStoreContext();

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddGenre()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult AddGenre(Genre g)
        {
            db.Genres.Add(g);
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddTextBook()
        {
            BookPresentationContainer bpc = new BookPresentationContainer
            {
                Type = "text"
            };
            return View("~/Views/ManageModel/AddBook.cshtml", bpc);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddAudioBook()
        {
            BookPresentationContainer bpc = new BookPresentationContainer
            {
                Type = "audio"
            };
            return View("~/Views/ManageModel/AddBook.cshtml", bpc);
        }

        [HttpPost]
        public ActionResult AddTextBook(BookPresentationContainer bpc)
        {
            TextBook book = ModelConvertationHelper.GetNewTextBook(bpc.TextBookPresentation);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            foreach (Genre g in book.Genres)
            {
                db.Genres.Attach(g);
            }
            db.SubscriptionTypes.Attach(book.SubscriptionType);
            db.TextBooks.Add(book);
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpPost]
        public ActionResult AddAudioBook(BookPresentationContainer bpc)
        {
            AudioBook book = ModelConvertationHelper.GetNewAudioBook(bpc.AudioBookPresentation);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            foreach (Genre g in book.Genres)
            {
                db.Genres.Attach(g);
            }
            db.SubscriptionTypes.Attach(book.SubscriptionType);
            db.AudioBooks.Add(book);
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpPost]
        public ActionResult EditTextBook(int id)
        {
            TextBook textBook = db.TextBooks.Find(id);
            if(textBook == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookPresentationContainer bpc = new BookPresentationContainer
            {
                TextBookPresentation = ModelConvertationHelper.GetTextBookPresentation(textBook),
                Type = "text"
            };
            return View("~/Views/ManageModel/EditBook.cshtml", bpc);
        }

        [HttpPost]
        public ActionResult EditAudioBook(int id)
        {
            AudioBook audioBook = db.AudioBooks.Find(id);
            if (audioBook == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookPresentationContainer bpc = new BookPresentationContainer
            {
                AudioBookPresentation = ModelConvertationHelper.GetAudioBookPresentation(audioBook),
                Type = "audio"
            };
            return View("~/Views/ManageModel/EditBook.cshtml", bpc);
        }

        [HttpPost]
        public ActionResult SaveTextBookChanges(BookPresentationContainer bpc)
        {
            TextBook book = ModelConvertationHelper.GetUpdatedTextBook(bpc.TextBookPresentation);
            if(book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpPost]
        public ActionResult SaveAudioBookChanges(BookPresentationContainer bpc)
        {
            AudioBook book = ModelConvertationHelper.GetUpdatedAudioBook(bpc.AudioBookPresentation);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }
    }
}