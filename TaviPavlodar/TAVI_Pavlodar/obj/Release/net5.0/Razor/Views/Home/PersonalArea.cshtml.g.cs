#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\PersonalArea.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bffd76025e409f5ef013f1c2e346f3af4befe768"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PersonalArea), @"mvc.1.0.view", @"/Views/Home/PersonalArea.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bffd76025e409f5ef013f1c2e346f3af4befe768", @"/Views/Home/PersonalArea.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2312deb65d56dd5c20838d81dd1f5625e120363", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PersonalArea : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PersonalAreaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <h4>Ваш личный кабинет, ");
#nullable restore
#line 5 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\TAVI_Pavlodar with JS\TAVI_Pavlodar\Views\Home\PersonalArea.cshtml"
                       Write(Model.FullUserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
    <div class=""RowPersonalArea"">
        <a href=""/Home/ShowActiveUserOrders"">
            <div class=""ColumnPersonalArea"">
                <p>Активные заказы</p>
            </div>
        </a>

        <a href=""/Home/ShowFinishedOrders"">
            <div class=""ColumnPersonalArea"">
                <p>Завершенные заказы</p>
            </div>
        </a>

        <a href=""/Home/ShowUserInfo/"">
            <div class=""ColumnPersonalArea"">
                <p>Данные вашего аккаунта</p>
            </div>
        </a>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersonalAreaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
