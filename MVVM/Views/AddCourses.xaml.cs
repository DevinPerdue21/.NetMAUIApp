using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;

public partial class AddCourses : ContentPage
{
	public AddCourses(int selectedTermID)
	{
		InitializeComponent();
		BindingContext = new AddCoursesViewModel(selectedTermID);
	}
}