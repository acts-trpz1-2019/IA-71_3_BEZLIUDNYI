using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMvcCore.Models
{
    public class BookCatalogViewModel
    {
        public string Title { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public string BaseUrl { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}