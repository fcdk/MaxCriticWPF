using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EditOrAddPerformerInEntertainmentUserControl : UserControl
    {
        public EditOrAddPerformerInEntertainmentUserControl()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddPerformerInEntertainmentUserControlVM)DataContext).AddButtonClick();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddPerformerInEntertainmentUserControlVM)DataContext).DeleteButtonClick();
        }
    }
}
