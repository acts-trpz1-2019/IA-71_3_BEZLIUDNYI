using LibraryMVC2.Helpers;
using LibraryMVC2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC2.Controllers
{
    public class CatalogController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        private int pageSize = 3;

        [HttpGet]
        public ActionResult MainCatalog()
        {

            CatalogViewModel cvm = new CatalogViewModel
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
        public ActionResult MainCatalogByGenre(int? genreId)
        {
            if (genreId == null || db.Genres.Find(genreId) == null)
            {
                return HttpNotFound();
            }

            CatalogViewModel cvm = new CatalogViewModel
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
        public ActionResult MainCatalogBySearch(string search)
        {
            CatalogViewModel cvm = new CatalogViewModel
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
        public ActionResult BookCatalog(string selectionType, int page = 1)
        {
            BookSelection bs = null;
            switch (selectionType)
            {
                case "text":
                    IEnumerable<Book> textBooks = db.TextBooks
                            .AsEnumerable()
                            .OrderBy(b => b.BookName);
                    bs = new BookSelection
                    {
                        Title = "Все книги",
                        Books = textBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = textBooks.Count() }
                    };
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", bs);

                case "audio":
                    IEnumerable<Book> audioBooks = db.AudioBooks
                                .AsEnumerable()
                                .OrderBy(b => b.BookName);
                    bs = new BookSelection
                    {
                        Title = "Все аудиокниги",
                        Books = audioBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = audioBooks.Count() }
                    };
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", bs);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult BookCatalogBySet(string setName, string selectionType, int page = 1)
        {
            BookSelection bs = null;

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
                            bs = new BookSelection
                            {
                                Title = "Все новинки",
                                Books = noveltyTextBooks
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize),
                                PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = noveltyTextBooks.Count() }
                            };
                            break;
                    }
                    if (bs == null) return HttpNotFound();
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", bs);

                case "audio":
                    switch (setName)
                    {
                        case "novelty":
                            IEnumerable<Book> noveltyAudioBooks = db.AudioBooks
                                          .AsEnumerable()
                                          .Where(b => BooksFilteringHelper.BookIsNew(b, 30))
                                          .OrderBy(b => b.BookName);
                            bs = new BookSelection
                            {
                                Title = "Все новинки",
                                Books = noveltyAudioBooks
                                          .Skip((page - 1) * pageSize)
                                          .Take(pageSize),
                                PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = noveltyAudioBooks.Count() }
                            };
                            break;
                    }
                    if (bs == null) return HttpNotFound();
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", bs);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult BookCatalogBySearch(string search, string selectionType, int page = 1)
        {
            BookSelection bs;
            switch (selectionType)
            {
                case "text":
                    IEnumerable<Book> textBooks = db.TextBooks
                            .AsEnumerable()
                            .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                            .OrderBy(b => b.BookName);
                    bs = new BookSelection
                    {
                        Title = "Все книги",
                        Books = textBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = textBooks.Count() }
                    };
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", bs);

                case "audio":
                    IEnumerable<Book> audioBooks = db.AudioBooks
                                .AsEnumerable()
                                .Where(b => BooksFilteringHelper.IsSearchedBook(b, search))
                                .OrderBy(b => b.BookName);
                    bs = new BookSelection
                    {
                        Title = "Все аудиокниги",
                        Books = audioBooks
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize),
                        PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = audioBooks.Count() }
                    };
                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", bs);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult BookCatalogByGenre(int? genreId, string selectionType, int page = 1)
        {
            BookSelection bs;

            switch (selectionType)
            {
                case "text":
                    if (genreId != null || db.Genres.Find(genreId) != null)
                    {
                        IEnumerable<Book> genreTextBooks = db.TextBooks
                                    .AsEnumerable()
                                    .Where(b => BooksFilteringHelper.GenresContains(b.Genres, genreId))
                                    .OrderBy(b => b.BookName);
                        bs = new BookSelection
                        {
                            Title = "Все книги жанра \"" + db.Genres.Find(genreId).Name + "\"",
                            Books = genreTextBooks
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize),
                            PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = genreTextBooks.Count() }
                        };
                    }
                    else
                    {
                        return HttpNotFound();
                    }     
                    
                    return View("~/Views/Catalog/TextBookCatalog.cshtml", bs);

                case "audio":
                    if (genreId != null || db.Genres.Find(genreId) != null)
                    {
                        IEnumerable<Book> genreAudioBooks = db.AudioBooks
                                    .AsEnumerable()
                                    .Where(b => BooksFilteringHelper.GenresContains(b.Genres, genreId))
                                    .OrderBy(b => b.BookName);
                        bs = new BookSelection
                        {
                            Title = "Все аудиокниги жанра \"" + db.Genres.Find(genreId).Name + "\"",
                            Books = genreAudioBooks
                                    .Skip((page - 1) * pageSize)
                                    .Take(pageSize),
                            PageInfo = new PageInfo { BaseUrl = PagingHelpers.RemovePageQuery(Request.Url), PageNumber = page, PageSize = pageSize, TotalItems = genreAudioBooks.Count() }
                        };
                    }
                    else
                    {
                        return HttpNotFound();
                    }

                    return View("~/Views/Catalog/AudioBookCatalog.cshtml", bs);
            }

            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult BookInfo(int book_id, string type)
        {
            BookInfoContainer bookInfo = new BookInfoContainer
            {
                Type = type
            };

            switch (type)
            {
                case "text":
                    TextBook textBook = db.TextBooks.Find(book_id);
                    if (textBook == null) return HttpNotFound();
                    bookInfo.TextBook = textBook;
                    break;
                case "audio":
                    AudioBook audioBook = db.AudioBooks.Find(book_id);
                    if (audioBook == null) return HttpNotFound();
                    bookInfo.AudioBook = audioBook;
                    break;
                default: return HttpNotFound();
            }

            return View("~/Views/Catalog/BookInfo.cshtml", bookInfo);
        }

        [HttpPost]
        public ActionResult ReadBook(int id)
        {
            string filePath = Properties.Settings.Default.TextBooksFilePath + db.TextBooks.Find(id).ContentFilePath;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
            return fsResult;
        }

        [HttpPost]
        public ActionResult ListenBook(int id)
        {
            string filePath = Properties.Settings.Default.AudioBooksFilePath + db.AudioBooks.Find(id).ContentFilePath;
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fsResult = new FileStreamResult(fileStream, "audio/mpeg");
            return fsResult;
        }
    }
}