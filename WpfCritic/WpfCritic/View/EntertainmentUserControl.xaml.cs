using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EntertainmentUserControl : UserControl
    {
        public EntertainmentUserControl()
        {
            InitializeComponent();

            Logger.Info("EntertainmentUserControl.EntertainmentUserControl", "Екземпляр EntertainmentUserControl створений.");
        }

        private void EntertainmentsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.EntertainmentsListBox_MouseDoubleClick", "Почата обробка подвійного натискання на EntertainmentsListBox.");

            ((EntertainmentUserControlVM)DataContext).EntertainmentsListBoxMouseDoubleClick();

            Logger.Info("EntertainmentUserControl.EntertainmentsListBox_MouseDoubleClick", "Завершена обробка подвійного натискання на EntertainmentsListBox.");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.SearchButton_Click", "Натиснута кнопка Пошук.");

            ((EntertainmentUserControlVM)DataContext).SearchButtonClick();

            Logger.Info("EntertainmentUserControl.SearchButton_Click", "Оброблений натиск кнопки Пошук.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.addButton_Click", "Натиснута кнопка Додати.");

            ((EntertainmentUserControlVM)DataContext).AddButtonClick();

            Logger.Info("EntertainmentUserControl.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.editButton_Click", "Натиснута кнопка Редагувати.");

            ((EntertainmentUserControlVM)DataContext).EditButtonClick();

            Logger.Info("EntertainmentUserControl.editButton_Click", "Оброблений натиск кнопки Редагувати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((EntertainmentUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("EntertainmentUserControl.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

        private void songButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.songButton_Click", "Натиснута кнопка Додавання пісні.");

            ((EntertainmentUserControlVM)DataContext).SongButtonClick();

            Logger.Info("EntertainmentUserControl.songButton_Click", "Оброблений натиск кнопки Додавання пісні.");
        }

        private void genreButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.genreButton_Click", "Натиснута кнопка Додавання жанра.");

            ((EntertainmentUserControlVM)DataContext).GenreButtonClick();

            Logger.Info("EntertainmentUserControl.genreButton_Click", "Оброблений натиск кнопки Додавання жанра.");
        }

        private void performerButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EntertainmentUserControl.performerButton_Click", "Натиснута кнопка Додавання виконавців.");

            ((EntertainmentUserControlVM)DataContext).PerformerButtonClick();

            Logger.Info("EntertainmentUserControl.performerButton_Click", "Оброблений натиск кнопки Додавання виконавців.");
        }
    }
}
