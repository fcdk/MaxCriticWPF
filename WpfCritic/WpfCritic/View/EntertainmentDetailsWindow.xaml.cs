using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EntertainmentDetailsWindow : Window
    {
        private EntertainmentVM _entertainment;
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();

        public EntertainmentDetailsWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            _entertainment = entertainment;

            DataContext = new EntertainmentDetailsWindowVM(_entertainment);

            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_entertainment.TrailerLink != String.Empty)
                    YoutubeVideo.Dispatcher.Invoke( new Action( () =>
                    {
                        YoutubeVideo.Navigate(new Uri(_entertainment.TrailerLink.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/")));
                    } ));
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ((EntertainmentDetailsWindowVM)DataContext).RequestNavigate(e);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((EntertainmentDetailsWindowVM)DataContext).WindowClosing(sender);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await YoutubeVideoInitialize();
        }

        private async Task YoutubeVideoInitialize()
        {
            await Task.Run(() =>
            {
                if (_entertainment.TrailerLink != String.Empty)
                    YoutubeVideo.Dispatcher.InvokeAsync(new Action(() =>
                  {
                      YoutubeVideo.Navigate(new Uri(_entertainment.TrailerLink.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/")));
                  }));
            });
        }

    }
}
