#pragma checksum "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "faf44b7d303817d7ded8edf39342316c08c4d60b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageModel_EditBook), @"mvc.1.0.view", @"/Views/ManageModel/EditBook.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManageModel/EditBook.cshtml", typeof(AspNetCore.Views_ManageModel_EditBook))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"faf44b7d303817d7ded8edf39342316c08c4d60b", @"/Views/ManageModel/EditBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2db0b02799d3f434a95101a7f3fa614f7032c356", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageModel_EditBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookInputContainerViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
  
    ViewBag.Title = "EditBook";
    Layout = "~/Views/Shared/_CustomLayout.cshtml";

#line default
#line hidden
            BeginContext(129, 116, true);
            WriteLiteral("\r\n<div class=\"billetWrapper\">\r\n    <div class=\"full_article_container\">\r\n        <h2>Редактировать аудиокнигу</h2>\r\n");
            EndContext();
#line 10 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
         if (Model.Type == "text")
        {
            using (Html.BeginForm("SaveTextBookChanges", "ManageModel"))
            {
                

#line default
#line hidden
            BeginContext(398, 43, false);
#line 14 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
           Write(Html.EditorFor(b => b.TextBookPresentation));

#line default
#line hidden
            EndContext();
            BeginContext(443, 83, true);
            WriteLiteral("                <br />\r\n                <input type=\"submit\" value=\"Сохранить\" />\r\n");
            EndContext();
#line 17 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
            }
        }
        else if (Model.Type == "audio")
        {
            using (Html.BeginForm("SaveAudioBookChanges", "ManageModel"))
            {
                

#line default
#line hidden
            BeginContext(711, 44, false);
#line 23 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
           Write(Html.EditorFor(b => b.AudioBookPresentation));

#line default
#line hidden
            EndContext();
            BeginContext(757, 83, true);
            WriteLiteral("                <br />\r\n                <input type=\"submit\" value=\"Сохранить\" />\r\n");
            EndContext();
#line 26 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\EditBook.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(866, 34, true);
            WriteLiteral("        <br />\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookInputContainerViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
