using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EntertainmentDetailsWindow : Window
    {
        public EntertainmentDetailsWindow(EntertainmentVM _entertainment)
        {
            InitializeComponent();

            DataContext = new EntertainmentDetailsWindowVM(_entertainment);
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

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
