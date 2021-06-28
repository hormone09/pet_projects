using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Portal.Data;
using Portal.Interfaces;
using Portal.Models;
using Portal.Models.ViewModels;

namespace Portal.Repository
{
    public class RepUpdate : IUpdate
    {
        private readonly AplicationDbContext db;
        public RepUpdate(AplicationDbContext db)
        {
            this.db = db;
        }
        public RegisterViewModel IsCanRegister(string applicationNumber)
        {
            var currentApplication = db.registrationApplications.SingleOrDefault
                (x => x.id.Equals(applicationNumber));
            bool IsCanRegister = currentApplication != null;
            if (IsCanRegister)
            {
                RegisterViewModel model = new RegisterViewModel(currentApplication);
                return model;
            }
            else return null;
        }
        public bool SendApplication(string name, string applicationNumber, string email)
        {
            try
            {
                MailAddress from = new MailAddress("botbotsuperbot@mail.ru", "Администрация 'Portal'");
                MailAddress to = new MailAddress(email, "Новый пользователь");
                MailMessage massage = new MailMessage(from, to);

                SmtpClient smtp = new SmtpClient(); //настройка smtp, можно посмотреть в маил ру
                smtp.Host = "smtp.mail.ru";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("botbotsuperbot@mail.ru", "TakeThisPasswordDude");
                massage.Subject = $"Здраствуйте, {name}! " +
                    $"Вам отправили приглашение на регистрацию в сервисе 'Portal'. Перейдите по ссылке:" +
                    $"https://localhost:44378/Account/Register/?registerNumber={applicationNumber}";
                smtp.Send(massage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void AddCourseToGroup(Group group, Course course)
        {
            throw new NotImplementedException();
        }
        public void AddGroup(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
