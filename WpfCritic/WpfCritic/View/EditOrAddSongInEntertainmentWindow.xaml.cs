using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddSongInEntertainmentWindow : Window
    {
        public EditOrAddSongInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddSongInEntertainmentWindowVM(entertainment);

            Logger.Info("EditOrAddSongInEntertainmentWindow.EditOrAddSongInEntertainmentWindow", "Екземпляр EditOrAddSongInEntertainmentWindow створений.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongInEntertainmentWindow.addButton_Click", "Натиснута кнопка Додати.");

            ((EditOrAddSongInEntertainmentWindowVM)DataContext).AddButtonClick();

            Logger.Info("EditOrAddSongInEntertainmentWindow.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongInEntertainmentWindow.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((EditOrAddSongInEntertainmentWindowVM)DataContext).DeleteButtonClick();

            Logger.Info("EditOrAddSongInEntertainmentWindow.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongInEntertainmentWindow.okButton_Click", "Натиснута кнопка ОК.");

            ((EditOrAddSongInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();

            Logger.Info("EditOrAddSongInEntertainmentWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongInEntertainmentWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddSongInEntertainmentWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
