#pragma checksum "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60bdea4d9113087be67f417053c6d94689252588"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Logs_Pages_System_Details), @"mvc.1.0.razor-page", @"/Areas/Logs/Pages/System/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60bdea4d9113087be67f417053c6d94689252588", @"/Areas/Logs/Pages/System/Details.cshtml")]
    public class Areas_Logs_Pages_System_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
  
    ViewData["Title"] = "System Log";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>System Log ");
#nullable restore
#line 7 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
          Write(Model.Item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 7 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                           Write(Model.Item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<dl>\r\n    <dt>");
#nullable restore
#line 10 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 10 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                              Write(Html.DisplayFor(m=>Model.Item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 11 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.ActionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 11 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                      Write(Html.DisplayFor(m=>Model.Item.ActionType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 12 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Executed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 12 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                    Write(Html.DisplayFor(m=>Model.Item.Executed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 13 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.LogLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 13 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                    Write(Html.DisplayFor(m=>Model.Item.LogLevel));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 14 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Reference));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 14 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                     Write(Html.DisplayFor(m=>Model.Item.Reference));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 15 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 15 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                  Write(Html.DisplayFor(m=>Model.Item.Source));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <hr/>\r\n    <dt>");
#nullable restore
#line 17 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 17 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                   Write(Html.DisplayFor(m=>Model.Item.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n    <dt>");
#nullable restore
#line 18 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
   Write(Html.DisplayNameFor(m=>m.Item.Detail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt><dd>");
#nullable restore
#line 18 "D:\Source\Logger\ApenLogManager\Areas\Logs\Pages\System\Details.cshtml"
                                                  Write(Html.DisplayFor(m=>Model.Item.Detail));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApenLogManager.Logs.Pages.System.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ApenLogManager.Logs.Pages.System.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ApenLogManager.Logs.Pages.System.DetailsModel>)PageContext?.ViewData;
        public ApenLogManager.Logs.Pages.System.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591