using LibraryMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMvcCore.Helpers
{
    public class BooksFilteringHelper
    {

        public static bool BookIsNew(Book book, int days)
        {
            return book.PublishingTime.AddDays(days).CompareTo(DateTime.Now) >= 0;
        }

        public static bool GenresContains(ICollection<Genre> genres, string genre)
        {
            foreach (Genre g in genres)
            {
                if (g.Name == genre)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool GenresContains(ICollection<Genre> genres, int? genreId)
        {
            foreach (Genre g in genres)
            {
                if (g.GenreId == genreId)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsSearchedBook(Book book, string search)
        {
            string[] searchBlocks = search.Trim().Split();
            string[] bookNameBlocks = book.BookName.Trim().Split();

            foreach(string searchBlock in searchBlocks)
            {
                bool result = false;

                foreach (string bookNameBlock in bookNameBlocks)
                {
                    if(searchBlock == bookNameBlock)
                    {
                        result = true;
                    }
                }

                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
    }
}