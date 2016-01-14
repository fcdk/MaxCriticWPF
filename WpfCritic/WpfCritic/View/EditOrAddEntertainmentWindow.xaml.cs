using System.Windows;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EditOrAddEntertainmentWindow : Window
    {
        public EditOrAddEntertainmentWindow(EditOrAddEntertainmentWindowVM viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddEntertainmentWindowVM)DataContext).PosterBrowseButtonClick();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
