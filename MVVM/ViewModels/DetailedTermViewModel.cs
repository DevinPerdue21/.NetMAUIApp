using C971.MVVM.Models;
using C971.MVVM.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C971.MVVM.ViewModels
{
    public class DetailedTermViewModel : INotifyPropertyChanged
    {
        private string termName;
        public string TermName
        {
            get => termName;
            set
            {
                if (termName != value)
                {
                    termName = value ?? string.Empty;
                    OnPropertyChanged();
                }
            }
        }


        private ObservableCollection<AcademicTerm> term;

        public ObservableCollection<AcademicTerm> Term
        {
            get { return term; }
            set
            {
                if (term != value)
                {
                    term = value;
                    OnPropertyChanged(nameof(term));
                }
            }
        }

        private DateTime termStartDate;
        public DateTime TermStartDate
        {
            get => termStartDate;
            set
            {
                if (termStartDate != value)
                {
                    termStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime termEndDate;
        public DateTime TermEndDate
        {
            get => termEndDate;
            set
            {
                if (termEndDate != value)
                {
                    termEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string courseName;
        public string CourseName
        {
            get => courseName;
            set
            {
                if (courseName != value)
                {
                    courseName = value ?? string.Empty;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime courseStartDate;
        public DateTime CourseStartDate
        {
            get => courseStartDate;
            set
            {
                if (courseStartDate != value)
                {
                    courseStartDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime courseEndDate;
        public DateTime CourseEndDate
        {
            get => courseEndDate;
            set
            {
                if (courseEndDate != value)
                {
                    courseEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Course> courses;

        public ObservableCollection<Course> Courses
        {
            get { return courses; }
            set
            {
                if (courses != value)
                {
                    courses = value;
                    OnPropertyChanged(nameof(courses));
                }
            }
        }
        private int selectedTermID;
        public int SelectedTermID
        {
            get { return selectedTermID; }
            set
            {
                if (selectedTermID != value)
                {
                    selectedTermID = value;
                    OnPropertyChanged(nameof(SelectedTermID));
                }
            }
        }

        public ICommand Submit { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public DetailedTermViewModel(int selectedTermID)
        {
            Term = new ObservableCollection<AcademicTerm>(App.AcademicTermRepo.GetTerm(selectedTermID));
            Courses = new ObservableCollection<Course>(App.AcademicTermRepo.GetAllCourses(selectedTermID));
            //Submit = new Command(SubmitClicked);
        }

        //private void SubmitClicked()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(CourseName))
        //        {
        //            Application.Current.MainPage.DisplayAlert("Alert", "Term name cannot be null!", "OK");
        //            return;
        //        }

        //        if (StartDate > EndDate)
        //        {
        //            Application.Current.MainPage.DisplayAlert("Alert", "Start date cannot be before end date!", "OK");
        //            return;
        //        }


        //        var newCourse = new Course
        //        {
        //            courseName = CourseName,
        //            courseStartDate = StartDate,
        //            courseEndDate = EndDate,
        //            TermID = TermID
        //        };

        //        App.AcademicTermRepo.AddCourses(newCourse);
        //        Application.Current.MainPage = new NavigationPage(new Courses(TermID));
        //        //Application.Current.MainPage.Navigation.PushAsync(new Courses(termID));

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        }
}
