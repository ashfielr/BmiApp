using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using BMIapp1._0.Navigation;
using BMIapp1._0.Views;
using BMIapp1._0.Models;

namespace BMIapp1._0.ViewModels
{
    public class MainPageViewModel :  BaseViewModel
    {
        private double height;
        private double weight;
        private double bmi;

        public double Height
        {
            get => height;
            set
            {
                if (value != height)
                {
                    height = value;
                    CalculateBMICommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value != weight)
                {
                    weight = value;
                    CalculateBMICommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public double BMI
        {
            get => bmi;
            set
            {
                if (value != bmi)
                {
                    bmi = value;
                    OnPropertyChanged(nameof(BMI));
                    SaveBmiCommand.ChangeCanExecute();
                }
            }
        }

        private bool ValidBmiCalculated()
        {
            return BMI != 0;
        }

        public MainPageViewModel()
        {
            ObservableCollection<string> savedBMIsCollection = new ObservableCollection<string>();
            SavedBMIs.Instance.Initialise(savedBMIsCollection);
                                                    // Action, Func<Bool>
            CalculateBMICommand = new Command(CalculateBmi, () =>
            {
                return Weight != 0 && Height != 0; // CanExecute passed as anonymous    function
                                                    // will also disable/enalbe UI element Command is bound to
            });

            NavigateToNextPageCommand = new Command(NavigateToNextPage);  // Dont want a CanExecute so just pass action

            SaveBmiCommand = new Command(SaveBmi, () =>
            {
                return ValidBmiCalculated();
            });

            ViewHistoryPageCommand = new Command(ViewHistoryPage);
        }

        public ObservableCollection<string> SavedBMIsCollection
        {
            get => SavedBMIs.Instance.GetSavedBMIs();
        }

        public Command CalculateBMICommand { get; set; }
        public Command NavigateToNextPageCommand { get; set; }
        public Command SaveBmiCommand { get; set; }

        public Command ViewHistoryPageCommand { get; set; }

        public void CalculateBmi()
        {
            double heightMeters = Height / 100;
            BMI = Math.Round(Weight / (heightMeters * heightMeters),2);
        }

        public void NavigateToNextPage()
        {
            // navigation goes here
            var nextPage = new NextPage();  // this is not testable as we are instantiating an Xarmarin Form Page
            NavigationDispatcher.Instance.Navigation.PushAsync(nextPage);
        }

        public void SaveBmi()
        {
            string bmiString = $"{BMI.ToString()} {DateTime.Now.ToString()}";
            SavedBMIs.Instance.Add(bmiString);
            OnPropertyChanged(nameof(SavedBMIsCollection));
        }

        public void ViewHistoryPage()
        {
            var historyPage = new HistoryPage();
            NavigationDispatcher.Instance.Navigation.PushModalAsync(historyPage);
        }
    }
}