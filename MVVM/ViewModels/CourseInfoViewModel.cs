using C971.MVVM.Models;
using C971.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C971.MVVM.ViewModels
{
    public class CourseInfoViewModel : INotifyPropertyChanged
    {

        private int courseID;
        public int CourseID
        {
            get { return courseID; }
            set
            {
                if (courseID != value)
                {
                    courseID = value;
                    OnPropertyChanged(nameof(CourseID));
                }
            }
        }

        private int termID;
        public int TermID
        {
            get { return termID; }
            set
            {
                if (termID != value)
                {
                    termID = value;
                    OnPropertyChanged(nameof(TermID));
                }
            }
        }
        private int storedCourseID;
        public int StoredCourseID
        {
            get { return storedCourseID; }
            set
            {
                if (storedCourseID != value)
                {
                    storedCourseID = value;
                    OnPropertyChanged(nameof(StoredCourseID));
                }
            }
        }

        private string courseName;
        public string CourseName
        {
            get { return courseName; }
            set
            {
                if (courseName != value)
                {
                    courseName = value;
                    OnPropertyChanged(nameof(CourseName));
                }
            }
        }

        private DateTime courseStartDate;
        public DateTime CourseStartDate
        {
            get { return courseStartDate; }
            set
            {
                if (courseStartDate != value)
                {
                    courseStartDate = value;
                    OnPropertyChanged(nameof(CourseStartDate));
                }
            }
        }

        private DateTime courseEndDate;
        public DateTime CourseEndDate
        {
            get { return courseEndDate; }
            set
            {
                if (courseEndDate != value)
                {
                    courseEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string courseStatus;
        public string CourseStatus
        {
            get { return courseStatus; }
            set
            {
                if (courseStatus != value)
                {
                    courseStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        private string instructorName;
        public string InstructorName
        {
            get { return instructorName; }
            set
            {
                if (instructorName != value)
                {
                    instructorName = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool startCourseAlert;
        public bool StartCourseAlert
        {
            get { return startCourseAlert; }
            set
            {
                if (startCourseAlert != value)
                {
                    startCourseAlert = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool endCourseAlert;
        public bool EndCourseAlert
        {
            get { return endCourseAlert; }
            set
            {
                if (endCourseAlert != value)
                {
                    endCourseAlert = value;
                    OnPropertyChanged();
                }
            }
        }

        private string instructorPhoneNumber;
        public string InstructorPhoneNumber
        {
            get { return instructorPhoneNumber; }
            set
            {
                if (instructorPhoneNumber != value)
                {
                    instructorPhoneNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string instructorEmail;
        public string InstructorEmail
        {
            get { return instructorEmail; }
            set
            {
                if (instructorEmail != value)
                {
                    instructorEmail = value;
                    OnPropertyChanged();
                }
            }
        }

        private string optionalNotes;
        public string OptionalNotes
        {
            get { return optionalNotes; }
            set
            {
                if (optionalNotes != value)
                {
                    optionalNotes = value;
                    OnPropertyChanged();
                }
            }
        }

        private string performanceName;
        public string PerformanceName
        {
            get { return performanceName; }
            set
            {
                if (performanceName != value)
                {
                    performanceName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime performanceDue;
        public DateTime PerformanceDue
        {
            get { return performanceDue; }
            set
            {
                if (performanceDue != value)
                {
                    performanceDue = value;
                    OnPropertyChanged();
                }
            }
        }

        private string objectiveName;
        public string ObjectiveName
        {
            get { return objectiveName; }
            set
            {
                if (objectiveName != value)
                {
                    objectiveName = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime objectiveDue;
        public DateTime ObjectiveDue
        {
            get { return objectiveDue; }
            set
            {
                if (objectiveDue != value)
                {
                    objectiveDue = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool performanceAlert;
        public bool PerformanceAlert
        {
            get { return performanceAlert; }
            set
            {
                if (performanceAlert != value)
                {
                    performanceAlert = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool objectiveAlert;
        public bool ObjectiveAlert
        {
            get { return objectiveAlert; }
            set
            {
                if (objectiveAlert != value)
                {
                    objectiveAlert = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<Course> course;

        public ObservableCollection<Course> Course
        {
            get { return course; }
            set
            {
                if (course != value)
                {
                    course = value;
                    OnPropertyChanged(nameof(Course));
                }
            }
        }
        public CourseInfoViewModel(int storedCourseID, int storedTermID)
        {
            StoredCourseID = storedCourseID;
            Course = new ObservableCollection<Course>(App.AcademicTermRepo.GetCourse(storedCourseID));
            Submit = new Command(SubmitClicked);
            Delete = new Command(DeleteClicked);

            var courseNames = App.AcademicTermRepo.GetCourseName(storedCourseID);
            if (courseNames.Count > 0)
            {
                CourseName = courseNames[0];
            }
            courseID = storedCourseID;
            termID = storedTermID;

            var courseNames1 = App.AcademicTermRepo.GetCourseStartDate(storedCourseID);
            if (courseNames1.Count > 0)
            {
                CourseStartDate = courseNames1[0];
            }
            

            var courseNames2 = App.AcademicTermRepo.GetCourseEndDate(storedCourseID);
            if (courseNames2.Count > 0)
            {
                CourseEndDate = courseNames2[0];
            }
            

            var courseNames3 = App.AcademicTermRepo.GetCourseStatus(storedCourseID);
            if (courseNames3.Count > 0)
            {
                CourseStatus = courseNames3[0];
            }

            var courseNames4 = App.AcademicTermRepo.GetCourseInstructor(storedCourseID);
            if (courseNames4.Count > 0)
            {
                InstructorName = courseNames4[0];
            }

            var courseNames5 = App.AcademicTermRepo.GetCourseInstructorPhoneNumber(storedCourseID);
            if (courseNames5.Count > 0)
            {
                InstructorPhoneNumber = courseNames5[0];
            }

            var courseNames6 = App.AcademicTermRepo.GetCourseInstructorEmail(storedCourseID);
            if (courseNames6.Count > 0)
            {
                InstructorEmail = courseNames6[0];
            }

            var courseNames7 = App.AcademicTermRepo.GetStartCourseAlert(storedCourseID);
            if (courseNames7.Count > 0)
            {
                StartCourseAlert = courseNames7[0];
            }

            var courseNames8 = App.AcademicTermRepo.GetEndCourseAlert(storedCourseID);
            if (courseNames8.Count > 0)
            {
                EndCourseAlert = courseNames8[0];
            }

            var courseNames9 = App.AcademicTermRepo.GetOptionalNotes(storedCourseID);
            if (courseNames9.Count > 0)
            {
                OptionalNotes = courseNames9[0];
            }

            var courseNames10 = App.AcademicTermRepo.GetPerformanceName(storedCourseID);
            if (courseNames10.Count > 0)
            {
                PerformanceName = courseNames10[0];
            }

            var courseName11 = App.AcademicTermRepo.GetPerformanceDate(storedCourseID);
            if (courseName11.Count > 0)
            {
                PerformanceDue = courseName11[0];
            }

            var courseNames12 = App.AcademicTermRepo.GetObjectiveName(storedCourseID);
            if (courseNames12.Count > 0)
            {
                ObjectiveName = courseNames12[0];
            }

            var courseName12 = App.AcademicTermRepo.GetObjectiveDate(storedCourseID);
            if (courseName12.Count > 0)
            {
                ObjectiveDue = courseName12[0];
            }

            var courseNames13 = App.AcademicTermRepo.GetPerformanceAlert(storedCourseID);
            if (courseNames13.Count > 0)
            {
                PerformanceAlert = courseNames13[0];
            }

            var courseName14 = App.AcademicTermRepo.GetObjectiveAlert(storedCourseID);
            if (courseName14.Count > 0)
            {
                ObjectiveAlert = courseName14[0];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Submit { get; }
        public ICommand Delete { get; }

        private void DeleteClicked()
        {
            try
            {
                var course = new Course
                {
                    courseID = StoredCourseID,
                    courseName = CourseName,
                    courseStartDate = CourseStartDate,
                    courseEndDate = CourseEndDate,
                    courseStatus = CourseStatus,
                    instructorName = InstructorName,
                    instructorPhoneNumber = InstructorPhoneNumber,
                    instructorEmail = InstructorEmail,
                    startCourseAlert = StartCourseAlert,
                    endCourseAlert = EndCourseAlert,
                    optionalNotes = OptionalNotes,
                    performanceName = PerformanceName,
                    performanceDue = PerformanceDue,
                    objectiveName = ObjectiveName,
                    objectiveDue = ObjectiveDue,
                    performanceAlert = PerformanceAlert,
                    objectiveAlert = ObjectiveAlert,
                    TermID = termID
                };

                App.AcademicTermRepo.DeleteCourse(courseID);
                Application.Current.MainPage.DisplayAlert("Alert", "Course Deleted", "OK");
                Application.Current.MainPage = new NavigationPage(new TermView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SubmitClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(CourseName))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Term name cannot be empty!", "OK");
                    return;
                }

                if (CourseStartDate > CourseEndDate)
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Start date cannot be before end date!", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(InstructorName))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Instructor name cannot be empty!", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(InstructorPhoneNumber))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Phone number cannot be empty!", "OK");
                    return;
                }

                string phoneNumberPattern = @"^\d{3}-\d{3}-\d{4}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(InstructorPhoneNumber, phoneNumberPattern))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Invalid phone number format! xxx-xxx-xxxx", "OK");
                    return;
                }

                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(InstructorEmail, emailPattern))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Invalid email format!", "OK");
                    return;
                }



                var course = new Course
                {
                    courseID = StoredCourseID,
                    courseName = CourseName,
                    courseStartDate = CourseStartDate,
                    courseEndDate = CourseEndDate,
                    courseStatus = CourseStatus,
                    instructorName = InstructorName,
                    instructorPhoneNumber = InstructorPhoneNumber,
                    instructorEmail = InstructorEmail,
                    startCourseAlert = StartCourseAlert,
                    endCourseAlert = EndCourseAlert,
                    optionalNotes = OptionalNotes,
                    performanceName = PerformanceName,
                    performanceDue = PerformanceDue,
                    objectiveName = ObjectiveName,
                    objectiveDue = ObjectiveDue,
                    performanceAlert = PerformanceAlert,
                    objectiveAlert = ObjectiveAlert,
                    TermID = termID
                };

                App.AcademicTermRepo.UpdateCourse(course);
                Application.Current.MainPage.DisplayAlert("Alert", "Course Updated", "OK");
                Application.Current.MainPage = new NavigationPage(new TermView());
                //Application.Current.MainPage.Navigation.PushAsync(new Courses(termID));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
