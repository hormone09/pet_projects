#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce5805e11eba02a9784d8c09eeaeb1e0cbce3214"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
#line 1 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
using Portal.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce5805e11eba02a9784d8c09eeaeb1e0cbce3214", @"/Views/Account/Register.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegisterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
  
    Layout = "~/Views/Shared/_Clear.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<form style=\"width: 500px; height: 500px;\" action=\"/Account/Register\" method=\"post\">\r\n\r\n    <h1>Регистрация</h1>\r\n    <div class=\"info\">\r\n        <p><span>Имя:</span> ");
#nullable restore
#line 12 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
                        Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Фамилия:</span> ");
#nullable restore
#line 13 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
                            Write(Model.sename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p><span>Почтовый адресс:</span>  ");
#nullable restore
#line 14 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
                                     Write(Model.email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <input type=\"hidden\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 462, "\"", 481, 1);
#nullable restore
#line 16 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
WriteAttributeValue("", 470, Model.name, 470, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    <input type=\"hidden\" name=\"sename\"");
            BeginWriteAttribute("value", " value=\"", 524, "\"", 545, 1);
#nullable restore
#line 17 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
WriteAttributeValue("", 532, Model.sename, 532, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n    <input type=\"hidden\" name=\"email\"");
            BeginWriteAttribute("value", " value=\"", 587, "\"", 607, 1);
#nullable restore
#line 18 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
WriteAttributeValue("", 595, Model.email, 595, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"/>
    <input class=""user"" type=""text"" name=""login"" placeholder=""логин"" />
    <input class=""pass"" type=""password"" name=""password"" placeholder=""пароль"" />
    <input class=""pass"" type=""password"" name=""password2"" placeholder=""повторите пароль"" />
    <input type=""hidden"" name=""personalUrl""");
            BeginWriteAttribute("value", " value=", 901, "", 926, 1);
#nullable restore
#line 22 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Account\Register.cshtml"
WriteAttributeValue("", 908, Model.personalUrl, 908, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n    <input class=\"btn\" type=\"submit\" value=\"ВОЙТИ\" />\r\n\r\n    <hr style=\"background-color : #bebebe;\" />\r\n    <hr style=\"background-color : #FFF; \" />\r\n</form>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
