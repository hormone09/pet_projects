#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a34cf99533fa11f5151812d240c156788cd667cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowAllLoadings), @"mvc.1.0.view", @"/Views/Home/ShowAllLoadings.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a34cf99533fa11f5151812d240c156788cd667cd", @"/Views/Home/ShowAllLoadings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2312deb65d56dd5c20838d81dd1f5625e120363", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowAllLoadings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Loading>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
   Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n        <h4>Планируемые загрузки товара на сегодняшнее число (");
#nullable restore
#line 6 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                                                         Write(DateTime.Now.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h4>
        <div class=""LoadingRow"">
            <div class=""TimeColumn"">
               <h3>Время планируемой загрузки. </h3>
            </div>
            <div class=""NameColumn"">
                <h3>Имя клиента, автомобиль</h3>
            </div>
            <div class=""TypesColumn"">
                <h3>Загружаемый товар</h3>
            </div>
            <div class=""IntervalColumn"">
               <h3>Примерное время загрузки</h3>
            </div>
        </div>
");
#nullable restore
#line 21 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
         foreach (var el in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"LoadingRow\">\r\n\r\n                <div class=\"TimeColumn\">\r\n                    <p>");
#nullable restore
#line 26 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                  Write(el.TimeForLoading.Hour);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 26 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                                            Write(el.TimeForLoading.Minute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n\r\n                <div class=\"NameColumn\">\r\n                    <p>");
#nullable restore
#line 30 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                  Write(el.FullnameOfUser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n\r\n                <div class=\"TypesColumn\">\r\n");
#nullable restore
#line 34 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                     foreach(var type in el.Products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p>Товар/количесвто: ");
#nullable restore
#line 36 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                                        Write(type.desk);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 36 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                                                   Write(type.amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 37 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n                <div class=\"IntervalColumn\">\r\n                    <p>Загрузка займет около: ");
#nullable restore
#line 41 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
                                         Write(el.MinutesForLoading);

#line default
#line hidden
#nullable disable
            WriteLiteral(" минут</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 44 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Tavi_Pavlodar\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\ShowAllLoadings.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Loading>> Html { get; private set; }
    }
}
#pragma warning restore 1591
