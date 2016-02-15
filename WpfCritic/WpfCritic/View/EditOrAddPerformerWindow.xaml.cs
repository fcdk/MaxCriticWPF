using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
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

            Logger.Info("EditOrAddPerformerWindow.EditOrAddPerformerWindow", "Екземпляр EditOrAddPerformerWindow створений.");
        }

        private void performerTypeUkrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerWindow.performerTypeUkrComboBox_SelectionChanged", "Почата обробка зміни типу виконавця для пошуку.");

            ((EditOrAddPerformerWindowVM)DataContext).PerformerTypeUkrComboBoxSelectionChanged();

            Logger.Info("EditOrAddPerformerWindow.performerTypeUkrComboBox_SelectionChanged", "Закінчена обробка зміни типу виконавця для пошуку.");
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerWindow.ImageButton_Click", "Натиснута кнопка додавання зображення.");

            ((EditOrAddPerformerWindowVM)DataContext).ImageButtonClick();

            Logger.Info("EditOrAddPerformerWindow.ImageButton_Click", "Оброблений натиск кнопки додавання зображення.");
        }

        private void ImageClearButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerWindow.ImageClearButton_Click", "Натиснута кнопка видалення зображення.");

            ((EditOrAddPerformerWindowVM)DataContext).ImageClearButtonClick();

            Logger.Info("EditOrAddPerformerWindow.ImageClearButton_Click", "Оброблений натиск кнопки видалення зображення.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerWindow.okButton_Click", "Натиснута кнопка ОК.");

            if (((EditOrAddPerformerWindowVM)DataContext).OkButtonClick())
                this.Close();

            Logger.Info("EditOrAddPerformerWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddPerformerWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }
                
    }
}
