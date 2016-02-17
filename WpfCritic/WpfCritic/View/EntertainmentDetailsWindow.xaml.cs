using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using WpfCritic.Core;
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

            YoutubeVideo.Navigate(new Uri(_entertainment.TrailerLink.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/")));

            Logger.Info("EntertainmentDetailsWindow.EntertainmentDetailsWindow", "Екземпляр EntertainmentDetailsWindow створений.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentDetailsWindow.cancelButton_Click", "Натиснута кнопка Закрити.");

            this.Close();

            Logger.Info("EntertainmentDetailsWindow.cancelButton_Click", "Оброблений натиск кнопки Закрити.");
        }

        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Logger.Info("EntertainmentDetailsWindow.RequestNavigate", "Початий перехід по посиланню на сторонній сайт.");

            ((EntertainmentDetailsWindowVM)DataContext).RequestNavigate(e);

            Logger.Info("EntertainmentDetailsWindow.RequestNavigate", "Завершений перехід по посиланню на сторонній сайт.");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Logger.Info("EntertainmentDetailsWindow.Window_Closing", "Почате оброблення закриття вікна.");

            ((EntertainmentDetailsWindowVM)DataContext).WindowClosing(sender);

            Logger.Info("EntertainmentDetailsWindow.Window_Closing", "Завершене оброблення закриття вікна.");
        }

        //private async void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Logger.Info("EntertainmentDetailsWindow.Window_Loaded", "Почате асинхронне оброблення події після завантаження вікна.");

        //    await YoutubeVideoInitialize();

        //    Logger.Info("EntertainmentDetailsWindow.Window_Closing", "Завершене асинхронне оброблення закриття вікна.");
        //}

        //private async Task YoutubeVideoInitialize()
        //{
        //    await Task.Run(() =>
        //    {
        //        if (_entertainment.TrailerLink != String.Empty)
        //            YoutubeVideo.Dispatcher.InvokeAsync(new Action(() =>
        //          {
        //              YoutubeVideo.Navigate(new Uri(_entertainment.TrailerLink.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/")));
        //          }));
        //    });
        //}

    }
}
