using System.ComponentModel;
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

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).AddButtonClick();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).SearchButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentUserControlVM)DataContext).deleteButtonClick();
        }
    }
}
