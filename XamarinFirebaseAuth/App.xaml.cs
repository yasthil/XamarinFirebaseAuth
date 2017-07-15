using Xamarin.Forms;

namespace XamarinFirebaseAuth
{
    public partial class App : Application
    {
        private Page _navPage;

        public App()
        {
            InitializeComponent();
            
            _navPage = MainPage = new NavigationPage(new AuthPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
