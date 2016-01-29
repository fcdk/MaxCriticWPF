using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddPerformerInEntertainmentWindow : Window
    {
        public EditOrAddPerformerInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddPerformerInEntertainmentWindowVM(entertainment);
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddPerformerInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
