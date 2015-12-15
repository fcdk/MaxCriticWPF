using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    /// <summary>
    /// Логика взаимодействия для AllMusicWindow.xaml
    /// </summary>
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
