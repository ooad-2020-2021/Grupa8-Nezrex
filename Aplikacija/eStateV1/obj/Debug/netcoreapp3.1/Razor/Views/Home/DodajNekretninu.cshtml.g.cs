#pragma checksum "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67726e66aedadba83388f4956d5eb1884d6273d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DodajNekretninu), @"mvc.1.0.view", @"/Views/Home/DodajNekretninu.cshtml")]
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
#line 1 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\_ViewImports.cshtml"
using eStateV1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\_ViewImports.cshtml"
using eStateV1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67726e66aedadba83388f4956d5eb1884d6273d2", @"/Views/Home/DodajNekretninu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45e5423fc1d652033b2d023e208e72a78a92ec48", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DodajNekretninu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
  
    ViewData["Title"] = "DodajNekretninu";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>DodajNekretninu</h1>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
 if (SignInManager.IsSignedIn(User))
{

    List<SelectListItem> items = new List<SelectListItem>();

    items.Add(new SelectListItem { Text = "Stan", Value = "0" });

    items.Add(new SelectListItem { Text = "Vikendica", Value = "1" });

    items.Add(new SelectListItem { Text = "Zemljište", Value = "2" });

    items.Add(new SelectListItem { Text = "Kuća", Value = "3" });

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
     using (Html.BeginForm("Rutiraj", "Home", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
   Write(Html.DropDownList("vrsta", items));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"submit\" value=\"Submit\" />\r\n");
#nullable restore
#line 29 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\Korisnik\Desktop\OOAD PROJEKAT\Grupa8-Nezrex\Aplikacija\eStateV1\Views\Home\DodajNekretninu.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Korisnik> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<Korisnik> SignInManager { get; private set; }
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
