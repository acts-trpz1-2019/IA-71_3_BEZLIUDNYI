using LibraryMvcCore.Helpers;
using LibraryMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMvcCore.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            // формируем три ссылки - на текущую, предыдущую и следующую
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);

            // создаем ссылку на предыдущую страницу, если она есть
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                output.Content.AppendHtml(prevItem);
            }

            output.Content.AppendHtml(currentItem);
            // создаем ссылку на следующую страницу, если она есть
            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                output.Content.AppendHtml(nextItem);
            }
        }

        public TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                link.AddCssClass("selected_page");
            }
            else
            {
                link.Attributes["href"] = PagingHelpers.GetPageLink(PageModel.BaseUrl, pageNumber);
            }
            link.InnerHtml.Append(pageNumber.ToString());
            return link;
        }

    }
}
