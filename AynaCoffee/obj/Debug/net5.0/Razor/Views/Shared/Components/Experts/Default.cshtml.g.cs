#pragma checksum "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e89d16a7b7973aa4c7a814c886ebde4388a10fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Experts_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Experts/Default.cshtml")]
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
#line 1 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\_ViewImports.cshtml"
using AynaCoffee;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\_ViewImports.cshtml"
using AynaCoffee.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
using AynaCoffee.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e89d16a7b7973aa4c7a814c886ebde4388a10fc", @"/Views/Shared/Components/Experts/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"333ce6cec5befb0984bc11992a555c5c0ded9e9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Experts_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AynaCoffee.Areas.Admin.ViewModels.ExpertsListViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container"">
    <div class=""row justify-content-center mb-5 pb-2"">
        <div class=""col-md-7 text-center heading-section ftco-animate"">
            <span class=""subheading"">Uzman</span>
            <h2 class=""mb-4"">Uzmanlarımız</h2>
        </div>
    </div>
    <div class=""row"">
");
#nullable restore
#line 12 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
         foreach (var expert in @Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-6 col-lg-3 ftco-animate\">\r\n                <div class=\"staff\">\r\n                    <div class=\"img\"");
            BeginWriteAttribute("style", " style=\"", 596, "\"", 654, 4);
            WriteAttributeValue("", 604, "background-image:", 604, 17, true);
            WriteAttributeValue(" ", 621, "url(", 622, 5, true);
#nullable restore
#line 16 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
WriteAttributeValue("", 626, expert.Content.Photo.Path, 626, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 652, ");", 652, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                    <div class=\"text pt-4\">\r\n                        <h3>");
#nullable restore
#line 18 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
                       Write(expert.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
                                    Write(expert.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <span class=\"position mb-2\">");
#nullable restore
#line 19 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
                                               Write(expert.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <p>");
#nullable restore
#line 20 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
                      Write(expert.Content.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 24 "D:\Archive\Backups\12.01.2021\Visual Studio Projects\source\repos\AynaCoffee\AynaCoffee\Views\Shared\Components\Experts\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AynaCoffee.Areas.Admin.ViewModels.ExpertsListViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
