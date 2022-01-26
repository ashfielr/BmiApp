using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIapp1._0.Views
{
    public partial class MainPage : ContentPage
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
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double heightMeters = Height / 100;
            BMI = Weight / (heightMeters * heightMeters);
        }
    }
}