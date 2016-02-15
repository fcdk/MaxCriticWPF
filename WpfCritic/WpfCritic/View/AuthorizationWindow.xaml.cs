using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            DataContext = new AuthorizationWindowVM();

            Logger.Info("AuthorizationWindow.AuthorizationWindow", "Екземпляр AuthorizationWindow створений.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.okButton_Click", "Натиснута кнопка ОК.");

            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hashedPassword = new StringBuilder();
            byte[] hash = crypt.ComputeHash(Encoding.UTF8.GetBytes(passwordBox.Password), 0, Encoding.UTF8.GetByteCount(passwordBox.Password));
            foreach (byte theByte in hash)
            {
                hashedPassword.Append(theByte.ToString("x2"));
            }

            if(((AuthorizationWindowVM)DataContext).OkButtonClick(hashedPassword.ToString()))
                this.Close();

            Logger.Info("AuthorizationWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.cancelButton_Click", "Натиснута кнопка Закрити.");

            this.Close();

            Logger.Info("AuthorizationWindow.cancelButton_Click", "Оброблений натиск кнопки Закрити.");
        }
    }
}
