using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class UserImage
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fullPuth { get; set; }
        public Guid userId { get; set; }
    }
}
