using LibraryMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using LibraryMvcCore.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMvcCore.Controllers
{
    [Authorize(Roles = "admin")]
    public class ManageModelController : Controller
    {
        private ApplicationContext db;

        public ManageModelController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGenre(Genre g)
        {
            db.Genres.Add(g);
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpGet]
        public IActionResult AddTextBook()
        {
            BookInputContainerViewModel bicvm = new BookInputContainerViewModel
            {
                Type = "text"
            };
            return View("~/Views/ManageModel/AddBook.cshtml", bicvm);
        }

        [HttpGet]
        public IActionResult AddAudioBook()
        {
            BookInputContainerViewModel bicvm = new BookInputContainerViewModel
            {
                Type = "audio"
            };
            return View("~/Views/ManageModel/AddBook.cshtml", bicvm);
        }

        [HttpGet]
        public IActionResult DeleteGenre()
        {
            DeleteGenreViewModel dgvm = new DeleteGenreViewModel
            {
                GenreNames = new SelectList(db.Genres.OrderBy(g => g.Name).Select(g => g.Name))
            };
            return View(dgvm);
        }

        [HttpPost]
        public IActionResult AddTextBook(BookInputContainerViewModel bicvm)
        {
            TextBook book = ModelConvertationHelper.GetNewTextBook(db, bicvm.TextBookPresentation);
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
        public IActionResult AddAudioBook(BookInputContainerViewModel bicvm)
        {
            AudioBook book = ModelConvertationHelper.GetNewAudioBook(db, bicvm.AudioBookPresentation);
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
        public IActionResult EditTextBook(int id)
        {
            TextBook textBook = db.TextBooks.Find(id);
            if (textBook == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookInputContainerViewModel bicvm = new BookInputContainerViewModel
            {
                TextBookPresentation = ModelConvertationHelper.GetTextBookInputViewModel(textBook),
                Type = "text"
            };
            return View("~/Views/ManageModel/EditBook.cshtml", bicvm);
        }

        [HttpPost]
        public IActionResult EditAudioBook(int id)
        {
            AudioBook audioBook = db.AudioBooks.Find(id);
            if (audioBook == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            BookInputContainerViewModel bicvm = new BookInputContainerViewModel
            {
                AudioBookPresentation = ModelConvertationHelper.GetAudioBookInputViewModel(audioBook),
                Type = "audio"
            };
            return View("~/Views/ManageModel/EditBook.cshtml", bicvm);
        }

        [HttpPost]
        public IActionResult DeleteTextBook(int id)
        {
            TextBook toDelete = db.TextBooks.Find(id);
            db.TextBooks.Remove(toDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteAudioBook(int id)
        {
            AudioBook toDelete = db.AudioBooks.Find(id);
            db.AudioBooks.Remove(toDelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult DeleteGenre(DeleteGenreViewModel dgvm)
        {
            Genre toDelete = db.Genres.FirstOrDefault(g => g.Name == dgvm.GenreName);
            if(toDelete == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            db.Genres.Remove(toDelete);
            db.SaveChanges();
            return RedirectToAction("AdminHome", "Home");
        }

        [HttpPost]
        public IActionResult SaveTextBookChanges(BookInputContainerViewModel bicvm)
        {
            TextBook book = ModelConvertationHelper.GetUpdatedTextBook(db, bicvm.TextBookPresentation);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveAudioBookChanges(BookInputContainerViewModel bicvm)
        {
            AudioBook book = ModelConvertationHelper.GetUpdatedAudioBook(db, bicvm.AudioBookPresentation);
            if (book == null)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}