using LibraryMVC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC2.Helpers
{
    public static class PagingHelpers
    {
       public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
       {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected_page");
                }
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
       }

        public static string GetPageLink(this HtmlHelper html, string baseUrl, int page)
        {
            return baseUrl + "&page=" + page;
        }

        public static string RemovePageQuery(Uri uri)
        {
            string baseUrl = uri.PathAndQuery;
            if (baseUrl.Contains("&page="))
            {
                int index = baseUrl.IndexOf("&page=");
                baseUrl = baseUrl.Remove(index);
            }

            return baseUrl;
        }
    }
}