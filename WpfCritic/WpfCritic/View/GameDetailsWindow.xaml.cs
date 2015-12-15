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
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    /// <summary>
    /// Логика взаимодействия для GameDetailsWindow.xaml
    /// </summary>
    public partial class GameDetailsWindow : Window
    {
        private GameDetailsWindowVM _viewModel = new GameDetailsWindowVM();
        public GameDetailsWindowVM ViewModel
        {
            get { return _viewModel; }
        }

        public GameDetailsWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            Logger.Info("GameDetailsWindow", "Окно с подробной информацией об игре создано");
        }

        private void playCenterButton_Click(object sender, RoutedEventArgs e)
        {
            trailer.Play();
            ((Button)sender).Visibility = Visibility.Hidden;
        }

        private void playDownButton_Click(object sender, RoutedEventArgs e)
        {
            trailer.Play();
            playCenterButton.Visibility = Visibility.Hidden;
        }

        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            trailer.Pause();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            trailer.Stop();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            trailer.Stop();
        }

        private void Ellipse_MouseEnter(object sender, MouseEventArgs e)
        {
            ((GameDetailsWindowVM)DataContext).EllipseMouseEnter(sender);
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            ((GameDetailsWindowVM)DataContext).EllipseMouseLeave(sender);
        }

        private void addReview_Click(object sender, RoutedEventArgs e)
        {
            ((GameDetailsWindowVM)DataContext).AddReviewClick();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GameDetailsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            trailer.Stop();
        }
    }
}
