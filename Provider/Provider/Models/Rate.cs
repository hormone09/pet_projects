using Provider.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Models
{
    public class Rate : ProviderService
    {
        public bool IsMoreInternet { get; set; }
        public int GigabyteCount { get; set; }
        public int MinuteCount { get; set; }
        public int SMSCount { get; set; }
    }
}
