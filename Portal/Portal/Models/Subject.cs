using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;

namespace Portal.Models
{
    public sealed class Subject
    {
        public int id { get; set; }
        public string heading { get; set; }
        public string task { get; set; }
        public Border border { get; set; }
        public List<Answer> answers { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public DateTime timeBorderForAnswer { get; set; }
        public bool IsExpired { get; set; }
        public bool IsFinished { get; set; }
        public bool IsToday { get; set; }
    }
}
