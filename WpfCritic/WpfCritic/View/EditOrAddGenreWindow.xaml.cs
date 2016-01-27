using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddGenreWindow : Window
    {
        public EditOrAddGenreWindow(ICollectionsEntity entity, GenreVM genre = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddGenreWindowVM(entity, genre);
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (((EditOrAddGenreWindowVM)DataContext).OkButtonClick())
                this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
