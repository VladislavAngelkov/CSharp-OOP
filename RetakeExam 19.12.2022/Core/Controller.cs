using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models.Any(m=>m.FirstName == firstName && m.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            int id = students.Models.Count() + 1;

            IStudent student = new Student(id, firstName, lastName);

            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(m=>m.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            int id = subjects.Models.Count() + 1;

            if (subjectType == "TechnicalSubject")
            {
                ISubject subject = new TechnicalSubject(id, subjectName);
                subjects.AddModel(subject);
            }
            else if (subjectType == "EconomicalSubject")
            {
                ISubject subject = new EconomicalSubject(id, subjectName);
                subjects.AddModel(subject);
            }
            else
            {
                ISubject subject = new HumanitySubject(id, subjectName);
                subjects.AddModel(subject);
            }

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.Models.Any(m=>m.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> subjectsIds = new List<int>();

            foreach (var subject in requiredSubjects)
            {
                subjectsIds.Add(subjects.Models.First(m => m.Name == subject).Id);
            }

            int id = universities.Models.Count() + 1;

            IUniversity university = new University(id, universityName, category, capacity, subjectsIds);

            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] fillName = studentName.Split(' ');
            string firstName = fillName[0];
            string lastName = fillName[1];

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var subject in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Any(e=>e==subject))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University!=null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Any(e=>e == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder message = new StringBuilder();
            message.AppendLine($"*** {university.Name} ***");
            message.AppendLine($"Profile: {university.Category}");
            
            int studnetsInUniversity = students.Models.Where(s => s.University!=null && s.University.Id == universityId).Count();

            message.AppendLine($"Students admitted: {studnetsInUniversity}");
            message.AppendLine($"University vacancy: {university.Capacity - studnetsInUniversity}");

            return message.ToString().TrimEnd();
        }
    }
}
