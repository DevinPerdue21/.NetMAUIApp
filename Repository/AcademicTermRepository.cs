using C971.MVVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C971.Repository
{
    public class AcademicTermRepository
    {
        string _dbpath;
        private SQLiteConnection connection;

        public AcademicTermRepository (string dbpath)
        {
            _dbpath = dbpath;
        }

        public void Init()
        {
            connection = new SQLiteConnection(_dbpath);
            connection.CreateTable<AcademicTerm>(); 
            connection.CreateTable<Course>();
        }

        public void Add(AcademicTerm term)
        {
            connection = new SQLiteConnection(_dbpath);
            connection.Insert(term);
        }

        public void AddCourses(Course course)
        {
            connection = new SQLiteConnection(_dbpath);
            connection.Insert(course);
        }

        public void UpdateCourse (Course course)
        {
            connection = new SQLiteConnection(_dbpath);
            connection.Update(course);
        }

        public void UpdateTerm(AcademicTerm term)
        {
            connection = new SQLiteConnection(_dbpath);
            connection.Update(term);
        }

        public void DeleteAll()
        {
            connection.DeleteAll<AcademicTerm>();
        }
        public void DeleteAllCourses()
        {
            connection.DeleteAll<Course>();
        }

        public void DeleteCourse(int courseID)
        {
            var courseToDelete = connection.Table<Course>().FirstOrDefault(course => course.courseID == courseID);
            connection.Delete(courseToDelete);
        }

        public List<AcademicTerm> GetAllTerms()
        {
            return connection.Table<AcademicTerm>().ToList();   
        }
        public int GetCourseCount(int termID)
        {
            return connection.Table<Course>().Count(course => course.TermID == termID);
        }

        public List<AcademicTerm> GetTerm(int termID)
        {
            return connection.Table<AcademicTerm>().Where(term => term.termID == termID).ToList();
        }

        public List<string> GetTermName(int termID)
        {
            return connection.Table<AcademicTerm>().Where(term => term.termID == termID).Select(term => term.termName).ToList();
        }

        public List<DateTime> GetTermStart(int termID)
        {
            return connection.Table<AcademicTerm>().Where(term => term.termID == termID).Select(term => term.termStartDate).ToList();
        }

        public List<DateTime> GetTermEnd(int termID)
        {
            return connection.Table<AcademicTerm>().Where(term => term.termID == termID).Select(term => term.termEndDate).ToList();
        }

        public List<string> GetCourseName(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.courseName).ToList();
        }

        public List<DateTime> GetCourseStartDate(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.courseStartDate).ToList();
        }

        public List<DateTime> GetCourseEndDate(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.courseEndDate).ToList();
        }

        public List<string> GetCourseStatus(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.courseStatus).ToList();
        }

        public List<string> GetCourseInstructor(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.instructorName).ToList();
        }

        public List<string> GetCourseInstructorPhoneNumber(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.instructorPhoneNumber).ToList();
        }

        public List<string> GetCourseInstructorEmail(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.instructorEmail).ToList();
        }

        public List<string> GetOptionalNotes(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.optionalNotes).ToList();
        }

        public List<bool> GetStartCourseAlert(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.startCourseAlert).ToList();
        }

        public List<bool> GetEndCourseAlert(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.endCourseAlert).ToList();
        }

        public List<Course> GetCourse(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).ToList();
        }

        public List<Course> GetAllCourses(int termID)
        {
            return connection.Table<Course>().Where(c => c.TermID == termID).ToList();
        }

        public List<Course> GetAllTotalCourses()
        {
            return connection.Table<Course>().ToList();
        }

        public List<string> GetPerformanceName(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.performanceName).ToList();
        }

        public List<DateTime> GetPerformanceDate(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.performanceDue).ToList();
        }

        public List<string> GetObjectiveName(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.objectiveName).ToList();
        }

        public List<DateTime> GetObjectiveDate(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.objectiveDue).ToList();
        }

        public List<bool> GetPerformanceAlert(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.performanceAlert).ToList();
        }

        public List<bool> GetObjectiveAlert(int courseID)
        {
            return connection.Table<Course>().Where(course => course.courseID == courseID).Select(course => course.objectiveAlert).ToList();
        }

        public void InitializeData()
        {
            DeleteAll();
            DeleteAllCourses();

            if (connection.Table<AcademicTerm>().Any())
            {
                return;
            }

            var sample = new List<AcademicTerm>
            {
                new AcademicTerm { termName = "Term1", termStartDate = DateTime.Now, termEndDate = DateTime.Now.AddMonths(1) }
            };

            foreach (var term in sample)
            {
                connection.Insert(term);
            }

            int termIdForCourse = sample.First().termID;


            var courseSample = new List<Course>
            {
                new Course { courseName = "Math101", courseStartDate = new DateTime(2024, 1, 23), courseEndDate = new DateTime(2024, 2, 23), TermID = termIdForCourse, courseStatus = "Progress",
                instructorName = "Anika Patel", instructorPhoneNumber = "555-123-4567", instructorEmail = "anika.patel@strimeuniversity.edu", startCourseAlert = true, endCourseAlert = true, optionalNotes = "This is your notes section",
                performanceName = "Math Exam", objectiveName = "Math Project", performanceDue = new DateTime(2024, 1, 23), objectiveDue = new DateTime(2024, 1, 23), performanceAlert = true, objectiveAlert = true}
            };

            foreach (var course in courseSample)
            {
                connection.Insert(course);
            }
        }

    }
}
