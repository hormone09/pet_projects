#pragma checksum "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "527e7746de9a0f61c4d7e08a343e605ddaa7493a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Group), @"mvc.1.0.view", @"/Views/Teacher/Group.cshtml")]
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
#line 1 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\_ViewImports.cshtml"
using Portal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\_ViewImports.cshtml"
using Portal.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"527e7746de9a0f61c4d7e08a343e605ddaa7493a", @"/Views/Teacher/Group.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7d9bd9fad73cef45371cf285281d8f480d65294", @"/Views/Teacher/_ViewImports.cshtml")]
    public class Views_Teacher_Group : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeacherGroupViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
  
    Layout = "~/Views/Shared/_TeacherLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div class=\"flex-box course-header\">\r\n");
#nullable restore
#line 9 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
         if (Model.IsHasGroup)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"width: 30%;\">\r\n                <h3><span>Название группы:</span> ");
#nullable restore
#line 12 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                             Write(Model.groupName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h3><span>Количество студентов:</span> ");
#nullable restore
#line 13 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(Model.numbersStudents);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </div>\r\n            <div style=\"width: 50%;\">\r\n                <h3>Студенты в вашей группе:</h3>\r\n");
#nullable restore
#line 17 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                 foreach (var student in Model.students)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Имя: ");
#nullable restore
#line 19 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                       Write(student.name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                     Write(student.sename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 20 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 22 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n            <div class=\"container\">\r\n");
#nullable restore
#line 25 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                 if (Model.IsHasGroup)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div>\r\n");
#nullable restore
#line 28 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                     if (Model.IsGroupHasShledue)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3>Расписание</h3>\r\n                        <div>\r\n                            <h3><span>Числитель:</span></h3>\r\n");
#nullable restore
#line 33 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                             if (Model.numerator != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"flex-box\">\r\n");
#nullable restore
#line 36 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                     foreach (var day in Model.numerator.days)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div>\r\n                                            <h4>");
#nullable restore
#line 39 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                           Write(day.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                            <p><span>");
#nullable restore
#line 40 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                Write(day.firstCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                                            <p>Начало: ");
#nullable restore
#line 41 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.firstTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>");
#nullable restore
#line 42 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                          Write(day.secondCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>Начало: ");
#nullable restore
#line 43 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.secondTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>");
#nullable restore
#line 44 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                          Write(day.thirdCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>Начало: ");
#nullable restore
#line 45 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.thirdTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </div>\r\n");
#nullable restore
#line 47 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
#nullable restore
#line 49 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4>Расписание пока не заданно куратором!</h4>\r\n");
#nullable restore
#line 53 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <div>\r\n                            <h3><span>Знаменатель:</span></h3>\r\n");
#nullable restore
#line 57 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                             if (Model.denominator != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"flex-box\">\r\n");
#nullable restore
#line 60 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                     foreach (var day in Model.numerator.days)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div>\r\n                                            <h4>");
#nullable restore
#line 63 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                           Write(day.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                            <p><span>");
#nullable restore
#line 64 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                Write(day.firstCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                                            <p>Начало: ");
#nullable restore
#line 65 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.firstTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>");
#nullable restore
#line 66 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                          Write(day.secondCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>Начало: ");
#nullable restore
#line 67 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.secondTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>");
#nullable restore
#line 68 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                          Write(day.thirdCourseName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                            <p>Начало: ");
#nullable restore
#line 69 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                                  Write(day.thirdTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </div>\r\n");
#nullable restore
#line 71 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n");
#nullable restore
#line 73 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4>Расписание пока не заданно куратором!</h4>\r\n");
#nullable restore
#line 77 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n");
#nullable restore
#line 79 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                    }
                    else
                    {
                        if (Model.denominator != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>Знаменатель задан</h3>\r\n");
#nullable restore
#line 85 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                        }
                        else if(Model.numerator != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h3>Чилстиель задан!</h3>\r\n");
#nullable restore
#line 89 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <h3>Задайте расписание вашей группы:</h3>
                        <a href=""#"" onclick=""edit('NForm', 5)"">Числитель</a>
                        <a href=""#"" onclick=""edit('DForm', 6)"">Знаменатель</a>
                        <form id=""NForm"" class=""hiddenForm"" action=""/Teacher/AddSchedule"" method=""post"">
                            <div class=""flex-box"">
");
#nullable restore
#line 95 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                 for (int i = 0; i < 6; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <p><span>");
#nullable restore
#line 98 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                            Write(Model.nameOfDays[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                                        <p>Первая пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 4671, "\"", 4693, 3);
            WriteAttributeValue("", 4678, "subjects[", 4678, 9, true);
#nullable restore
#line 100 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 4687, i, 4687, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4689, "][0]", 4689, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 4694, "\"", 4702, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало первой пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 4856, "\"", 4874, 3);
            WriteAttributeValue("", 4863, "time[", 4863, 5, true);
#nullable restore
#line 102 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 4868, i, 4868, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4870, "][0]", 4870, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 4875, "\"", 4883, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 4884, "\"", 4898, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <p>Вторая пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 5025, "\"", 5047, 3);
            WriteAttributeValue("", 5032, "subjects[", 5032, 9, true);
#nullable restore
#line 105 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 5041, i, 5041, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5043, "][1]", 5043, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5048, "\"", 5056, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало второй пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 5210, "\"", 5228, 3);
            WriteAttributeValue("", 5217, "time[", 5217, 5, true);
#nullable restore
#line 107 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 5222, i, 5222, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5224, "][1]", 5224, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5229, "\"", 5237, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 5238, "\"", 5252, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <p>Третья пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 5379, "\"", 5401, 3);
            WriteAttributeValue("", 5386, "subjects[", 5386, 9, true);
#nullable restore
#line 110 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 5395, i, 5395, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5397, "][2]", 5397, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5402, "\"", 5410, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало третьей пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 5565, "\"", 5583, 3);
            WriteAttributeValue("", 5572, "time[", 5572, 5, true);
#nullable restore
#line 112 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 5577, i, 5577, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5579, "][2]", 5579, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5584, "\"", 5592, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 5593, "\"", 5607, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <input type=\"hidden\" name=\"IsNumerator\" value=\"true\" />\r\n                                    </div>\r\n");
#nullable restore
#line 116 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <button>Задать</button>
                        </form>
                        <form id=""DForm"" class=""hiddenForm"" action=""/Teacher/AddSchedule"" method=""post"">
                            <div class=""flex-box"">
");
#nullable restore
#line 122 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                 for (int i = 0; i < 6; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <p><span>");
#nullable restore
#line 125 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                            Write(Model.nameOfDays[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n                                        <p>Первая пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 6412, "\"", 6434, 3);
            WriteAttributeValue("", 6419, "subjects[", 6419, 9, true);
#nullable restore
#line 127 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 6428, i, 6428, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6430, "][0]", 6430, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6435, "\"", 6443, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало первой пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 6597, "\"", 6615, 3);
            WriteAttributeValue("", 6604, "time[", 6604, 5, true);
#nullable restore
#line 129 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 6609, i, 6609, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6611, "][0]", 6611, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6616, "\"", 6624, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 6625, "\"", 6639, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <p>Вторая пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 6766, "\"", 6788, 3);
            WriteAttributeValue("", 6773, "subjects[", 6773, 9, true);
#nullable restore
#line 132 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 6782, i, 6782, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6784, "][1]", 6784, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6789, "\"", 6797, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало второй пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 6951, "\"", 6969, 3);
            WriteAttributeValue("", 6958, "time[", 6958, 5, true);
#nullable restore
#line 134 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 6963, i, 6963, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6965, "][1]", 6965, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6970, "\"", 6978, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 6979, "\"", 6993, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <p>Третья пара:</p>\r\n                                        <input type=\"text\"");
            BeginWriteAttribute("name", " name=\"", 7120, "\"", 7142, 3);
            WriteAttributeValue("", 7127, "subjects[", 7127, 9, true);
#nullable restore
#line 137 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 7136, i, 7136, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7138, "][2]", 7138, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 7143, "\"", 7151, 0);
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Предмет\" />\r\n                                        <p>Начало третьей пары:</p>\r\n                                        <input type=\"time\"");
            BeginWriteAttribute("name", " name=\"", 7306, "\"", 7324, 3);
            WriteAttributeValue("", 7313, "time[", 7313, 5, true);
#nullable restore
#line 139 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
WriteAttributeValue("", 7318, i, 7318, 2, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7320, "][2]", 7320, 4, true);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 7325, "\"", 7333, 0);
            EndWriteAttribute();
            BeginWriteAttribute("placeholder", " placeholder=\"", 7334, "\"", 7348, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                                        <input type=\"hidden\" name=\"IsNumerator\" value=\"false\" />\r\n                                    </div>\r\n");
#nullable restore
#line 143 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                            <button>Задать</button>\r\n                        </form>\r\n");
#nullable restore
#line 147 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 149 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>Вы пока не назначены куратором!</p>\r\n");
#nullable restore
#line 153 "C:\Users\Владимир\Desktop\Заходи сюда чаще\Заходи сюда чаще\C#\VS\Portal\Portal\Views\Teacher\Group.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeacherGroupViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
