using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class GenreUserControl : UserControl
    {
        public GenreUserControl()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((GenreUserControlVM)DataContext).SearchButtonClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((GenreUserControlVM)DataContext).AddButtonClick();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ((GenreUserControlVM)DataContext).EditButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((GenreUserControlVM)DataContext).DeleteButtonClick();
        }

    }
}
