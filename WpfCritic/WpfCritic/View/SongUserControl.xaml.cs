using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class SongUserControl : UserControl
    {
        public SongUserControl()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((SongUserControlVM)DataContext).SearchButtonClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((SongUserControlVM)DataContext).AddButtonClick();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ((SongUserControlVM)DataContext).EditButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((SongUserControlVM)DataContext).DeleteButtonClick();
        }

    }
}
