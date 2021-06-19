using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Provider.Data;
using Provider.Interfaces;
using Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Provider.Repository
{
    public class ServicesRep : IServices
    {
        private readonly ApplicationDbContext db;

        public ServicesRep(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string GetUserData(Guid userId)
        {
            using (db)
            {
                dynamic json = new JObject();
                var user = db.Users.Single(x => x.Id.Equals(userId));
                json.Name = user.FullName;
                json.Phone = user.PhoneNumber;
                json.Services = new JArray();
                if(user.IsHasServices)
                {
                    var servicesTable = db.UserServices.Where(x => x.UserName.Equals(user.UserName));
                    foreach (var userService in servicesTable)
                        foreach (var service in db.Services)
                            if (userService.ServiceName.Equals(service.NumberForMobileConnection))
                            {
                                dynamic jService = new JObject();
                                jService.Name = service.Name;
                                jService.Desk = service.Desk;
                                jService.Command = service.NumberForMobileConnection;
                                json.Services.Add(jService);
                            }
                }
                if(user.IsHasRate)
                {
                    var rate = db.Rates.SingleOrDefault(x => x.Name.Equals(user.RateName));
                    if(rate != null)
                    {
                        json.Rate = rate.Name;
                        json.Payment = rate.Payment;
                    }
                    else
                    {
                        json.Rate = user.RateName;
                        json.Payment = "Неизвестно!";
                    }
                }
                else
                {
                    json.Rate = "У вас нет тарифа!";
                    json.Payment = "Абоненсткая плата не взымается!";
                }

                return JsonConvert.SerializeObject(json);
            }
        }
        public string GetInternetRates()
        {
            using (db)
            {
                var rates = db.Rates.Where(x => x.IsMoreInternet && x.IsCanConnect).ToList();
                if (rates != null || rates.Count() > 0)
                {
                    return Serialization(rates);
                }
                else
                    return null;
            }
        }
        public string GetTelephoneRates()
        {
            using (db)
            {
                var rates = db.Rates.Where(x => !x.IsMoreInternet && x.IsCanConnect).ToList();
                if (rates != null || rates.Count() > 0)
                {
                    return Serialization(rates);
                }
                else
                    return null;
            }
        }
        public string GetServices(string serviceType)
        {
            using (db)
            {
                var services = new List<Service>();
                if (serviceType.Equals("All"))
                    services = db.Services.ToList();
                else
                    services = db.Services.Where(x => !x.Type.Equals(serviceType) 
                        && x.IsCanConnect).ToList();

                if (services != null && services.Count() > 0)
                {
                    return Serialization(services);
                }
                else
                    return "Error!";
            }
        }
        private string Serialization(List<Rate> rates)
        {
            dynamic result = new JArray();
            foreach (var rate in rates)
            {
                dynamic jsonObj = new JObject();
                jsonObj.Id = rate.Id;
                jsonObj.Name = rate.Name;
                jsonObj.Desk = rate.Desk;
                jsonObj.MobileCode = rate.NumberForMobileConnection;
                jsonObj.PriceForConnection = rate.PriceForConnection + " тг";
                jsonObj.Payment = rate.Payment + " тг/мес";
                jsonObj.Sms = rate.SMSCount;
                jsonObj.Gigabyte = rate.GigabyteCount;
                jsonObj.Minute = rate.MinuteCount;

                result.Add(jsonObj);
            }

            return JsonConvert.SerializeObject(result);
        }
        private string Serialization(List<Service> services)
        {
            dynamic result = new JArray();
            foreach (var service in services)
            {
                dynamic jsonObj = new JObject();
                jsonObj.Id = service.Id;
                jsonObj.Name = service.Name;
                jsonObj.Desk = service.Desk;
                jsonObj.MobileCode = service.NumberForMobileConnection;
                jsonObj.PriceForConnection = service.PriceForConnection + "  тг";
                if(service.IsPaymentOnceMonth)
                    jsonObj.Payment = service.Payment + "тг/мес";
                else
                    jsonObj.Payment = service.Payment + "тг/день";
                jsonObj.Type = service.Type;

                result.Add(jsonObj);
            }

            return JsonConvert.SerializeObject(result);
        }
        public bool NewApplicate(Applicate applicate)
        {
            using (db)
            {
                var IsHasServiceForConnection = db.Services.SingleOrDefault
                    (x => x.NumberForMobileConnection.Equals(applicate.NewServiceName)) != null;
                bool IsHasRateForConnection = db.Rates.SingleOrDefault
                    (x => x.NumberForMobileConnection.Equals(applicate.NewServiceName)) != null;
                if (IsHasServiceForConnection ^ IsHasRateForConnection)
                {
                    bool IsHasThisApplicate = db.Applicates.FirstOrDefault(x => x.NewServiceName.Equals(applicate.NewServiceName) 
                        && x.UserName.Equals(applicate.UserName) && x.ApplicateType.Equals(applicate.ApplicateType)) != null;
                    if(!IsHasThisApplicate)
                    {
                        db.Applicates.Add(applicate);
                        db.SaveChanges();
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
        }

        public bool NewUserApplicate(NewUserApplicate applicate)
        {
            using (db)
            {
                bool IsHasThisApplicate = db.NewUserApplicates.FirstOrDefault(x =>
                    x.Name.Equals(applicate.Name) && x.Sename.Equals(applicate.Sename)) != null;
                bool IsValid = applicate.PersonalNumber.Length == 12;
                if (!IsHasThisApplicate && IsValid)
                {
                    db.NewUserApplicates.Add(applicate);
                    db.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }
    }
}
