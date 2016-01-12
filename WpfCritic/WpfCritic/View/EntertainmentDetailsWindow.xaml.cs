using System;
using System.Windows;
using System.Windows.Navigation;
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

            YoutubeVideo.Source = new Uri(_entertainment.TrailerLink.Replace("https://www.youtube.com/watch?v=", "https://www.youtube.com/embed/"));
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ((EntertainmentDetailsWindowVM)DataContext).RequestNavigate(e);
        }
    }
}
