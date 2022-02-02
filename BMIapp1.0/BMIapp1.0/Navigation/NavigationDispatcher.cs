using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BMIapp1._0.Navigation
{
    internal class NavigationDispatcher
    {
        private static NavigationDispatcher _instance;

        private INavigation _navigation;

        public static NavigationDispatcher Instance =>
            _instance ?? (_instance = new NavigationDispatcher());

        public INavigation Navigation =>
            _navigation ?? throw new Exception("NavigationDispatcher is not initialised");

        public void Initialise(INavigation navigation)
        {
            _navigation = navigation;
        }

    }
}
