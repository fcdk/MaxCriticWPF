using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            DataContext = new AuthorizationWindowVM();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hashedPassword = new StringBuilder();
            byte[] hash = crypt.ComputeHash(Encoding.UTF8.GetBytes(passwordBox.Password), 0, Encoding.UTF8.GetByteCount(passwordBox.Password));
            foreach (byte theByte in hash)
            {
                hashedPassword.Append(theByte.ToString("x2"));
            }

            if(((AuthorizationWindowVM)DataContext).OkButtonClick(hashedPassword.ToString()))
                this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
