using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EntertainmentUserControl : UserControl
    {
        public EntertainmentUserControl()
        {
            InitializeComponent();
        }

        private void EntertainmentsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).EntertainmentsListBoxMouseDoubleClick();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).SearchButtonClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).AddButtonClick();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).EditButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).DeleteButtonClick();
        }

        private void songButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).SongButtonClick();
        }

        private void genreButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).GenreButtonClick();
        }
    }
}
