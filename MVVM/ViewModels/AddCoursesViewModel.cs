using C971.MVVM.Models;
using C971.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C971.MVVM.ViewModels
{
    public class AddCoursesViewModel : INotifyPropertyChanged
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


        public ICommand Submit { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddCoursesViewModel(int selectedTermID)
        {
            TermID = selectedTermID;
            Console.WriteLine($"Constructor: SelectedTermID = {selectedTermID}, TermID = {TermID}");

            PerformanceDue = DateTime.Now;
            ObjectiveDue = DateTime.Now;
            CourseStartDate = DateTime.Now;
            CourseEndDate = DateTime.Now.AddMonths(1);
            Submit = new Command(SubmitClicked);
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

                if (string.IsNullOrEmpty(CourseStatus))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Must choose a status!", "OK");
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
                    Application.Current.MainPage.DisplayAlert("Alert", "Invalid phone number format! 123-456-7890", "OK");
                    return;
                }

                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(InstructorEmail, emailPattern))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Invalid email format!", "OK");
                    return;
                }


                var newCourse = new Course
                {
                    courseName = CourseName,
                    courseStartDate = CourseStartDate,
                    courseEndDate = CourseEndDate,
                    courseStatus = CourseStatus,
                    instructorName = InstructorName,
                    instructorPhoneNumber = InstructorPhoneNumber,
                    instructorEmail = InstructorEmail,
                    startCourseAlert = StartCourseAlert,
                    endCourseAlert = EndCourseAlert,
                    performanceName = PerformanceName,
                    performanceDue = PerformanceDue,
                    performanceAlert = PerformanceAlert,
                    objectiveName = ObjectiveName,
                    objectiveDue = ObjectiveDue,
                    objectiveAlert = ObjectiveAlert,
                    optionalNotes = OptionalNotes,
                    TermID = TermID
                };

                App.AcademicTermRepo.AddCourses(newCourse);
                Application.Current.MainPage = new NavigationPage(new Courses(TermID));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
