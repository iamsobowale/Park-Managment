#pragma checksum "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Park\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8dc0274ef431ab9e9fda8c2ed95e8793ade8d754"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Park_Get), @"mvc.1.0.view", @"/Views/Park/Get.cshtml")]
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
#line 1 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\_ViewImports.cshtml"
using ParkManagment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\_ViewImports.cshtml"
using ParkManagment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dc0274ef431ab9e9fda8c2ed95e8793ade8d754", @"/Views/Park/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da6afb13f6489435bb5cbf53002e1ff01204f83", @"/Views/_ViewImports.cshtml")]
    public class Views_Park_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkManagment.DTOs.Park.ParkDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>Id</th>\r\n            <th>Name</th>\r\n            <th>Price</th>\r\n            <th>Description</th>\r\n        </tr>\r\n        <tr>\r\n            <td>");
#nullable restore
#line 12 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Park\Get.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 13 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Park\Get.cshtml"
           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 14 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Park\Get.cshtml"
           Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 15 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Park\Get.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkManagment.DTOs.Park.ParkDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
