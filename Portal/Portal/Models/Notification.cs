using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string head { get; set; }
        public string message { get; set; }
        public DateTime time { get; set; }
        public bool IsChecked { get; set; }
        public Guid personalNumber { get; set; }

        public Notification() { }
        public Notification(string head, string message, string personalNumber)
        {
            this.head = head;
            this.message = message;
            this.personalNumber = Guid.Parse(personalNumber);
            time = DateTime.Now;
            IsChecked = false;
        }
    }
}
