using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirebaseAuth.Interfaces
{
    /// <summary>
    /// Provides an easy to use interface for all authentication operations
    /// </summary>
    public interface IAuthentication
    {
        void SignUp(string email, string password);
        void Login(string email, string password);
        void SignOut();
        bool IsBusy();
        event EventHandler<FirebaseAuthEventData> CustomAuthStateChanged;
    }

}
