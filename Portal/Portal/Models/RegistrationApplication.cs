using System;
using Portal.Models.ViewModels;

namespace Portal.Models
{
    public class RegistrationApplication : NewPersonViewModel
    {
        public string id { get; set; }

        public RegistrationApplication()
        {
            id = Guid.NewGuid().ToString();
        }

        public RegistrationApplication(NewPersonViewModel model)
        {
            id = Guid.NewGuid().ToString();
            name = model.name;
            sename = model.sename;
            email = model.email;
            birthday = model.birthday;
            IsTeacher = model.IsTeacher;
        }
    }
}
