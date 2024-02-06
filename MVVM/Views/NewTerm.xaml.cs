using C971.MVVM.Models;
using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;

public partial class NewTerm : ContentPage
{
	public NewTerm()
	{
		InitializeComponent();
        BindingContext = new NewTermViewModel();
	}
    //private void Button_Clicked_1(object sender, EventArgs e)
    //{
    //    var Name = TermName.Text;
    //    var start = StartDate.Date;
    //    var end = EndDate.Date;

    //    if (start > end)
    //    {
    //        DisplayAlert("Alert", "Start date cannot be before end date!", "OK");
    //    }

    //    if (string.IsNullOrWhiteSpace(Name))
    //    {
    //        DisplayAlert("Alert", "Term name cannot be empty!", "OK");
    //    }
    //}

}