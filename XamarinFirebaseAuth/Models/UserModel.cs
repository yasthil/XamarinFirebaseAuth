using System;
using GalaSoft.MvvmLight;

namespace XamarinFirebaseAuth.Models
{
    /// <summary>
    /// Respresents a single User and their data
    /// </summary>
    public class UserModel : ObservableObject
    {
        private string _username;
        private string _password;
        public UserModel()
        {
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
