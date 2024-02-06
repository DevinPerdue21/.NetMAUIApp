using C971.MVVM.Models;
using C971.MVVM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C971.MVVM.ViewModels
{
    public class EditTermViewModel:INotifyPropertyChanged
    {
        private string termName;
        public string TermName
        {
            get { return termName; }
            set
            {
                if (termName != value)
                {
                    termName = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime termStartDate;
        public DateTime TermStartDate
        {
            get { return termStartDate; }
            set
            {
                if (termStartDate != value)
                {
                    termStartDate = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime termEndDate;
        public DateTime TermEndDate
        {
            get { return termEndDate; }
            set
            {
                if (termEndDate != value)
                {
                    termEndDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private int storedTermID;
        public int StoredTermID
        {
            get { return storedTermID; }
            set
            {
                if (storedTermID != value)
                {
                    storedTermID = value;
                    OnPropertyChanged(nameof(StoredTermID));
                }
            }
        }

        public ICommand Submit { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditTermViewModel(int storedTermID) 
        {
            StoredTermID = storedTermID;
            Submit = new Command(SubmitClicked);

            var courseNames1 = App.AcademicTermRepo.GetTermName(storedTermID);
            if (courseNames1.Count > 0)
            {
                TermName = courseNames1[0];
            }

            var courseNames2 = App.AcademicTermRepo.GetTermStart(storedTermID);
            if (courseNames2.Count > 0)
            {
                TermStartDate = courseNames2[0];
            }

            var courseNames3 = App.AcademicTermRepo.GetTermEnd(storedTermID);
            if (courseNames3.Count > 0)
            {
                TermEndDate = courseNames3[0];
            }

        }

        private void SubmitClicked()
        {
            var term = new AcademicTerm
            {
                termID = StoredTermID,
                termName = TermName,
                termStartDate = TermStartDate,
                termEndDate = TermEndDate
                
            };

            App.AcademicTermRepo.UpdateTerm(term);
            Application.Current.MainPage = new NavigationPage(new TermView());
        }

    }
}
