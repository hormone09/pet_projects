#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb83dfd846bdff5f92b079acd74d3920926eb42d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowOrders), @"mvc.1.0.view", @"/Views/Home/ShowOrders.cshtml")]
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
#line 1 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\_ViewImports.cshtml"
using TAVI_Pavlodar.Model.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\_ViewImports.cshtml"
using TAVI_Pavlodar.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb83dfd846bdff5f92b079acd74d3920926eb42d", @"/Views/Home/ShowOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2312deb65d56dd5c20838d81dd1f5625e120363", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Purchase>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 4 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
     if (Model.Count < 1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>Пока нет ни одного заказа!</h1>\r\n");
#nullable restore
#line 7 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"orders\">\r\n            <h4>Активные заказы на нашем сайте</h4>\r\n");
#nullable restore
#line 12 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
             foreach (Purchase pr in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n                    <p><b>Дата совершения заказа:</b> ");
#nullable restore
#line 15 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
                                                 Write(pr.timeOfPurchaes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p><b>Статус:</b> ");
#nullable restore
#line 16 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
                                 Write(pr.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("                    <p><b>Стоимость:</b> ");
#nullable restore
#line 23 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
                                    Write(pr.finalyPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb83dfd846bdff5f92b079acd74d3920926eb42d6206", async() => {
                WriteLiteral("\r\n                        <button>Подробнее</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 28 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
                
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 31 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowOrders.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Purchase>> Html { get; private set; }
    }
}
#pragma warning restore 1591
