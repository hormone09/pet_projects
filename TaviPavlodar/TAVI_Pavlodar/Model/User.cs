using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TAVI_Pavlodar.Data;

namespace TAVI_Pavlodar.Model
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Product> FavoriteProducts { get; set; }
    }
}
