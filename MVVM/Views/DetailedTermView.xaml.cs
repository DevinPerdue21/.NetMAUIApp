using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;

public partial class DetailedTermView : ContentPage
{
	public DetailedTermView(int selectedTermID)
	{
		InitializeComponent();
		BindingContext = new DetailedTermViewModel(selectedTermID);
	}
}