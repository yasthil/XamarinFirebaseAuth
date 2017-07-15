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

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
