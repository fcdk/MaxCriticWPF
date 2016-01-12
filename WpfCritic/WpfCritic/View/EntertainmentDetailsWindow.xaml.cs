using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class GameDetailsWindow : Window
    {
        private EntertainmentDetailsWindowVM _viewModel = new EntertainmentDetailsWindowVM();
        public EntertainmentDetailsWindowVM ViewModel
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
            ((EntertainmentDetailsWindowVM)DataContext).EllipseMouseEnter(sender);
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            ((EntertainmentDetailsWindowVM)DataContext).EllipseMouseLeave(sender);
        }

        private void addReview_Click(object sender, RoutedEventArgs e)
        {
            ((EntertainmentDetailsWindowVM)DataContext).AddReviewClick();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
