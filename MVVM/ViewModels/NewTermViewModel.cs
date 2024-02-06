
using C971.MVVM.Models;
using C971.MVVM.Views;
using C971.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace C971.MVVM.ViewModels
{
    public class NewTermViewModel : INotifyPropertyChanged
    {
        private string termName;
        public string TermName
        {
            get => termName;
            set
            {
                if (termName != value)
                {
                    termName = value ?? string.Empty;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand Submit { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewTermViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddMonths(1);
            Submit = new Command(SubmitClicked);
        }

        private void SubmitClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(TermName))
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Term name cannot be null!", "OK");
                    return;
                }

                if (StartDate > EndDate)
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "Start date cannot be before end date!", "OK");
                    return;
                }
                

                var newTerm = new AcademicTerm
                {
                    termName = TermName,
                    termStartDate = StartDate,
                    termEndDate = EndDate
                };

                App.AcademicTermRepo.Add(newTerm);

                //Application.Current.MainPage.Navigation.PushAsync(new TermView());
                Application.Current.MainPage = new NavigationPage(new TermView());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }
    }
}
