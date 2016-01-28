using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddGenreInEntertainmentWindow : Window
    {
        public EditOrAddGenreInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddGenreInEntertainmentWindowVM(entertainment);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).AddButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).DeleteButtonClick();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
