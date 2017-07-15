using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinFirebaseAuth.ViewModel
{
    public class AuthPageViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify bound items that a property has changed
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AuthPageViewModel()
        {
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string DisplayMessage
        {
            get
            {
                return $"Hi {Email}\nWelcome to XamarinFirebaseAuth";
            }
        }
    }
}
