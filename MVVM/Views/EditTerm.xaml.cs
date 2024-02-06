using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;

public partial class EditTerm : ContentPage
{
	public EditTerm(int storedTermID)
	{
		InitializeComponent();
		BindingContext = new EditTermViewModel(storedTermID);
	}
}