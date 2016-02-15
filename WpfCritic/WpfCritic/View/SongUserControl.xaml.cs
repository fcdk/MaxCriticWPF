using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class SongUserControl : UserControl
    {
        public SongUserControl()
        {
            InitializeComponent();

            Logger.Info("SongUserControl.SongUserControl", "Екземпляр SongUserControl створений.");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("SongUserControl.SearchButton_Click", "Натиснута кнопка Пошук.");

            ((SongUserControlVM)DataContext).SearchButtonClick();

            Logger.Info("SongUserControl.SearchButton_Click", "Оброблений натиск кнопки Пошук.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("SongUserControl.addButton_Click", "Натиснута кнопка Додати.");

            ((SongUserControlVM)DataContext).AddButtonClick();

            Logger.Info("SongUserControl.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("SongUserControl.editButton_Click", "Натиснута кнопка Редагувати.");

            ((SongUserControlVM)DataContext).EditButtonClick();

            Logger.Info("SongUserControl.editButton_Click", "Оброблений натиск кнопки Редагувати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("SongUserControl.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((SongUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("SongUserControl.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

    }
}
