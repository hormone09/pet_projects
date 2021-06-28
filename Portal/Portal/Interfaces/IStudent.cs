using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;

namespace Portal.Interfaces
{
    public interface IStudent
    {
        public Student GetMinimalStudentInfo(string personalNumber);
        public Student GetStudent(int id);
        public Student GetStudentPage(string pageNumber);
        public bool AddNewAnswer(string answerText, int studentNumber, int subjectNumber);
        public List<FinallyMark> GetAllMarks(Student student);
        public string GetImagePath(Guid personNumber);
    }
}
