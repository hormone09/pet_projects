using System;
using Microsoft.AspNetCore.Identity;

namespace Provider.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Sename { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool IsHasRate { get; set; }
        public bool IsHasServices { get; set; }
        public string RateName { get; set; }
    }
}
