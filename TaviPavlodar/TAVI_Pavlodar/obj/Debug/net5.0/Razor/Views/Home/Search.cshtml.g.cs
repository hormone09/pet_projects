#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ff9d410a8f2446242952241537a10c0bf78c707"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
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
#line 1 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\_ViewImports.cshtml"
using TAVI_Pavlodar.Model.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\_ViewImports.cshtml"
using TAVI_Pavlodar.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ff9d410a8f2446242952241537a10c0bf78c707", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2312deb65d56dd5c20838d81dd1f5625e120363", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/AddToBasket/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div>\r\n        <h1>Продукты по запросу \"");
#nullable restore
#line 5 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                            Write(Model.search);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h1>\r\n");
#nullable restore
#line 6 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
         if (Model.products.Count > 0)
        {
            
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
             foreach (var el in Model.products)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""ColumnCurrentType"">
                        <div class=""Image"">
                            <img src=""https://i.ibb.co/cYdR098/Laminat.jpg"" alt=""Alternate Text"" />
                        </div>
                        <div class=""Text"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff9d410a8f2446242952241537a10c0bf78c7075401", async() => {
                WriteLiteral("\r\n                                <p>Название: ");
#nullable restore
#line 17 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                                        Write(el.desk);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 18 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                              Write(el.parametr1);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p>");
#nullable restore
#line 19 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                              Write(el.parametr2);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p>Цена: ");
#nullable restore
#line 20 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                                    Write(el.price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p>В наличии: ");
#nullable restore
#line 21 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
                                         Write(el.avalib);

#line default
#line hidden
#nullable disable
                WriteLiteral(" шт.</p>\r\n                                <p>Укажите количество товара для покупки: </p>\r\n                                <input name=\"amount\" value=\"1\">\r\n                                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=", 1091, "", 1104, 1);
#nullable restore
#line 24 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
WriteAttributeValue("", 1098, el.id, 1098, 6, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <input type=\"hidden\" name=\"type\"");
                BeginWriteAttribute("value", " value=", 1171, "", 1186, 1);
#nullable restore
#line 25 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
WriteAttributeValue("", 1178, el.type, 1178, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <button type=\"submit\">В корзину</button>\r\n                            ");
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
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 30 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Ничего нет</h1>\r\n");
#nullable restore
#line 35 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\Search.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    \r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
