#pragma checksum "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfc04115d83c9c41d5ab1ea727019788c6fc537d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Home), @"mvc.1.0.view", @"/Views/Home/Home.cshtml")]
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
#nullable restore
#line 1 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\_ViewImports.cshtml"
using PLC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\_ViewImports.cshtml"
using PLC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfc04115d83c9c41d5ab1ea727019788c6fc537d", @"/Views/Home/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"318532a94475871999cf0daac7885af11a7118fa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
  
    ViewData["Title"] = "Home";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
  
    var _token = Context.Request.Query["_token"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Home</h1>\r\n\r\n");
#nullable restore
#line 12 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
  
    if (_token.Equals("404"))
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
   Write(Html.Partial("~/Views/Login/AdminNotFound.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
                                                           
    if (_token.Equals("exception") || _token.Equals("error"))
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
   Write(Html.Partial("~/Views/Login/AdminNotFound.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
                                                           
    if (string.IsNullOrEmpty(_token))
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
   Write(Html.Partial("~/Views/Login/SessionInvalida.cshtml"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
                                                             
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>Hello</h3>\r\n        <p>Welcome to Dashboard render partial view</p>\r\n");
#nullable restore
#line 23 "C:\CMSEncuestas.Net\CMSEncuestas\PLC\Views\Home\Home.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
