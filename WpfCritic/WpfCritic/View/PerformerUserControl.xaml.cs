using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class PerformerUserControl : UserControl
    {
        public PerformerUserControl()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ((PerformerUserControlVM)DataContext).SearchButtonClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((PerformerUserControlVM)DataContext).AddButtonClick();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            ((PerformerUserControlVM)DataContext).EditButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((PerformerUserControlVM)DataContext).DeleteButtonClick();
        }

        private void PerformersListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ((PerformerUserControlVM)DataContext).PerformersListBoxMouseDoubleClick();
        }

    }
}
