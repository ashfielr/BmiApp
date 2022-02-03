using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using BMIapp1._0.Models;

namespace BMIapp1._0.ViewModels
{
    internal class HistoryPageViewModel : BaseViewModel
    {
        public ObservableCollection<string> SavedBMIsCollection
        {
            get => SavedBMIs.Instance.GetSavedBMIs();
        }
    }
}
