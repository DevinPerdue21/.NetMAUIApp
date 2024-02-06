using C971.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace C971.MVVM.Views;

public partial class CourseInfo : ContentPage
{
    private int selectedCourseID;
    private int storedCourseID;
    public CourseInfo(int selectedCourseID, int storedTermID)
	{
		InitializeComponent();
        storedCourseID = selectedCourseID;
        BindingContext = new CourseInfoViewModel(storedCourseID, storedTermID);
    }

    //private void Switch_Toggled(object sender, ToggledEventArgs e)
    //{
    //    var switchControl = (Switch)sender;
    //    if (switchControl.IsToggled)
    //    {
    //        DisplayAlert("YAY", "YAY", "OK");
    //    }
    //}

    //private void end_Toggled(object sender, ToggledEventArgs e)
    //{
    //    var switchControl = (Switch)sender;
    //    if (switchControl.IsToggled)
    //    {
    //        DisplayAlert("YAY", "YAY", "OK");
    //    }
    //}
}