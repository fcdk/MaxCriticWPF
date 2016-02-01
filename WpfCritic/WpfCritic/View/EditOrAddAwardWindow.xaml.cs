using System.Windows;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddAwardWindow : Window
    {
        public EditOrAddAwardWindow(ICollectionsEntity entity, AwardVM award = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddAwardWindowVM(entity, award);
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddAwardWindowVM)DataContext).ImageButtonClick();
        }

        private void ImageClearButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditOrAddAwardWindowVM)DataContext).ImageClearButtonClick();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (((EditOrAddAwardWindowVM)DataContext).OkButtonClick())
                this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
