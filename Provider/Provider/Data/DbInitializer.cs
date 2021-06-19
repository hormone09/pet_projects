using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Data
{
    public static class DbInitializer
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();

            bool IsHasAdminRole = roleManager.FindByNameAsync("admin").GetAwaiter().GetResult() != null;
            bool IsHasUserRole = roleManager.FindByNameAsync("user").GetAwaiter().GetResult() != null;
            bool IsHasAdmin = userManager.FindByNameAsync("admin_admin").GetAwaiter().GetResult() != null;

            if (!IsHasAdminRole)
            {
                Role newRole = new Role
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };

                roleManager.CreateAsync(newRole).GetAwaiter().GetResult();
            }

            if (!IsHasUserRole)
            {
                Role newRole = new Role
                {
                    Name = "user",
                    NormalizedName = "USER"
                };

                roleManager.CreateAsync(newRole).GetAwaiter().GetResult();
            }

            if(!IsHasAdmin)
            {
                User newUser = new User
                {
                    UserName = "_Ruslan_",
                    Name = "Руслан",
                    Sename = "Каппасов",
                    FullName = "Руслан Каппасов",
                    Age = 19,
                    Email = "kapassow09@mail.ru",
                    IsHasRate = false,
                    IsHasServices = false
                };

                userManager.CreateAsync(newUser, "admin_admin").GetAwaiter().GetResult();
                var user = userManager.FindByNameAsync("_Ruslan_").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(user, "admin").GetAwaiter().GetResult();
            }

            context.SaveChanges();
        }
    }
}
