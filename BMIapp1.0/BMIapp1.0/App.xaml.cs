using BMIapp1._0.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMIapp1._0.Navigation;

namespace BMIapp1._0
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());  // Navigation page provides us with navigation stack
            NavigationDispatcher.Instance.Initialise(MainPage.Navigation);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
