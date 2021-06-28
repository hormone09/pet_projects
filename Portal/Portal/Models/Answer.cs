using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Answer
    {
        public int id { get; set; }
        public string text { get; set; }
        public SubjectMark mark { get; set; }
        public DateTime time { get; set; }
        public Subject subject { get; set; }
        public Student student { get; set; }

        public Answer() { }

        public Answer(string answerText, Student student, Subject subject)
        {
            text = answerText;
            this.student = student;
            this.subject = subject;
            time = DateTime.Now;
            mark = null;
        }
    }
}
