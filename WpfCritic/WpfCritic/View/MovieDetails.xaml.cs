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
using Critic.Data;
using System.IO;
using System.Drawing.Imaging;
using WpfCritic.ViewModel;

namespace WpfCritic
{
    /// <summary>
    /// Логика взаимодействия для MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Window
    {
        private MovieDetailsVM _viewModel = new MovieDetailsVM();
        public MovieDetailsVM ViewModel
        {
            get { return _viewModel; }
        }

        public MovieDetails()
        {
            this.InitializeComponent();

            DataContext = _viewModel;
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
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0074FF"));
        }

        private void Ellipse_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00167C"));
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addReview_Click(object sender, RoutedEventArgs e)
        {
            NewReview nR = new NewReview(_viewModel.Movie);
            nR.ShowDialog();
        }
    }
}
