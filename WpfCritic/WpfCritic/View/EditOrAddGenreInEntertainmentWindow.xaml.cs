using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddGenreInEntertainmentWindow : Window
    {
        public EditOrAddGenreInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddGenreInEntertainmentWindowVM(entertainment);

            Logger.Info("EditOrAddGenreInEntertainmentWindow.EditOrAddGenreInEntertainmentWindow", "Екземпляр EditOrAddGenreInEntertainmentWindow створений.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreInEntertainmentWindow.addButton_Click", "Натиснута кнопка Додати.");

            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).AddButtonClick();

            Logger.Info("EditOrAddGenreInEntertainmentWindow.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreInEntertainmentWindow.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).DeleteButtonClick();

            Logger.Info("EditOrAddGenreInEntertainmentWindow.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreInEntertainmentWindow.okButton_Click", "Натиснута кнопка ОК.");

            ((EditOrAddGenreInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();

            Logger.Info("EditOrAddGenreInEntertainmentWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreInEntertainmentWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddGenreInEntertainmentWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
