using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portal.Models;
using Portal.Models.Abstract;

namespace Portal.Interfaces
{
    public interface ITeacher
    {
        public Teacher GetTeacher(int id);
        public Teacher GetTeacher(string personalNumber);
        public bool AddNumerator(string[][] subjects, TimeSpan[][] time, string userId);
        public bool AddDenominator(string[][] subjects, TimeSpan[][] time, string userId);
        public bool AddBorder(int courseNumber, Border newBorder);
        public bool AddSubjectToBorder(int borderNumber, Subject newSubject);
        public bool EstimateBorder(int valueOfMark, int borderId, int studentId);
        public bool EstimateSubject(int valueOfMark, int studentId, int subjectId);
        public Task AddNotification(string head, string message, string personalNumber);
        public Task AddNotificationToGroup(string head, string message, int groupNumber);
        public string GetImagePath(Guid personNumber);
    }
}
