using System.Windows;
using System.Windows.Input;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AllGamesWindow : Window
    {
        private AllGamesWindowVM _viewModel = new AllGamesWindowVM();
        public AllGamesWindowVM ViewModel
        {
            get { return _viewModel; }
        }

        public AllGamesWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            _viewModel.LoadData();

            Logger.Info("AllGamesWindow", "Форма со всеми играми создана");
        }

        private void GamesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((AllGamesWindowVM)DataContext).GamesListBoxMouseDoubleClick();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((AllGamesWindowVM)DataContext).AddButtonClick();
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            ((AllGamesWindowVM)DataContext).MenuButtonClick();
            this.Close();
        }

        private void AllGamesWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((AllGamesWindowVM)DataContext).AllGamesWindowClosing();
        }
    }
}
