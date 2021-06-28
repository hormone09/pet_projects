using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class RegisterViewModel : NewPersonViewModel
    {
        public string login { get; set; }
        public string password { get; set; }
        public string password2 { get; set; }
        public string personalUrl { get; set; }

        public RegisterViewModel() { }

        public RegisterViewModel(RegistrationApplication application)
        {
            personalUrl = application.id;
            name = application.name;
            sename = application.sename;
            email = application.email;
            birthday = application.birthday;
            IsTeacher = application.IsTeacher;
        }
    }
}
