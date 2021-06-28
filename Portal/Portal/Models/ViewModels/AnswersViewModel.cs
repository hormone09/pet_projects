using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models.ViewModels
{
    public class AnswersViewModel
    {
        public string groupName;
        public string courseName;
        public Subject subject;
        public List<StudentWithAnswer> answers = new List<StudentWithAnswer>();
    }
    public struct StudentWithAnswer
    {
        public Student student;
        public Answer answer;
    }
}
