#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4088329348f674d77f73f56171b47dc814e1aec"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Common_Person), @"mvc.1.0.view", @"/Views/Common/Person.cshtml")]
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
#line 1 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
using Portal.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4088329348f674d77f73f56171b47dc814e1aec", @"/Views/Common/Person.cshtml")]
    public class Views_Common_Person : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PersonViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <p>Имя: ");
#nullable restore
#line 5 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
       Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Возраст: ");
#nullable restore
#line 6 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
           Write(Model.age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Группа: ");
#nullable restore
#line 7 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
          Write(Model.groupName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Количество курсов: ");
#nullable restore
#line 8 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
                     Write(Model.coursesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <form action=\"/Student/AddFriend\" method=\"post\">\r\n        <button>Добавить в друзья</button>\r\n        <input type=\"hidden\" name=\"studentNumber\"");
            BeginWriteAttribute("value", " value=\"", 364, "\"", 381, 1);
#nullable restore
#line 11 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Common\Person.cshtml"
WriteAttributeValue("", 372, Model.id, 372, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </form>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PersonViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
