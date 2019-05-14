using LibraryMvcCore.Helpers;
using LibraryMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http.Extensions;
using LibraryMvcCore.Properties;
using Microsoft.AspNetCore.Http;

namespace LibraryMvcCore.Controllers
{
    public class CatalogController : Controller
    {
        private ApplicationContext db;
        private int pageSize = AppSettings.PageSize;

        public CatalogController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult MainCatalog()
        {

            MainCatalogViewModel cvm = new MainCatalogViewModel
            {
                Genres = db.Genres.OrderBy(g => g.Name),
                TextBooks = db.TextBooks
                            .OrderBy(b => b.BookName)
                            .Take(10),
                AudioBooks = db.AudioBooks
                             .OrderBy(b => b.BookName)
                             .Take(10),
                Description = db.Descriptions.FirstOrDefault(d => d.TargetName == "Book Catalog Description")
            };

            return View(cvm);
        }

        [HttpGet]
        public IActionResult MainCatalogByGenre(int? genreId)
        {
            if (genreId == null || db.Genres.Find(genreId) == null)
            {
                return NotFound();
            }

            MainCatalogViewModel cvm = new MainCatalogViewModel
            {
                SelectedGenre = db.Genres.Find(genreId),
                Genres = db.Genres.OrderBy(g => g.Name),
                TextBooks = db.TextBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.GenresContains(b.Genres, genreId))
                            .OrderBy(b => b.BookName)
                            .Take(10),
                AudioBooks = db.AudioBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.GenresContains(b.Genres, genreId))
                            .OrderBy(b => b.BookName)
                            .Take(10)
            };

