using C971.MVVM.Models;
using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;

public partial class Courses : ContentPage
{
    private int selectedTermID;
    private int storedTermID;

	public Courses(int selectedTermID)
	{
		InitializeComponent();
        storedTermID = selectedTermID;
        BindingContext = new CoursesViewModel(storedTermID);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if(App.AcademicTermRepo.GetCourseCount(storedTermID) < 6)
        {
            Navigation.PushAsync(new AddCourses(storedTermID));
        }
        else
        {
            AddButton.IsEnabled = false;
        }
        
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new TermView());
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new DetailedTermView(storedTermID));
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        Application.Current.MainPage = new NavigationPage(new TermView());
    }

    private void CollectionView_SelectionChanged1(object sender, SelectionChangedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is View tappedItem && tappedItem.BindingContext is Course selectedItem)
        {
            int selectedCourseID = selectedItem.courseID;
            Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ViewCourseInfo(selectedCourseID, storedTermID)));
        }

    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new EditTerm(storedTermID)));

    }

    private void SwipeItem_Clicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is Course selectedItem)
        {
            int selectedCourseID = selectedItem.courseID;
            App.AcademicTermRepo.DeleteCourse(selectedCourseID);
            Application.Current.MainPage.DisplayAlert("Alert", "Course Deleted", "OK");
            Application.Current.MainPage = new NavigationPage(new TermView());
        }
    }
}



