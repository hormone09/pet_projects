using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Interfaces
{
    public interface IUpdate
    {
        public string AddRate(Rate rate);
        public string AddService(Service service);
        public string Delete(int objectId, string objectType);
        public bool ConfirmApplicate(int applicateId);
        public string GetAllApplications();
        public bool DeleteApp(int applicateId, bool IsConnectApp);
    }
}
