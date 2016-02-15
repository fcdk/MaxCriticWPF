using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class GenreUserControl : UserControl
    {
        public GenreUserControl()
        {
            InitializeComponent();

            Logger.Info("GenreUserControl.GenreUserControl", "Екземпляр GenreUserControl створений.");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("GenreUserControl.SearchButton_Click", "Натиснута кнопка Пошук.");

            ((GenreUserControlVM)DataContext).SearchButtonClick();

            Logger.Info("GenreUserControl.SearchButton_Click", "Оброблений натиск кнопки Пошук.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("GenreUserControl.addButton_Click", "Натиснута кнопка Додати.");

            ((GenreUserControlVM)DataContext).AddButtonClick();

            Logger.Info("GenreUserControl.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("GenreUserControl.editButton_Click", "Натиснута кнопка Редагувати.");

            ((GenreUserControlVM)DataContext).EditButtonClick();

            Logger.Info("GenreUserControl.editButton_Click", "Оброблений натиск кнопки Редагувати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("GenreUserControl.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((GenreUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("GenreUserControl.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

    }
}
