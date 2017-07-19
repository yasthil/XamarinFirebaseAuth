using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinFirebaseAuth.Droid.src;
using Firebase.Auth;
using XamarinFirebaseAuth.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationAndroid))]
namespace XamarinFirebaseAuth.Droid.src
{
    class AuthenticationAndroid : Interfaces.IAuthentication
    {
        private bool _isSignUp = false;
        private bool _isLogin = false;        
        private bool _hasLoggedIn;

        public event EventHandler<FirebaseAuthEventData> CustomAuthStateChanged;

        /// <summary>
        /// Used to login the user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async void Login(string email, string password)
        {
            try
            {
                _isLogin = true;

                // create event listener so we know when the user has sucessfully signed in
                FirebaseAuth.Instance.AuthState += AuthStateChanged;
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            }
            catch (Exception ex)
            {
                // Sign-in failed, display a message to the user
                // If sign in succeeds, the AuthState event handler will
                //  be notified and logic to handle the signed in user can happen there
                _isLogin = false;
                _hasLoggedIn = false;
                OnCustomAuthStateChanged();
                Toast.MakeText(Xamarin.Forms.Forms.Context, "Login failed. " + ex.Message, ToastLength.Short).Show();
            }
        }


        /// <summary>
        /// Used to sign up the user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public async void SignUp(string email, string password)
        {
            try
            {
                _isSignUp = true;

                // create event listener so we know when the user has sucessfully signed in
                FirebaseAuth.Instance.AuthState += AuthStateChanged;
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            }
            catch (Exception ex)
            {
                // Sign-up failed, display a message to the user
                // If sign in succeeds, the AuthState event handler will
                //  be notified and logic to handle the signed in user can happen there
                _isSignUp = false;
                _hasLoggedIn = false;
                OnCustomAuthStateChanged();
                Toast.MakeText(Xamarin.Forms.Forms.Context, "Sign Up failed. " + ex.Message, ToastLength.Short).Show();
            }
        }

        /// <summary>
        /// Fires when there's a Firebase authentication state change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AuthStateChanged(object sender, FirebaseAuth.AuthStateEventArgs e)
        {
           
            if (e.Auth.CurrentUser != null) // User is signed in
            {
                if (_isLogin)
                {
                    // user logged in successfully
                    _hasLoggedIn = true;
                }
                else if (_isSignUp)
                {
                    // user signed up and logged in successfully
                    _hasLoggedIn = true;
                }

                FirebaseAuth.Instance.AuthState -= AuthStateChanged;
                OnCustomAuthStateChanged();
            }
            else
            {
                // User is signed out
                // tell the view that the login/sign up was successfull
                _hasLoggedIn = false;
            }
        }
        
        

        public void OnCustomAuthStateChanged()
        {            
            CustomAuthStateChanged?.Invoke(this, new FirebaseAuthEventData(_isLogin, _isSignUp, _hasLoggedIn));
        }

        /// <summary>
        /// sign out any other user that may have been already signed in
        /// </summary>
        void IAuthentication.SignOut()
        {
            if (FirebaseAuth.Instance.CurrentUser != null)
            {
                FirebaseAuth.Instance.SignOut();
            }
        }

        public bool IsBusy()
        {
            throw new NotImplementedException();
        }
    }
}