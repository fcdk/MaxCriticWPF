using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddSongWindow : Window
    {
        public EditOrAddSongWindow(ICollectionsEntity entity, SongVM song = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddSongWindowVM(entity, song);
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
