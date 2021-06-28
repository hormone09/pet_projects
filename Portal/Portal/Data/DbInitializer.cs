using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Portal.Models;

namespace Portal.Data
{
    public static class DbInitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var context = scopeServiceProvider.GetRequiredService<AplicationDbContext>();
            var userManager = scopeServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scopeServiceProvider.GetRequiredService<RoleManager<Role>>();

            bool currentRoleIsNull = context.Roles.SingleOrDefault(x => x.Name.Equals("student")) == null;
            bool administrationRoleIsNull = context.Roles.SingleOrDefault(x => x.Name.Equals("administration")) == null;
            if (currentRoleIsNull)
            {
                Role roleStudent = new Role
                {
                    Name = "student",
                    NormalizedName = "студент",
                };
                Role roleTeacher = new Role
                {
                    Name = "teacher",
                    NormalizedName = "преподаватель",
                };
                Role roleAdministration = new Role
                {
                    Name = "administration",
                    NormalizedName = "администрация",
                };
                roleManager.CreateAsync(roleStudent).GetAwaiter().GetResult();
                roleManager.CreateAsync(roleTeacher).GetAwaiter().GetResult();
                roleManager.CreateAsync(roleAdministration).GetAwaiter().GetResult();
            }
            if(administrationRoleIsNull)
            {
                Role roleAdministration = new Role
                {
                    Name = "administration",
                    NormalizedName = "администрация",
                };
                roleManager.CreateAsync(roleAdministration).GetAwaiter().GetResult();
                User userAdmin = new User
                {
                    UserName = "CollegeAdministration",
                    IsTeacher = true,
                };
                userManager.CreateAsync(userAdmin, "admin123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(userAdmin, "administration").GetAwaiter().GetResult();
                Teacher adminTeacher = new Teacher()
                {
                    numberOfAccount = userAdmin.Id.ToString(),
                    name = "admin",
                    sename = " ",
                    IsHasGroup = false
                };
                context.teachers.Add(adminTeacher);
                context.SaveChanges();
            }

            bool currentUserIsNull = context.Users.SingleOrDefault(x => x.UserName.Equals("student")) == null;
            if(currentUserIsNull)
            {
                User userStudent = new User
                {
                    UserName = "student",
                    IsTeacher = false,
                };
                User userTeacher = new User
                {
                    UserName = "teacher",
                    IsTeacher = true,
                };

                userManager.CreateAsync(userStudent, "password123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(userStudent, "student").GetAwaiter().GetResult();

                userManager.CreateAsync(userTeacher, "password123").GetAwaiter().GetResult();
                userManager.AddToRoleAsync(userTeacher, "teacher").GetAwaiter().GetResult();

                var _student = userManager.FindByNameAsync("student").GetAwaiter().GetResult();
                var _student2 = userManager.FindByNameAsync("student2").GetAwaiter().GetResult();
                var _teacher = userManager.FindByNameAsync("teacher").GetAwaiter().GetResult();

                Student newStudent = new Student()
                {
                    numberOfAccount = _student.Id.ToString(),
                    name = "Владимир",
                    sename = "Коробов",
                    speciality = "Инженер Программист",
                    IsHasGroup = false,
                    dateOfRegister = DateTime.Now,
                    dateOfBirthday = DateTime.Parse("12.10.2001"),
                };

                Teacher newTeacher = new Teacher()
                {
                    numberOfAccount = _teacher.Id.ToString(),
                    name = "Александр",
                    sename = "Шилин",
                    IsHasGroup = false,
                    dateOfRegister = DateTime.Now,
                    dateOfBirthday = DateTime.Parse("15.01.1980"),
                };

                context.students.AddRange(newStudent);
                context.teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }
    }
}
