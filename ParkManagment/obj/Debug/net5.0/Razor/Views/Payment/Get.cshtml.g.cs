#pragma checksum "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c972f13fb9b29af811c5c0d158cd83ed9b04bff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_Get), @"mvc.1.0.view", @"/Views/Payment/Get.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c972f13fb9b29af811c5c0d158cd83ed9b04bff", @"/Views/Payment/Get.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4da6afb13f6489435bb5cbf53002e1ff01204f83", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment_Get : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ParkManagment.DTOs.Payment.PaymentDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div>
    <table class=""table"">
      <tr>
        <th>Id</th>
        <th>DayOfPayment</th>
        <th>Days Paid For</th>
        <th>Expire</th>
        <th>TotalPayment</th>
        <th>Vehicle Paid For</th>
      </tr>
      <tr>
        <td>");
#nullable restore
#line 13 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 14 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.DayOfPayment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 15 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.NumberOfDays);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 16 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.Expire);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 17 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.TotalPayment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 18 "C:\Users\user\RiderProjects\ParkManagment\ParkManagment\Views\Payment\Get.cshtml"
       Write(Model.MotorRegNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n      </tr>\r\n      <tr>\r\n      </tr>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ParkManagment.DTOs.Payment.PaymentDto> Html { get; private set; }
    }
}
#pragma warning restore 1591