using LibraryMvcCore.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LibraryMvcCore.Helpers
{
    public static class PagingHelpers
    {
        public static string GetPageLink(string baseUrl, int page)
        {
            return baseUrl + "&page=" + page;
        }

        public static string RemovePageQuery(string uri)
        {
            if (uri.Contains("&page="))
            {
                int index = uri.IndexOf("&page=");
                uri = uri.Remove(index);
            }

            return uri;
        }
    }
}