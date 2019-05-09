using LibraryMVC2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMVC2.Helpers
{
    public class ModelConvertationHelper
    {
        public static TextBookPresentation GetTextBookPresentation(TextBook book)
        {
            TextBookPresentation presentation = new TextBookPresentation
            {
                Id = book.Id,
                BookName = book.BookName,
                Author = book.Author,
                Pages = book.Pages,
                SubscriptionType = book.SubscriptionType.Name,
                ContentFilePath = book.ContentFilePath,
                CoverFilePath = book.CoverFilePath,
                Description = book.Description
            };
            presentation.GenresList = GetGenresString(book.Genres);

            return presentation;
        }

        public static AudioBookPresentation GetAudioBookPresentation(AudioBook book)
        {
            AudioBookPresentation presentation = new AudioBookPresentation
            {
                Id = book.Id,
                BookName = book.BookName,
                Author = book.Author,
                ReadingTime = book.ReadingTime,
                SubscriptionType = book.SubscriptionType.Name,
                ContentFilePath = book.ContentFilePath,
                CoverFilePath = book.CoverFilePath,
                Description = book.Description
            };

            presentation.GenresList = GetGenresString(book.Genres);

            return presentation;
        }

        public static TextBook GetNewTextBook(TextBookPresentation presentation)
        {
            using (var db = new BookStoreContext())
            {
                TextBook book = new TextBook
                {
                    BookName = presentation.BookName,
                    Author = presentation.Author,
                    Pages = presentation.Pages,
                    ContentFilePath = presentation.ContentFilePath,
                    CoverFilePath = presentation.CoverFilePath,
                    Description = presentation.Description
                };

                ICollection<Genre> genres = GetGenresList(presentation.GenresList);
                foreach (Genre g in genres)
                {
                    book.Genres.Add(g);
                }
                SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == presentation.SubscriptionType);
                if (type == null) return null;
                book.SubscriptionType = type;

                return book;
            }
        }

        public static AudioBook GetNewAudioBook(AudioBookPresentation presentation)
        {
            using (var db = new BookStoreContext())
            {
                AudioBook book = new AudioBook
                {
                    BookName = presentation.BookName,
                    Author = presentation.Author,
                    ReadingTime = presentation.ReadingTime,
                    ContentFilePath = presentation.ContentFilePath,
                    CoverFilePath = presentation.CoverFilePath,
                    Description = presentation.Description
                };

                ICollection<Genre> genres = GetGenresList(presentation.GenresList);
                foreach (Genre g in genres)
                {
                    book.Genres.Add(g);
                }
                SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == presentation.SubscriptionType);
                if (type == null) return null;
                book.SubscriptionType = type;

                return book;
            }
        }

        public static TextBook GetUpdatedTextBook(TextBookPresentation presentation)
        {
            using (var db = new BookStoreContext())
            {
                TextBook book = db.TextBooks.Find(presentation.Id);
                if (book == null)
                {
                    return null;
                }
                book.BookName = presentation.BookName;
                book.Author = presentation.Author;
                book.Pages = presentation.Pages;
                book.ContentFilePath = presentation.ContentFilePath;
                book.CoverFilePath = presentation.CoverFilePath;
                book.Description = presentation.Description;
                book.Genres.Clear();
                ICollection<Genre> genres = GetGenresList(presentation.GenresList);
                foreach (Genre g in genres)
                {
                    book.Genres.Add(g);
                }
                SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == presentation.SubscriptionType);
                if (type == null) return null;
                book.SubscriptionType = type;
                return book;
            }
        }

        public static AudioBook GetUpdatedAudioBook(AudioBookPresentation presentation)
        {
            using (var db = new BookStoreContext())
            {
                AudioBook book = db.AudioBooks.Find(presentation.Id);
                if (book == null)
                {
                    return null;
                }
                book.BookName = presentation.BookName;
                book.Author = presentation.Author;
                book.ReadingTime = presentation.ReadingTime;
                book.ContentFilePath = presentation.ContentFilePath;
                book.CoverFilePath = presentation.CoverFilePath;
                book.Description = presentation.Description;
                book.Genres.Clear();
                ICollection<Genre> genres = GetGenresList(presentation.GenresList);
                foreach (Genre g in genres)
                {
                    book.Genres.Add(g);
                }
                SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == presentation.SubscriptionType);
                if (type == null) return null;
                book.SubscriptionType = type;
                return book;
            }
        }

        private static ICollection<Genre> GetGenresList(string genres)
        {
            using (var db = new BookStoreContext())
            {
                string[] genresName = genres.Trim().Split('|');
                ICollection<Genre> genreList = new List<Genre>();
                foreach (string genreName in genresName)
                {
                    Genre selectedGenre = db.Genres.FirstOrDefault(g => g.Name == genreName);
                    if (selectedGenre != null)
                    {
                        genreList.Add(selectedGenre);
                    }
                }

                return genreList;
            }
        }

        private static string GetGenresString(ICollection<Genre> genresList)
        {
            string genres = "";
            foreach (Genre g in genresList)
            {
                genres += g.Name + "|";
            }

            return genres.Remove(genres.Length - 1);
        }
    }
}