using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TAVI_Pavlodar.Data;
using TAVI_Pavlodar.Model;

namespace TAVI_Pavlodar.Data
{
    public static class DataBaseInitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            // InitializerOfUsersAndRoles
            var userManager = scopeServiceProvider.GetService<UserManager<User>>();
            var roleManager = scopeServiceProvider.GetService<RoleManager<Role>>();
            var context = scopeServiceProvider.GetService<AplicationDbContext>();
            var roleAdmin = context.Roles.SingleOrDefault(x => x.Name.Equals("admin"));
            bool IsNeedCreateAdminRole = roleAdmin == null;
            var roleManager_ = context.Roles.SingleOrDefault(x => x.Name.Equals("Manager"));
            bool IsNeedCreateManagerRole = roleManager_ == null;
            var userRole = context.Roles.SingleOrDefault(x => x.Name.Equals("User"));
            bool IsNeedCreateUserRole = userRole == null;



            if (IsNeedCreateManagerRole)
            {
                Role newRole = new Role()
                {
                    Name = "Manager",
                    NormalizedName = "Мэнэджер"
                };
                roleManager.CreateAsync(newRole).GetAwaiter().GetResult();

                User newUser = new User
                {
                    FirstName = "Сергей",
                    LastName = "Мэнэджер",
                    UserName = "Manager"
                };
                newUser.Login = newUser.UserName;
                userManager.CreateAsync(newUser, "Managerrr").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(newUser, "Manager").GetAwaiter().GetResult();
            }

            if (IsNeedCreateUserRole)
            {
                Role newRole = new Role
                {
                    Name = "User",
                    NormalizedName = "Покупатель"
                };

                roleManager.CreateAsync(newRole).GetAwaiter().GetResult();
            }

            if (IsNeedCreateAdminRole)
            {
                Role newRole = new Role
                {
                    Name = "admin",
                    NormalizedName = "Админ"
                };

                roleManager.CreateAsync(newRole).GetAwaiter().GetResult();

                User newUser = new User
                {
                    FirstName = "Vladimir",
                    LastName = "Korobov",
                    UserName = "admin"
                };
                newUser.Login = newUser.UserName;
                userManager.CreateAsync(newUser, "adminnn").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(newUser, "admin").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(newUser, "Manager").GetAwaiter().GetResult();

                context.Baskets.Add(new Basket(newUser.Id.ToString()));
                context.SaveChanges();
            }

            // InitializerOfTypes

            string[] nameOfTypes = {
                "Paralon",
                "Laminat",
                "DSP",
            };

            bool IsNeed;
            var allTypes = context.Types;
            foreach (string el in nameOfTypes) //Исправить, не правильно работает, IsNeed не бывает Null
            {
                IsNeed = context.Types.SingleOrDefault(x => x.name.Equals(el)) == null;
                if (IsNeed)
                {
                    context.Types.Add(new ProductType
                    {
                        name = el
                    });
                    context.Products.Add(new Product
                    {
                        type = "Paralon",
                        desk = "Паралон",
                        parametr1 = "2250",
                        parametr2 = "80x2000x1500",
                        price = 4000,
                        avalib = 76,
                        typeId = 1
                    });
                }

                break;
            }

            //Initializ A Company Initializ A Company Initializ A Company Initializ A Company Initializ A Company

            Company company = new Company
            {
                Name = "ТАВИ Павлодар",
                Adress = "Пригородная 1А",
                PhoneNumber1 = "8-(707)-640-56-99",
                PhoneNumber2 = "8-(000)-012-34-56",
                Desk = "одна из самых крупных фирм, производящих все составляющие для мебели.У нас вы можете найти абсолютно все, начиная от Ламината,заканчивая шурупами и мелкими кронштейнами, а так же ткани и матрацы."
            };
            context.Company.Add(company);

            context.SaveChanges();
        }
    }
}
