#pragma checksum "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\DeleteGenre.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46a5ed4f08fa7b5d7fac5cb9c3d49b6e3905cda1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ManageModel_DeleteGenre), @"mvc.1.0.view", @"/Views/ManageModel/DeleteGenre.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ManageModel/DeleteGenre.cshtml", typeof(AspNetCore.Views_ManageModel_DeleteGenre))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46a5ed4f08fa7b5d7fac5cb9c3d49b6e3905cda1", @"/Views/ManageModel/DeleteGenre.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2db0b02799d3f434a95101a7f3fa614f7032c356", @"/Views/_ViewImports.cshtml")]
    public class Views_ManageModel_DeleteGenre : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DeleteGenreViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\DeleteGenre.cshtml"
  
    ViewData["Title"] = "DeleteGenre";
    Layout = "~/Views/Shared/_CustomLayout.cshtml";

#line default
#line hidden
            BeginContext(129, 104, true);
            WriteLiteral("\r\n<div class=\"billetWrapper\">\r\n    <div class=\"full_article_container\">\r\n        <h2>Удалить жанр</h2>\r\n");
            EndContext();
#line 10 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\DeleteGenre.cshtml"
         using (Html.BeginForm("DeleteGenre", "ManageModel"))
        {
            

#line default
#line hidden
            BeginContext(320, 56, false);
#line 12 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\DeleteGenre.cshtml"
       Write(Html.DropDownListFor(g => g.GenreName, Model.GenreNames));

#line default
#line hidden
            EndContext();
            BeginContext(378, 79, true);
            WriteLiteral("            <br /><br />\r\n            <input type=\"submit\" value=\"Удалить\" />\r\n");
            EndContext();
#line 15 "C:\Users\Yurets\source\repos\LibraryMvcCore\LibraryMvcCore\Views\ManageModel\DeleteGenre.cshtml"
        }

#line default
#line hidden
            BeginContext(468, 36, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DeleteGenreViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591