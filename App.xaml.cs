using C971.MVVM.Views;
using C971.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace C971;

public partial class App : Application
{
	public static AcademicTermRepository AcademicTermRepo { get; private set; }
	public App(AcademicTermRepository termRepo)
	{
		InitializeComponent();

		MainPage = new NavigationPage();

		AcademicTermRepo = termRepo;

		InitializeDatabase();
	}

    private void InitializeDatabase()
    {
        AcademicTermRepo.Init();
        AcademicTermRepo.InitializeData();

        MainPage = new NavigationPage(new TermView());
    }
}
