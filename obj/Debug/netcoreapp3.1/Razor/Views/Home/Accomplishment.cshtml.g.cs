#pragma checksum "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab2c03ff751ac181af6fa9b6b120757c77e5db20"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Accomplishment), @"mvc.1.0.view", @"/Views/Home/Accomplishment.cshtml")]
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
#line 1 "C:\Users\holli\Desktop\LearnSpace\Views\_ViewImports.cshtml"
using LearnSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\holli\Desktop\LearnSpace\Views\_ViewImports.cshtml"
using LearnSpace.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab2c03ff751ac181af6fa9b6b120757c77e5db20", @"/Views/Home/Accomplishment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc7718078fe7e31dc6fc777ff2b2469e2c917ac1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Accomplishment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Accomplishment>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab2c03ff751ac181af6fa9b6b120757c77e5db203244", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css"" integrity=""sha512-HK5fgLBL+xu6dm/Ii3z4xhlSUyZgTT9tuc/hSrtw6uzJOvgRr2a9jyxxT1ely+B+xFAmJKVSTbpM/CuL7qxO8w=="" crossorigin=""anonymous"" />
    <link rel=""stylesheet"" href=""css/utilities.css"">
    <link rel=""stylesheet"" href=""css/style.css"">
    <title>LearnSpace | Dashboard</title>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab2c03ff751ac181af6fa9b6b120757c77e5db204790", async() => {
                WriteLiteral("\r\n\r\n    <a href=\"/newaccomplishment\">Add A Accomplishment</a>\r\n");
                WriteLiteral("<div>\r\n    <h1>Celebrate your Accomplishments!</h1>\r\n                <p>Name</p>\r\n                <p>Accomplishment Level</p>\r\n                <p>Accomplishment Description</p>\r\n\r\n");
#nullable restore
#line 23 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
             foreach (var accomplish in Model)
            { 

#line default
#line hidden
#nullable disable
                WriteLiteral("                <section> \r\n                    <div>");
#nullable restore
#line 26 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
                    Write(accomplish.AccomplishmentName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                    <div>");
#nullable restore
#line 27 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
                    Write(accomplish.AccomplishmentType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                    <div>");
#nullable restore
#line 28 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
                    Write(accomplish.AccomplishmentDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                    <div>");
#nullable restore
#line 29 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
                    Write(accomplish.UserId);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                </section>\r\n                <hr>\r\n");
#nullable restore
#line 32 "C:\Users\holli\Desktop\LearnSpace\Views\Home\Accomplishment.cshtml"
               
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n</div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Accomplishment>> Html { get; private set; }
    }
}
#pragma warning restore 1591