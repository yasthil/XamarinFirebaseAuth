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
        private IAuthentication _iAuthService;

        public event PropertyChangedEventHandler PropertyChanged;

        public AuthPageViewModel()
        {
            LoginCommand = new Command(Login);
            SignUpCommand = new Command(SignUp);

            _iAuthService = DependencyService.Get<IAuthentication>();
            _iAuthService.SignOut();
            
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
            _iAuthService = DependencyService.Get<IAuthentication>();
            _iAuthService.SignOut();
            IsBusy = true;
            _iAuthService.CustomAuthStateChanged += OnCustomAuthStateChanged;          
            _iAuthService.Login(Email, Password);
        }

        private void SignUp()
        {
            _iAuthService = DependencyService.Get<IAuthentication>();
            _iAuthService.SignOut();
            IsBusy = true;
            _iAuthService.CustomAuthStateChanged += OnCustomAuthStateChanged;            
            _iAuthService.SignUp(Email, Password);
        }

        private void OnCustomAuthStateChanged(object sender, FirebaseAuthEventData e)
        {
            // whether we're logged in or failed to login, stop the ActivityIndicator
            IsBusy = false;

            // de-register the event listner - this prevents OnCustomAuthStateChanged from being called multiple times
            _iAuthService.CustomAuthStateChanged -= OnCustomAuthStateChanged;

            if (e.HasLoggedIn)
            {
                Email = "";
                Password = "";
                App.Current.MainPage.Navigation.PushAsync(new GreetingPage());
            }
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
