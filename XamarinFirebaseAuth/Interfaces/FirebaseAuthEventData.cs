using System;

namespace XamarinFirebaseAuth.Interfaces
{
    public class FirebaseAuthEventData : EventArgs
    {
        private bool _isLoginRequest;
        private bool _isSignUpRequest;
        private bool _hasLoggedIn;

        public FirebaseAuthEventData(bool isLoginRequest, bool isSignUpRequest,bool hasLoggedIn)
        {
            _isLoginRequest = isLoginRequest;
            _isSignUpRequest = isSignUpRequest;
            _hasLoggedIn = hasLoggedIn;
        }

        public bool HasLoggedIn
        {
            get { return _hasLoggedIn; }
            set { _hasLoggedIn = value; }
        }

        public bool IsLoginRequest
        {
            get { return _isLoginRequest; }
            set { _isLoginRequest = value; }
        }
        public bool IsSignUpRequest
        {
            get { return _isSignUpRequest; }
            set { _isSignUpRequest = value; }
        }
    }
}