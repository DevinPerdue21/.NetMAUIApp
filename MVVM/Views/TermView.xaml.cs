using C971.MVVM.Models;
using C971.MVVM.ViewModels;
using Microsoft.Maui.Controls.Compatibility;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace C971.MVVM.Views;

public partial class TermView : ContentPage
{
	public TermView()
	{
        InitializeComponent();
        BindingContext = new AcademicTermViewModel();

        Terms = new ObservableCollection<AcademicTerm>(App.AcademicTermRepo.GetAllTerms());
        Courses = new ObservableCollection<Course>(App.AcademicTermRepo.GetAllTotalCourses());

        foreach (var courses in Courses)
        {
            try
            {
                if (courses.courseStartDate.Date == DateTime.Today && (courses.startCourseAlert == true))
                {
                    ShowStartCourseAlert(courses.courseName);
                }

                if (courses.courseEndDate.Date == DateTime.Now.Date && (courses.endCourseAlert == true))
                {
                    ShowEndCourseAlert(courses.courseName);
                }

                if (courses.performanceDue.Date == DateTime.Now.Date && (courses.performanceAlert == true))
                {
                    ShowPerformanceAlert(courses.performanceName);
                }

                if (courses.objectiveDue.Date == DateTime.Now.Date && (courses.objectiveAlert == true))
                {
                    ShowObjectiveAlert(courses.objectiveName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

    private void ShowStartCourseAlert(string courseName)
    {
        var request = new NotificationRequest
        {
            NotificationId = 1,
            Title = $"{courseName} is starting today!!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(1),
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

    private void ShowEndCourseAlert(string courseName)
    {
        var request = new NotificationRequest
        {
            NotificationId = 2,
            Title = $"{courseName} is ending today!!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(2),
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

    private void ShowPerformanceAlert(string performanceName)
    {
        var request = new NotificationRequest
        {
            NotificationId = 3,
            Title = $"{performanceName} is Due today!!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(3),
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

    private void ShowObjectiveAlert(string objectiveName)
    {
        var request = new NotificationRequest
        {
            NotificationId = 4,
            Title = $"{objectiveName} is Due today!!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(2),
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new NewTerm());
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {
        DisplayAlert("Swiped Left", "Click me!", "OK");
    }

    private void SwipeItem_Clicked(object sender, EventArgs e)
    {

        //Console.WriteLine("CLICKED");
        //if (BindingContext is AcademicTermViewModel viewModel && viewModel.SelectedTerm != null)
        //{
        //    int selectedTermID = viewModel.SelectedTerm.termID;
        //    Console.WriteLine("_________________________________" + selectedTermID.ToString());

        //    // Pass selectedTermID to DetailedTermView
        //    Application.Current.MainPage.Navigation.PushAsync(new DetailedTermView(selectedTermID));
        //}
    }

    private void SwipeItem_Clicked_1(object sender, EventArgs e)
    {
        //if (BindingContext is AcademicTermViewModel viewModel && viewModel.SelectedTerm != null)
        //{
        //    int selectedTermID = viewModel.SelectedTerm.termID;
        //    Console.WriteLine("_________________________________" + selectedTermID.ToString());

        //    // Pass selectedTermID to DetailedTermView
        //    Application.Current.MainPage.Navigation.PushAsync(new DetailedTermView(selectedTermID));
        //}
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedTerm = e.CurrentSelection[0] as AcademicTerm;
            if (selectedTerm != null)
            {
                int selectedTermID = selectedTerm.termID;
                Console.WriteLine("_________________________________" + selectedTermID.ToString());

                //if (BindingContext is AcademicTermViewModel viewModel)
                //{
                //    viewModel.SelectedTerm = selectedTerm;
                //}
                //Application.Current.MainPage.Navigation.PushAsync(new Courses(selectedTermID));
                Application.Current.MainPage = new NavigationPage(new Courses(selectedTermID));

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

    private ObservableCollection<AcademicTerm> terms;

    public ObservableCollection<AcademicTerm> Terms
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

}