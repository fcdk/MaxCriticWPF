using System.Windows;
using System.Windows.Controls;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddPerformerWindow : Window
    {
        public EditOrAddPerformerWindow(ICollectionsEntity entity, PerformerVM performer = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddPerformerWindowVM(entity, performer);
        }

        private void performerTypeUkrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((EditOrAddPerformerWindowVM)DataContext).PerformerTypeUkrComboBoxSelectionChanged();
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddPerformerWindowVM)DataContext).ImageButtonClick();
        }

        private void ImageClearButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddPerformerWindowVM)DataContext).ImageClearButtonClick();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (((EditOrAddPerformerWindowVM)DataContext).OkButtonClick())
                this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
                
    }
}
