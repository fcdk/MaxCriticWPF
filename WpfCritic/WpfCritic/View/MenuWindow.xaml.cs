using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class MenuWindow : Window
    {

        private MenuWindowVM _viewModel = new MenuWindowVM();

        public MenuWindowVM ViewModel
        {
            get { return _viewModel; }
        }

        public MenuWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            Logger.Info("MenuWindow", "Форма с главным меню создана");
        }

        private void moviesShowButton_Click(object sender, RoutedEventArgs e)
        {
            //фильмы добавить
            this.Close();
        }

        private void gamesShowButton_Click(object sender, RoutedEventArgs e)
        {
            ((MenuWindowVM)DataContext).GamesShowButtonClick();
            this.Close();
        }

        private void musicShowButton_Click(object sender, RoutedEventArgs e)
        {
            //музыку добавить
            this.Close();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
