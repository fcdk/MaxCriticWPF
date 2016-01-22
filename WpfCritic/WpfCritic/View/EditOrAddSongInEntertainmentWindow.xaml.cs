using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddSongInEntertainmentWindow : Window
    {
        public EditOrAddSongInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddSongInEntertainmentWindowVM(entertainment);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddSongInEntertainmentWindowVM)DataContext).AddButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddSongInEntertainmentWindowVM)DataContext).DeleteButtonClick();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddSongInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
