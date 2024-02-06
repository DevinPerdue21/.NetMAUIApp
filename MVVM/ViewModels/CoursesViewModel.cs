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
    public class CoursesViewModel : INotifyPropertyChanged
    {
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
        private ObservableCollection<Course> courses;

            public ObservableCollection<Course> Courses
            {
                get { return courses; }
                set
                {
                    if (courses != value)
                    {
                        courses = value;
                        OnPropertyChanged(nameof(Courses));
                    }
                }
            }
        public CoursesViewModel(int selectedTermID)
        {
            SelectedTermID = selectedTermID;
            Courses = new ObservableCollection<Course>(App.AcademicTermRepo.GetAllCourses(selectedTermID));

        }


            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                if (selectedCourse != value)
                {
                    selectedCourse = value;
                    OnPropertyChanged(nameof(SelectedCourse));
                }
            }
        }

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

    }
}
