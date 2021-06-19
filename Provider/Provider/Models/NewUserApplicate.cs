using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Models
{
    public class NewUserApplicate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sename { get; set; }
        public string Phone { get; set; }
        public string PersonalNumber { get; set; }
    }
}
