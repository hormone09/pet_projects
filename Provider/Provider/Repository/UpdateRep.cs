using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Provider.Data;
using Provider.Interfaces;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provider.Repository
{
    public class UpdateRep : IUpdate
    {
        private readonly ApplicationDbContext db;
        public UpdateRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string AddRate(Rate rate)
        {
            bool IsValid = Validate(rate);
            if (IsValid)
            {
                using (db)
                {
                    rate.NormalName = rate.Name.ToUpper();
                    bool IsHas = db.Rates.SingleOrDefault(x =>x.NormalName.Equals(rate.NormalName) 
                        || x.NumberForMobileConnection.Equals(rate.NumberForMobileConnection)) != null;

                    if (!IsHas)
                    {
                        rate.IsCanConnect = true;
                        db.Add(rate);
                        db.SaveChanges();
                        return "Succes";
                    }
                    else
                        return "Тариф с таким именем или командой уже есть!";
                }
            }
            else
                return "Поля заполнены неправильно!";
        }

        public string AddService(Service service)
        {
            bool IsValid = Validate(service);
            if (IsValid)
            {
                using (db)
                {
                    service.NormalName = service.Name.ToUpper();
                    bool IsHas = db.Rates.SingleOrDefault(x => x.NormalName.Equals(service.NormalName) 
                        || x.NumberForMobileConnection.Equals(service.NumberForMobileConnection)) != null;

                    if (!IsHas)
                    {
                        service.IsCanConnect = true;
                        db.Add(service);
                        db.SaveChanges();
                        return "Succes";
                    }
                    else
                        return "Тариф с таким именем уже есть!";
                }
            }
            else
                return "Поля заполнены неправильно!";
        }

        public string Delete(int objectId, string objectType)
        {
            if (objectType.Equals("service") || objectType.Equals("Service"))
            {
                using (db)
                {
                    var currentObj = db.Services.SingleOrDefault(x => x.Id == objectId);
                    if (currentObj != null)
                    {
                        db.Services.Remove(currentObj);
                        db.SaveChanges();

                        return "Удаленно!";
                    }
                    else
                        return "Не найдено!";
                }
            }
            else if (objectType.Equals("rate") || objectType.Equals("Rate"))
            {
                using (db)
                {
                    var currentObj = db.Rates.SingleOrDefault(x => x.Id == objectId);
                    if (currentObj != null)
                    {
                        db.Rates.Remove(currentObj);
                        db.SaveChanges();

                        return "Удаленно!";
                    }
                    else
                        return "Не найдено!";
                }
            }
            else
                return "Неправленье название типа!";
        }
       
        public bool ConfirmApplicate(int applicateId)
        {
            using (db)
            {
                var applicate = db.Applicates.Single(x => x.Id == applicateId);
                var user = db.Users.Single(x => x.UserName.Equals(applicate.UserName));
                if (applicate.ApplicateType.Equals(ApplicateTypes.RateConnection.ToString()))
                {
                    var rate = db.Rates.Single(x => x.NumberForMobileConnection.Equals(applicate.NewServiceName));
                    user.RateName = rate.Name;
                    user.IsHasRate = true;
                    db.Applicates.Remove(applicate);
                    db.SaveChanges();
                }
                else if(applicate.ApplicateType.Equals(ApplicateTypes.ServiceConnection.ToString()))
                {
                    var service = db.Services.Single(x => x.NumberForMobileConnection.Equals(applicate.NewServiceName));
                    user.IsHasServices = true;
                    db.UserServices.Add(new UserService
                    {
                        ServiceName = applicate.NewServiceName,
                        UserName = user.UserName
                    });
                    db.Applicates.Remove(applicate);
                    db.SaveChanges();
                }
                else if(applicate.ApplicateType.Equals(ApplicateTypes.ServiceDisconnect.ToString()))
                {
                    var service = db.Services.Single(x => x.NumberForMobileConnection.Equals(applicate.NewServiceName));
                    var userService = db.UserServices.First(x => x.ServiceName.Equals(service.NumberForMobileConnection));
                    db.UserServices.Remove(userService);
                    var allUserServices = db.UserServices.Where(x => x.UserName.Equals(user.UserName));
                    if (allUserServices == null || allUserServices.Count() <= 0)
                        user.IsHasServices = false;
                    db.Applicates.Remove(applicate);
                    db.SaveChanges();
                }
            }

            return true;
        }

        public string GetAllApplications()
        {
            dynamic result = new JObject();
            result.IsHasApplications = true;
            result.Connections = new JArray();
            result.NewUsers = new JArray();
            using (db)
            {
                var connectApplications = db.Applicates.ToList();
                var newUserApplications = db.NewUserApplicates.ToList();
                if(connectApplications.Count() < 0 && newUserApplications.Count() < 0)
                    result.IsHasApplications = false;

                foreach (var el in connectApplications)
                {
                    dynamic app = new JObject();
                    var user = db.Users.Single(x => x.UserName.Equals(el.UserName));
                    
                    app.UserName = user.FullName;
                    if (el.ApplicateType.Equals(ApplicateTypes.RateConnection.ToString()))
                    {
                        var rate = db.Rates.Single(x => x.NumberForMobileConnection.Equals(el.NewServiceName));
                        app.Id = el.Id;
                        app.Type = "Подключение нового тарифа";
                        app.ServiceName = rate.Name;
                    }
                    else if(el.ApplicateType.Equals(ApplicateTypes.ServiceConnection.ToString()))
                    {
                        var service = db.Services.Single(x => x.NumberForMobileConnection.Equals(el.NewServiceName));
                        app.Id = el.Id;
                        app.Type = "Подключение дополнительной услуги";
                        app.ServiceName = service.Name;
                    }
                    else if (el.ApplicateType.Equals(ApplicateTypes.ServiceDisconnect.ToString()))
                    {
                        var service = db.Services.Single(x => x.NumberForMobileConnection.Equals(el.NewServiceName));
                        app.Id = el.Id;
                        app.Type = "Удаление подключенной услуги";
                        app.ServiceName = service.Name;
                    }
                    result.Connections.Add(app);
                }

                foreach(var el in newUserApplications)
                {
                    dynamic app = new JObject();
                    app.Id = el.Id;
                    app.UserName = el.Name + "  " + el.Sename;
                    app.Phone = el.Phone;
                    app.PersonalNumber = el.PersonalNumber;

                    result.NewUsers.Add(app);
                }
                    
            }

            return JsonConvert.SerializeObject(result);
        }

        private bool Validate(Rate rate)
        {
            if (string.IsNullOrEmpty(rate.Name) || rate.Name.Length < 7)
                return false;
            else if (rate.Payment < 600 || rate.PriceForConnection < 0)
                return false;
            else
                return true;
        }

        private bool Validate(Service service)
        {
            if (string.IsNullOrEmpty(service.Name) || service.Name.Length < 7)
                return false;
            else if (service.Payment < 30 || service.PriceForConnection < 0)
                return false;
            else
                return true;
        }

        public bool DeleteApp(int applicateId, bool IsConnectApp)
        {
            using (db)
            {
                try
                {
                    if (IsConnectApp)
                        db.Applicates.Remove(db.Applicates.Single(x => x.Id == applicateId));
                    else
                        db.NewUserApplicates.Remove(db.NewUserApplicates.Single(x => x.Id == applicateId));
                    db.SaveChanges();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }

            }
        }
    }
}
