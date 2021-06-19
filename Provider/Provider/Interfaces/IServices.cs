using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Interfaces
{
    enum ServiceTypes { Internet, Phone, Balance, NewUsers }
    public interface IServices
    {
        public string GetInternetRates();
        public string GetTelephoneRates();
        public string GetServices(string serviceType);
        public bool NewApplicate(Applicate applicate);
        public bool NewUserApplicate(NewUserApplicate applicate);
        public string GetUserData(Guid userId);
    }
}
