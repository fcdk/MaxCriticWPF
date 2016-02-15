using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddEntertainmentWindow : Window
    {
        public EditOrAddEntertainmentWindow(ICollectionsEntity entity, EntertainmentVM entertainment = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddEntertainmentWindowVM(entity, entertainment);

            Logger.Info("EditOrAddEntertainmentWindow.EditOrAddEntertainmentWindow", "Екземпляр EditOrAddEntertainmentWindow створений.");
        }

        private void entertainmentTypeUkrComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Logger.Info("EditOrAddEntertainmentWindow.entertainmentTypeUkrComboBox_SelectionChanged", "Почата обробка зміни типу фільма для пошуку.");

            ((EditOrAddEntertainmentWindowVM)DataContext).entertainmentTypeUkrComboBoxSelectionChanged();

            Logger.Info("EditOrAddEntertainmentWindow.entertainmentTypeUkrComboBox_SelectionChanged", "Закінчена обробка зміни типу фільма для пошуку.");
        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddEntertainmentWindow.posterBrowseButton_Click", "Натиснута кнопка Обзор.");

            ((EditOrAddEntertainmentWindowVM)DataContext).PosterBrowseButtonClick();

            Logger.Info("EditOrAddEntertainmentWindow.posterBrowseButton_Click", "Оброблений натиск кнопки Обзор.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddEntertainmentWindow.okButton_Click", "Натиснута кнопка ОК.");

            if (((EditOrAddEntertainmentWindowVM)DataContext).OkButtonClick())
                this.Close();

            Logger.Info("EditOrAddEntertainmentWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddEntertainmentWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddEntertainmentWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
