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
        private double _height;
        private double _width;
        private BmiCalculation _bmiCalculation;

        public double Height
        {
            get => _height;
            set
            {
                if (value != _height)
                {
                    _height = value;
                    CalculateBMICommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        public double Weight
        {
            get => _width;
            set
            {
                if (value != _width)
                {
                    _width = value;
                    CalculateBMICommand.ChangeCanExecute();
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        public double BMI
        {
            get
            {
                if (_bmiCalculation == null)
                    return 0.0;
                else
                    return _bmiCalculation.BMI;
            }
        }

        private bool ValidBmiCalculated()
        {
            return _bmiCalculation != null;
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
        public ICommand NavigateToNextPageCommand { get; set; }
        public Command SaveBmiCommand { get; set; }

        public Command ViewHistoryPageCommand { get; set; }

        /// <summary>
        /// Creates a new BMI calculation object with the Height and Weight
        /// </summary>
        public void CalculateBmi()
        {
            _bmiCalculation = new BmiCalculation(Height, Weight);
            OnPropertyChanged(nameof(BMI));
            SaveBmiCommand.ChangeCanExecute();
        }

        /// <summary>
        /// Adds a NextPage content page to the navigation stack
        /// </summary>
        public void NavigateToNextPage()
        {
            // navigation goes here
            var nextPage = new NextPage();  // this is not testable as we are instantiating an Xarmarin Form Page
            NavigationDispatcher.Instance.Navigation.PushAsync(nextPage);
        }

        /// <summary>
        /// Saves the current BMI calculation
        /// </summary>
        public void SaveBmi()
        {
            string bmiString = _bmiCalculation.ToString();
            SavedBMIs.Instance.Add(bmiString);
            OnPropertyChanged(nameof(SavedBMIsCollection));
        }

        /// <summary>
        /// Adds HistoryPage to navigation stack as modal
        /// </summary>
        public void ViewHistoryPage()
        {
            var historyPage = new HistoryPage();
            NavigationDispatcher.Instance.Navigation.PushModalAsync(historyPage);
        }
    }
}