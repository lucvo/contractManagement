

namespace ContractorMgrt.Wpf.ViewModels
{
    using Caliburn.Micro;
    using System.ComponentModel.Composition;
    using System.Windows;
    [Export(typeof(IShell))]
    public class LoginViewModel : PropertyChangedBase, IShell
    {
        string username;
        public string Username {
            get { return username; }
            set {
                username = value;
                NotifyOfPropertyChange(() => Username);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public bool CanLogin
        {
            get
            {
                return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);
            }
        }

        public void Login()
        {
            MessageBox.Show("Login", "Succeed!!", MessageBoxButton.OK);
        }
    }
}
