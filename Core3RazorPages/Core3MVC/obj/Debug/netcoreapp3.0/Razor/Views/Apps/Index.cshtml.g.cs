#pragma checksum "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23b856d4a444669d9924f3a16874de3bb537f756"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Apps_Index), @"mvc.1.0.view", @"/Views/Apps/Index.cshtml")]
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
#line 1 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\_ViewImports.cshtml"
using Core3MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\_ViewImports.cshtml"
using Core3MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23b856d4a444669d9924f3a16874de3bb537f756", @"/Views/Apps/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58a7958647e95a68f6cfad633d126c7c6b80b9bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Apps_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Core3MVC.Models.App>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline ml-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Alerts2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23b856d4a444669d9924f3a16874de3bb537f7564882", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Html.DisplayNameFor(model => model[0].MonAlertsID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Html.DisplayNameFor(model => model[0].AppName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Html.DisplayNameFor(model => model[0].AlertType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Html.DisplayNameFor(model => model[0].Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
 for (int i= 0;i< Model.Count();i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Model[i].AppName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Model[i].MonAlertsID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
           Write(Model[i].AlertType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n    <td>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23b856d4a444669d9924f3a16874de3bb537f7568605", async() => {
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"AppName\"");
                BeginWriteAttribute("value", " value=\"", 1093, "\"", 1118, 1);
#nullable restore
#line 45 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
WriteAttributeValue("", 1101, Model[i].AppName, 1101, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <input type=\"hidden\" name=\"MonAlertsID\"");
                BeginWriteAttribute("value", " value=\"", 1175, "\"", 1204, 1);
#nullable restore
#line 46 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
WriteAttributeValue("", 1183, Model[i].MonAlertsID, 1183, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 47 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
             if (@Model[i].Active)
            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" name=\"changetoinactive\" class=\"btn btn-success btn-raised btn-fab btn-fab-mini btn-round\">\r\n\r\n                    <i class=\"material-icons\">done</i>\r\n                </button>\r\n");
#nullable restore
#line 54 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
             if (!@Model[i].Active)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <button type=\"submit\" name=\"notactive\" id=\"notactive\" class=\"btn btn-danger btn-raised btn-fab btn-fab-mini btn-round\">\r\n                    <i class=\"material-icons\">clear</i>\r\n                </button>\r\n");
#nullable restore
#line 60 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n       \r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("    </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "C:\Workspace\aspcore3Practice\Core3RazorPages\Core3MVC\Views\Apps\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(" \r\n<style>\r\n    select {\r\n    width: 100px !important;\r\n    word-wrap: break-word;\r\n}\r\n\r\n/*#meselectt option {\r\n    background-color:yellow;\r\n    width: 100px ;\r\n    word-wrap: break-word;\r\n}*/\r\n</style>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Core3MVC.Models.App>> Html { get; private set; }
    }
}
#pragma warning restore 1591