            return View("~/Views/Catalog/MainCatalog.cshtml", cvm);
        }

        [HttpGet]
        public IActionResult MainCatalogBySearch(string search)
        {
            MainCatalogViewModel cvm = new MainCatalogViewModel
            {
                SearchString = search,
                Genres = db.Genres.OrderBy(g => g.Name),
                TextBooks = db.TextBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                            .OrderBy(b => b.BookName)
                            .Take(10),
                AudioBooks = db.AudioBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                            .OrderBy(b => b.BookName)
                            .Take(10)
            };

            return View("~/Views/Catalog/MainCatalog.cshtml", cvm);
        }

        [HttpGet]
        public IActionResult BookCatalog(string selectionType, int page = 1)
        {
            BookCatalogViewModel cvm = null;
            string uri = UriHelper.GetEncodedPathAndQuery(Request);
            switch (selectionType)
            {
                case "text":
                    IEnumerable<Book> textBooks = db.TextBooks
                            .AsEnumerable()
                            .OrderBy(b => b.BookName);
                    cvm = new BookCatalogViewModel
                    {
                        Title = "Все книги",
                        Books = textBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = textBooks.Count() }
                    };
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", cvm);

                case "audio":
                    IEnumerable<Book> audioBooks = db.AudioBooks
                                .AsEnumerable()
                                .OrderBy(b => b.BookName);
                    cvm = new BookCatalogViewModel
                    {
                        Title = "Все аудиокниги",
                        Books = audioBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = audioBooks.Count() }
                    };
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", cvm);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult BookCatalogBySet(string setName, string selectionType, int page = 1)
        {
            BookCatalogViewModel cvm = null;
            string uri = UriHelper.GetEncodedPathAndQuery(Request);

            switch (selectionType)
            {
                case "text":
                    switch (setName)
                    {
                        case "novelty":
                            IEnumerable<Book> noveltyTextBooks = db.TextBooks
                                          .AsEnumerable()
                                          .Where(b => BooksFilteringHelper.BookIsNew(b, 30))
                                          .OrderBy(b => b.BookName);
                            cvm = new BookCatalogViewModel
                            {
                                Title = "Все новинки",
                                Books = noveltyTextBooks
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize),
                                PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = noveltyTextBooks.Count() }
                            };
                            break;
                    }
                    if (cvm == null) return NotFound();
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", cvm);

                case "audio":
                    switch (setName)
                    {
                        case "novelty":
                            IEnumerable<Book> noveltyAudioBooks = db.AudioBooks
                                          .AsEnumerable()
                                          .Where(b => BooksFilteringHelper.BookIsNew(b, 30))
                                          .OrderBy(b => b.BookName);
                            cvm = new BookCatalogViewModel
                            {
                                Title = "Все новинки",
                                Books = noveltyAudioBooks
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize),
                                PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = noveltyAudioBooks.Count() }
                            };
                            break;
                    }
                    if (cvm == null) return NotFound();
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", cvm);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult BookCatalogBySearch(string search, string selectionType, int page = 1)
        {
            BookCatalogViewModel cvm = null;
            string uri = UriHelper.GetEncodedPathAndQuery(Request);

            switch (selectionType)
            {
                case "text":
                    IEnumerable<Book> textBooks = db.TextBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                            .OrderBy(b => b.BookName);
                    cvm = new BookCatalogViewModel
                    {
                        Title = "Все книги",
                        Books = textBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = textBooks.Count() }
                    };
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", cvm);

                case "audio":
                    IEnumerable<Book> audioBooks = db.AudioBooks
                                .AsEnumerable()
                                .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                                .OrderBy(b => b.BookName);
                    cvm = new BookCatalogViewModel
                    {
                        Title = "Все аудиокниги",
                        Books = audioBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = audioBooks.Count() }
                    };
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", cvm);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult BookCatalogByGenre(int? genreId, string selectionType, int page = 1)
        {
            BookCatalogViewModel cvm = null;
            string uri = UriHelper.GetEncodedPathAndQuery(Request);

            switch (selectionType)
            {
                case "text":
                    if (genreId != null || db.Genres.Find(genreId) != null)
                    {
                        IEnumerable<Book> genreTextBooks = db.TextBooks
                                    .AsEnumerable()
                                    .Where(b => BooksFilteringHelper.GenresContains(b.Genres, genreId))
                                    .OrderBy(b => b.BookName);
                        cvm = new BookCatalogViewModel
                        {
                            Title = "Все книги жанра \"" + db.Genres.Find(genreId).Name + "\"",
                            Books = genreTextBooks
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize),
                            PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = genreTextBooks.Count() }
                        };
                    }
                    else
                    {
                        return NotFound();
                    }

                    return View("~/Views/Catalog/TextBookCatalog.cshtml", cvm);

                case "audio":
                    if (genreId != null || db.Genres.Find(genreId) != null)
                    {
                        IEnumerable<Book> genreAudioBooks = db.AudioBooks
                                    .AsEnumerable()
                                    .Where(b => BooksFilteringHelper.GenresContains(b.Genres, "Книги о программировании"))
                                    .OrderBy(b => b.BookName);
                        cvm = new BookCatalogViewModel
                        {
                            Title = "Все аудиокниги жанра \"" + db.Genres.Find(genreId).Name + "\"",
                            Books = genreAudioBooks
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize),
                            PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(uri), PageNumber = page, PageSize = pageSize, TotalItems = genreAudioBooks.Count() }
                        };
                    }
                    else
                    {
                        return NotFound();
                    }

                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", cvm);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult BookInfo(int book_id, string type)
        {
            BookInfoContainerViewModel bookInfo = new BookInfoContainerViewModel
            {
                Type = type,
            };

            switch (type)
            {
                case "text":
                    TextBook textBook = db.TextBooks.Find(book_id);
                    if (textBook == null) return NotFound();
                    bookInfo.TextBook = textBook;
                    bookInfo.IsAccessible = User.IsInRole("admin") || UserHelper.GetUserSubscriptionType(User, db).Level >= textBook.SubscriptionType.Level;
                    break;
                case "audio":
                    AudioBook audioBook = db.AudioBooks.Find(book_id);
                    if (audioBook == null) return NotFound();
                    bookInfo.AudioBook = audioBook;
                    bookInfo.IsAccessible = User.IsInRole("admin") || UserHelper.GetUserSubscriptionType(User, db).Level >= audioBook.SubscriptionType.Level;
                    break;
                default: return NotFound();
            }

            return View(bookInfo);
        }

        [HttpPost]
        public IActionResult ReadBook(int id)
        {
            string filePath = AppSettings.TextBooksFilePath + db.TextBooks.Find(id).ContentFilePath;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }

        [HttpPost]
        public IActionResult ListenBook(int id)
        {
            string filePath = AppSettings.AudioBooksFilePath + db.AudioBooks.Find(id).ContentFilePath;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "audio/mpeg");
            return fsResult;
        }
    }
}