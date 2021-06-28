using Microsoft.AspNetCore.Identity;
using Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class User : IdentityUser<Guid>
    {
        public bool IsTeacher { get; set; }
        public List<Notification> notifications { get; set; }
        public UserImage image { get; set; }
    }
}
