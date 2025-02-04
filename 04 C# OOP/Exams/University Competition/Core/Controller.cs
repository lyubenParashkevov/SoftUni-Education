using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private IRepository<ISubject> subjects;
        private IRepository<IStudent> students;
        private IRepository<IUniversity> universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        public string AddStudent(string firstName, string lastName)     // OK
        {
            IStudent student = new Student(students.Models.Count + 1, firstName, lastName);

            string fullName = firstName + " " + lastName;
            if (students.FindByName(fullName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
        }

        public string AddSubject(string subjectName, string subjectType)  // 100 % OK

        {


            if (subjectType != nameof(EconomicalSubject) && subjectType != nameof(HumanitySubject)
                && subjectType != nameof(TechnicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            if (subjectType == nameof(EconomicalSubject))
            {
                ISubject subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);

                return string.Format(OutputMessages.SubjectAddedSuccessfully, nameof(EconomicalSubject), subjectName
                    , nameof(SubjectRepository));
            }

            else if (subjectType == nameof(HumanitySubject))
            {
                ISubject subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);
                return string.Format(OutputMessages.SubjectAddedSuccessfully, nameof(HumanitySubject), subjectName
                    , nameof(SubjectRepository));
            }

            else         //TehnicalSubject
            {
                ISubject subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                subjects.AddModel(subject);
                return string.Format(OutputMessages.SubjectAddedSuccessfully, nameof(TechnicalSubject), subjectName
                    , nameof(SubjectRepository));
            }



        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)//99%
        {
            if (universities.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> required = new List<int>();

            for (int i = 0; i < requiredSubjects.Count; i++)
            {

                ISubject subject = subjects.FindByName(requiredSubjects[i]);
                
                if (subject != null)
                {
                    required.Add(subject.Id);
                
                }
            }

            IUniversity university = new University(universities.Models.Count + 1, universityName, category, capacity, required);

            universities.AddModel(university);
            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);


            if (student == null)
            {
                return string.Format(OutputMessages.InvalidStudentId, studentId);
            }

            if (subject == null)
            {
                return string.Format(OutputMessages.InvalidSubjectId, subjectId);
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName
                    , subject.Name);
            }

            student.CoverExam(subject);
            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)   // not tested
        {

            string[] names = studentName.Split();
            string firstName = names[0];
            string lastName = names[1];

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


            if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))  ///!!! да се запомни синтаксиса
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, universityName);

        }


        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");

            int studentsInThisUniversity = 0;
            foreach (var student in students.Models)
            {
                if (student.University == university)
                {
                    studentsInThisUniversity++;
                }
            }

            sb.AppendLine($"Students admitted: {studentsInThisUniversity}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsInThisUniversity}");

            return sb.ToString().TrimEnd();

        }
    }
}
