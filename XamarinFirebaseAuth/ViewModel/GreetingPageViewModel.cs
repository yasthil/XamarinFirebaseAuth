using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinFirebaseAuth.ViewModel
{
    public class GreetingPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _message;

        public GreetingPageViewModel()
        {

        }

        #region Properties


        string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Used to notify bound items that a property has changed
        /// </summary>
        /// <param name="name"></param>
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
