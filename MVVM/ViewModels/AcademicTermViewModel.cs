
using C971.MVVM.Models;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.LocalNotification;

namespace C971.MVVM.ViewModels
{
    public class AcademicTermViewModel : INotifyPropertyChanged
    {
        private AcademicTerm selectedTerm;

        public AcademicTerm SelectedTerm
        {
            get { return selectedTerm; }
            set
            {
                if (selectedTerm != value)
                {
                    selectedTerm = value;
                    OnPropertyChanged(nameof(SelectedTerm));
                }
            }
        }



        private ObservableCollection<AcademicTerm> terms;
        
        public ObservableCollection<AcademicTerm>Terms
        {
            get { return terms; }
            set
            {
                if (terms != value)
                {
                    terms = value;
                    OnPropertyChanged(nameof(terms));
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



        public AcademicTermViewModel()
        {
            Terms = new ObservableCollection<AcademicTerm>(App.AcademicTermRepo.GetAllTerms());
            //Courses = new ObservableCollection<Course>(App.AcademicTermRepo.GetAllTotalCourses());

            
            //foreach(var courses in Courses)
            //{
            //    try
            //    {
            //        if (courses.courseStartDate == DateTime.Now.Date && (courses.startCourseAlert == true))
            //        {
                        
            //            var request = new NotificationRequest
            //            {
            //                Title = "Yo Big boy",
            //                Description = "YO ITS ME",
            //                Schedule = new NotificationRequestSchedule
            //                {
            //                    NotifyTime = DateTime.Now.AddSeconds(5),
            //                }
            //            };
            //            LocalNotificationCenter.Current.Show(request);
            //            Console.WriteLine("YAY______________________________");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("oooops___________________________________");
            //    }
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected  void  OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
