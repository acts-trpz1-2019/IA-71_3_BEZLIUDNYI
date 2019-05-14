#pragma checksum "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a665cab2183b9e7ddc1c124b6040fd0656472295"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Subscription), @"mvc.1.0.view", @"/Views/Home/Subscription.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Subscription.cshtml", typeof(AspNetCore.Views_Home_Subscription))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\_ViewImports.cshtml"
using LibraryMvcCore;

#line default
#line hidden
#line 2 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\_ViewImports.cshtml"
using LibraryMvcCore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a665cab2183b9e7ddc1c124b6040fd0656472295", @"/Views/Home/Subscription.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2db0b02799d3f434a95101a7f3fa614f7032c356", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Subscription : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SubscriptionInputViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
  
    ViewBag.Title = "Subscription";
    Layout = "~/Views/Shared/_CustomLayout.cshtml";

#line default
#line hidden
            BeginContext(132, 394, true);
            WriteLiteral(@"
<div class=""billetWrapper"">
    <div class=""full_article_container"">
        <h2>Подписка</h2>
        <h3>Каталог</h3>
        <table class=""subscription_catalog"">
            <thead>
                <tr>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Описание</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 20 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
                 foreach (SubscriptionType st in Model.SubscriptionTypes)
                {

#line default
#line hidden
            BeginContext(620, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(675, 7, false);
#line 23 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
                       Write(st.Name);

#line default
#line hidden
            EndContext();
            BeginContext(682, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(718, 8, false);
#line 24 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
                       Write(st.Price);

#line default
#line hidden
            EndContext();
            BeginContext(726, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(762, 14, false);
#line 25 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
                       Write(st.Description);

#line default
#line hidden
            EndContext();
            BeginContext(776, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 27 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
                }

#line default
#line hidden
            BeginContext(829, 89, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n        <br /><br />\r\n        <h3>Оформить</h3>\r\n");
            EndContext();
#line 32 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
         using (Html.BeginForm())
        {

#line default
#line hidden
            BeginContext(964, 35, true);
            WriteLiteral("            <div>\r\n                ");
            EndContext();
            BeginContext(1000, 47, false);
#line 35 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
           Write(Html.LabelFor(b => b.SubscriptionForm.Duration));

#line default
#line hidden
            EndContext();
            BeginContext(1047, 24, true);
            WriteLiteral("<br />\r\n                ");
            EndContext();
            BeginContext(1072, 100, false);
#line 36 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
           Write(Html.EditorFor(b => b.SubscriptionForm.Duration, new { htmlAttributes = new { min = 1, max = 12 } }));

#line default
#line hidden
            EndContext();
            BeginContext(1172, 57, true);
            WriteLiteral("\r\n            </div>\r\n            <div>\r\n                ");
            EndContext();
            BeginContext(1230, 51, false);
#line 39 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
           Write(Html.LabelFor(b => b.SubscriptionForm.SelectedType));

#line default
#line hidden
            EndContext();
            BeginContext(1281, 24, true);
            WriteLiteral("<br />\r\n                ");
            EndContext();
            BeginContext(1306, 100, false);
#line 40 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
           Write(Html.DropDownListFor(b => b.SubscriptionForm.SelectedType, Model.SubscriptionForm.SubscriptionTypes));

#line default
#line hidden
            EndContext();
            BeginContext(1406, 102, true);
            WriteLiteral("\r\n            </div>\r\n            <br /><br />\r\n            <input type=\"submit\" value=\"Оформить\" />\r\n");
            EndContext();
#line 44 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\Home\Subscription.cshtml"
        }

#line default
#line hidden
            BeginContext(1519, 36, true);
            WriteLiteral("        <br />\r\n    </div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SubscriptionInputViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591