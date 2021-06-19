using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Models
{
    public enum ApplicateTypes { ServiceConnection, RateConnection, ServiceDisconnect, RateDisconnect}
    public class Applicate
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NewServiceName { get; set; }
        public string ApplicateType { get; set; }
    }
}
