using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFirebaseAuth.Interfaces;
namespace XamarinFirebaseAuth.ViewModel
{
    public class AuthPageViewModel : INotifyPropertyChanged
    {
        private string _email;
        private string _password;
        private bool _isBusy;
        private Command _loginCommand;
        private Command _signUpCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        public AuthPageViewModel()
        {
            // execute if we're not busy
            //LoginCommand = new Command(async () => await Login(),
            //    () => !IsBusy);

            LoginCommand = new Command(Login);

            // execute if we're not busy
            //SignUpCommand = new Command(async () => await SignUp(),
            //    () => !IsBusy);
            SignUpCommand = new Command(SignUp);
        }
        #region Properties
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

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();

                // re-evaluate if we can execute again
                LoginCommand.ChangeCanExecute();
                SignUpCommand.ChangeCanExecute();
            }
        }
        #endregion

        #region Functions

        public Command LoginCommand
        {
            get
            {
                return _loginCommand;
            }
            set
            {
                _loginCommand = value;
            }
        }

        public Command SignUpCommand
        {
            get
            {               
                return _signUpCommand;
            }
            set
            {
                _signUpCommand = value;
            }
        }

        private void Login()
        {
            //await DependencyService.Get<IAuthentication>().Login(Email, Password).ContinueWith((task) => { IsBusy = false; });
            DependencyService.Get<IAuthentication>().Login(Email, Password);
        }

        private void SignUp()
        {
            //DependencyService.Get<IAuthentication>().SignUp(Email, Password).ContinueWith((task) => { IsBusy = false; });
            DependencyService.Get<IAuthentication>().SignUp(Email, Password);
        }

        /// <summary>
        /// Used to notify bound items that a property has changed
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Used so a UI Label can bind to the Email property
        /// </summary>
        public string DisplayMessage
        {
            get
            {
                return $"Hi {Email}\nWelcome to XamarinFirebaseAuth";
            }
        }
        #endregion

    }
}
