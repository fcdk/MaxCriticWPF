using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AwardUserControl : UserControl
    {
        public AwardUserControl()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((AwardUserControlVM)DataContext).SearchButtonClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((AwardUserControlVM)DataContext).AddButtonClick();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ((AwardUserControlVM)DataContext).EditButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((AwardUserControlVM)DataContext).DeleteButtonClick();
        }

    }
}
