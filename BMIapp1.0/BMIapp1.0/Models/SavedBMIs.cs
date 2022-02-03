using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;

namespace BMIapp1._0.Models
{
    internal class SavedBMIs
    {
        private static SavedBMIs _instance;

        private static ObservableCollection<string> _savedBMIs;

        private SavedBMIs()
        {

        }

        public static SavedBMIs Instance => _instance ?? (_instance = new SavedBMIs());

        public void Initialise(ObservableCollection<string> savedBMIs)
        {
            _savedBMIs = savedBMIs;
        }

        public ObservableCollection<string> GetSavedBMIs()
        {
            return _savedBMIs;
        }

        public void Add(string newBMI)
        {
            _savedBMIs.Add(newBMI);
        }

    }
}
