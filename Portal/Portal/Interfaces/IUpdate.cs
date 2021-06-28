using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;
using Portal.Models.ViewModels;

namespace Portal.Interfaces
{
    public interface IUpdate
    {
        public RegisterViewModel IsCanRegister(string applicationNumber);
        public bool SendApplication(string name, string applicationNumber, string email);
        public void AddGroup(Teacher teacher);
        public void AddCourseToGroup(Group group, Course course);
    }
}
