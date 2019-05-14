using LibraryMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Helpers
{
    public class ModelConvertationHelper
    {
        public static TextBookInputViewModel GetTextBookInputViewModel(TextBook book)
        {
            TextBookInputViewModel inputModel = new TextBookInputViewModel
            {
                Id = book.BookId,
                BookName = book.BookName,
                Author = book.Author,
                Pages = book.Pages,
                SubscriptionType = book.SubscriptionType.Name,
                ContentFilePath = book.ContentFilePath,
                CoverFilePath = book.CoverFilePath,
                Description = book.Description
            };
            inputModel.GenresList = GetGenresString(book.Genres);
            return inputModel;
        }

        public static AudioBookInputViewModel GetAudioBookInputViewModel(AudioBook book)
        {
            AudioBookInputViewModel inputModel = new AudioBookInputViewModel
            {
                Id = book.BookId,
                BookName = book.BookName,
                Author = book.Author,
                ReadingTime = book.ReadingTime,
                SubscriptionType = book.SubscriptionType.Name,
                ContentFilePath = book.ContentFilePath,
                CoverFilePath = book.CoverFilePath,
                Description = book.Description
            };
            inputModel.GenresList = GetGenresString(book.Genres);
            return inputModel;
        }

        public static TextBook GetNewTextBook(ApplicationContext db, TextBookInputViewModel inputModel)
        {
            TextBook book = new TextBook
            {
                BookName = inputModel.BookName,
                Author = inputModel.Author,
                Pages = inputModel.Pages,
                ContentFilePath = inputModel.ContentFilePath,
                CoverFilePath = inputModel.CoverFilePath,
                Description = inputModel.Description
            };

            ICollection<Genre> genres = inputModel.GenresList.Trim().Split().Select(s => db.Genres.FirstOrDefault(g => g.Name == s)).ToList();
            foreach (Genre g in genres)
            {
                book.Genres.Add(g);
            }
            SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == inputModel.SubscriptionType);
            if (type == null)
            {
                return null;
            }
            book.SubscriptionType = type;
            return book;
        }

        public static AudioBook GetNewAudioBook(ApplicationContext db, AudioBookInputViewModel inputModel)
        {
            AudioBook book = new AudioBook
            {
                BookName = inputModel.BookName,
                Author = inputModel.Author,
                ReadingTime = inputModel.ReadingTime,
                ContentFilePath = inputModel.ContentFilePath,
                CoverFilePath = inputModel.CoverFilePath,
                Description = inputModel.Description
            };

            ICollection<Genre> genres = GetGenresList(db, inputModel.GenresList);
            foreach (Genre g in genres)
            {
                book.Genres.Add(g);
            }
            SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == inputModel.SubscriptionType);
            if (type == null)
            {
                return null;
            }
            book.SubscriptionType = type;
            return book;
        }

        public static TextBook GetUpdatedTextBook(ApplicationContext db, TextBookInputViewModel inputModel)
        {
            TextBook book = db.TextBooks.Find(inputModel.Id);
            if (book == null)
            {
                return null;
            }
            book.BookName = inputModel.BookName;
            book.Author = inputModel.Author;
            book.Pages = inputModel.Pages;
            book.ContentFilePath = inputModel.ContentFilePath;
            book.CoverFilePath = inputModel.CoverFilePath;
            book.Description = inputModel.Description;
            book.Genres.Clear();
            ICollection<Genre> genres = GetGenresList(db, inputModel.GenresList);
            foreach (Genre g in genres)
            {
                book.Genres.Add(g);
            }
            SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == inputModel.SubscriptionType);
            if (type == null)
            {
                return null;
            }
            book.SubscriptionType = type;
            return book;
        }

        public static AudioBook GetUpdatedAudioBook(ApplicationContext db, AudioBookInputViewModel inputModel)
        {
            AudioBook book = db.AudioBooks.Find(inputModel.Id);
            if (book == null)
            {
                return null;
            }
            book.BookName = inputModel.BookName;
            book.Author = inputModel.Author;
            book.ReadingTime = inputModel.ReadingTime;
            book.ContentFilePath = inputModel.ContentFilePath;
            book.CoverFilePath = inputModel.CoverFilePath;
            book.Description = inputModel.Description;
            book.Genres.Clear();
            ICollection<Genre> genres = GetGenresList(db, inputModel.GenresList);
            foreach (Genre g in genres)
            {
                book.Genres.Add(g);
            }
            SubscriptionType type = db.SubscriptionTypes.FirstOrDefault(s => s.Name == inputModel.SubscriptionType);
            if (type == null)
            {
                return null;
            }
            book.SubscriptionType = type;
            return book;
        }

        private static ICollection<Genre> GetGenresList(ApplicationContext db, string genres)
        {
            return genres
                .Trim()
                .Split()
                .Select(s => db.Genres.FirstOrDefault(g => g.Name == s))
                .ToList();
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