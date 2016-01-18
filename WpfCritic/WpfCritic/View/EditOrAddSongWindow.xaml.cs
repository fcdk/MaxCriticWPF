using System.Windows;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EditOrAddSongWindow : Window
    {
        public EditOrAddSongWindow(EditOrAddSongWindowVM viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (((EditOrAddSongWindowVM)DataContext).OkButtonClick())
                this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
