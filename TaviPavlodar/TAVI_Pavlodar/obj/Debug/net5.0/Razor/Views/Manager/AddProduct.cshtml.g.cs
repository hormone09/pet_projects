#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Manager\AddProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89aec04ad42af2793820bf2899744298c5000b57"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_AddProduct), @"mvc.1.0.view", @"/Views/Manager/AddProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89aec04ad42af2793820bf2899744298c5000b57", @"/Views/Manager/AddProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2312deb65d56dd5c20838d81dd1f5625e120363", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_AddProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductType>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("typeId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("AddProduct"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"container\">\r\n        <h1>Добавление нового товара: </h1>\r\n        <div class=\"AddProduct\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89aec04ad42af2793820bf2899744298c5000b574722", async() => {
                WriteLiteral("\r\n                <div>\r\n                    <p>Укажите тип продукта: </p>\r\n                    <select name=\"typeId\" size=\"1\">\r\n                        \r\n");
#nullable restore
#line 11 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Manager\AddProduct.cshtml"
                         foreach (var el in Model)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89aec04ad42af2793820bf2899744298c5000b575516", async() => {
#nullable restore
#line 13 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Manager\AddProduct.cshtml"
                                                            Write(el.normalName);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 13 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Manager\AddProduct.cshtml"
                                             WriteLiteral(el.id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Manager\AddProduct.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </select>\r\n                </div>\r\n                <div>\r\n                    <p> Укажите название товара:</p>\r\n                    <input type=\"text\" name=\"desk\"");
                BeginWriteAttribute("value", " value=\"", 722, "\"", 730, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div>\r\n                    <p> Укажите параметр 1, название параметра, двоиточие, затем само значение</p>\r\n                    <input type=\"text\" name=\"parametr1\"");
                BeginWriteAttribute("value", " value=\"", 938, "\"", 946, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div>\r\n                    <p> Укажите параметр 2, название параметра, двоиточие, затем само значение</p>\r\n                    <input type=\"text\" name=\"parametr2\"");
                BeginWriteAttribute("value", " value=\"", 1154, "\"", 1162, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div>\r\n                    <p> Укажите стоимость</p>\r\n                    <input type=\"text\" name=\"price\"");
                BeginWriteAttribute("value", " value=\"", 1313, "\"", 1321, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <div>\r\n                    <p> Укажите количество заданного товара на складе</p>\r\n                    <input type=\"text\" name=\"avalib\"");
                BeginWriteAttribute("value", " value=\"", 1501, "\"", 1509, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n                <button type=\"submit\">Добавить</button>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductType>> Html { get; private set; }
    }
}
#pragma warning restore 1591
