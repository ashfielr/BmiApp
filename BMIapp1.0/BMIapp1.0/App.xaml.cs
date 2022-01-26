using BMIapp1._0.Services;
using BMIapp1._0.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIapp1._0
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
