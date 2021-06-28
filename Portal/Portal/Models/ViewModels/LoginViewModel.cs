using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class LoginViewModel
    {
        public string login { get; set; }

        public string password { get; set; }

        public string validatorForLogin = "";

        public string validatorForPassword = "";
    }
}
