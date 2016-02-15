using System.Configuration;
using WpfCritic.DataLayer;
using WpfCritic.View;

namespace WpfCritic.ViewModel
{
    [ConnectionName("MaxCritic")]
    public class AuthorizationWindowVM : ViewModelBase
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged("Login"); }
        }

        internal bool OkButtonClick(string hashedPassword)
        {
            string _connectionName = ((ConnectionNameAttribute)typeof(AuthorizationWindowVM).GetCustomAttributes(typeof(ConnectionNameAttribute), false)[0]).Name;

            string connectionString = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString +
            "User ID=" + Login + ";Password=" + hashedPassword + ";";

            Connection.Instance.ConnectionString = connectionString;

            if (Connection.Instance.IsReady)
            {
                Connection.Instance.Login = Login;
                MainMenuWindow mainMenu = new MainMenuWindow();
                mainMenu.Show();
                return true;
            }
            return false;
        }
    }
}
