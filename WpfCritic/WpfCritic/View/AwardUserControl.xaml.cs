using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AwardUserControl : UserControl
    {
        public AwardUserControl()
        {
            InitializeComponent();

            Logger.Info("AwardUserControl.AwardUserControl", "Екземпляр AwardUserControl створений.");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.SearchButton_Click", "Натиснута кнопка Пошук.");

            ((AwardUserControlVM)DataContext).SearchButtonClick();

            Logger.Info("AuthorizationWindow.SearchButton_Click", "Оброблений натиск кнопки Пошук.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.addButton_Click", "Натиснута кнопка Додати.");

            ((AwardUserControlVM)DataContext).AddButtonClick();

            Logger.Info("AuthorizationWindow.SearchButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.editButton_Click", "Натиснута кнопка Редагувати.");

            ((AwardUserControlVM)DataContext).EditButtonClick();

            Logger.Info("AuthorizationWindow.editButton_Click", "Оброблений натиск кнопки Редагувати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((AwardUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("AuthorizationWindow.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

    }
}
