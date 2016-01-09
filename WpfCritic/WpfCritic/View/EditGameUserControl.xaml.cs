using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EditGameUserControl : UserControl
    {
        public EditGameUserControl()
        {
            InitializeComponent();
        }

        private void trailerBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditGameUserControlVM)DataContext).TrailerBrowseButtonClick();
        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditGameUserControlVM)DataContext).PosterBrowseButtonClick();
        }
    }
}
