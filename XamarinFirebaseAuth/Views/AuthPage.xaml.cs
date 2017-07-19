using Xamarin.Forms;
using XamarinFirebaseAuth.ViewModel;

namespace XamarinFirebaseAuth
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();

            // bind the context to the view model
            BindingContext = new AuthPageViewModel();

        }
    }
}
