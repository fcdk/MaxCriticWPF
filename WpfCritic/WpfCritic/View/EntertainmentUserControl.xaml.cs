using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EntertainmentUserControl : UserControl
    {
        private EnterteinmentUserControlVM _viewModel = new EnterteinmentUserControlVM();
        public EnterteinmentUserControlVM ViewModel
        {
            get { return _viewModel; }
        }

        public EntertainmentUserControl()
        {
            InitializeComponent();

            _viewModel.LoadData();
        }

        private void GamesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((EnterteinmentUserControlVM)DataContext).GamesListBoxMouseDoubleClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EnterteinmentUserControlVM)DataContext).AddButtonClick();
        }

        private void AllGamesWindow_Closing(object sender, CancelEventArgs e)
        {
            ((EnterteinmentUserControlVM)DataContext).AllGamesWindowClosing();
        }
    }
}
