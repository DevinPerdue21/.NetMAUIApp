using C971.MVVM.ViewModels;

namespace C971.MVVM.Views;


public partial class ViewCourseInfo : ContentPage
{
    private int selectedCourseID;
    private int storedCourseID;
    private int storedTermID1;
    public ViewCourseInfo(int selectedCourseID, int storedTermID)
	{
		InitializeComponent();
        storedCourseID = selectedCourseID;
        storedTermID1 = storedTermID;
        BindingContext = new ViewCourseInfoViewModel(storedCourseID, storedTermID);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new CourseInfo(storedCourseID, storedTermID1)));
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        string notes = "";
        var courseNames9 = App.AcademicTermRepo.GetOptionalNotes(storedCourseID);
        if (courseNames9.Count > 0)
        {
            notes = courseNames9[0];
        }
        ShareText(notes);

    }

    public async Task ShareText(string text)
    {
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = "Share Text"
        });
    }
}