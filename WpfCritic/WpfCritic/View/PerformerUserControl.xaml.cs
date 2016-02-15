using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class PerformerUserControl : UserControl
    {
        public PerformerUserControl()
        {
            InitializeComponent();

            Logger.Info("PerformerUserControl.PerformerUserControl", "Екземпляр PerformerUserControl створений.");
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("PerformerUserControl.SearchButton_Click", "Натиснута кнопка Пошук.");

            ((PerformerUserControlVM)DataContext).SearchButtonClick();

            Logger.Info("PerformerUserControl.SearchButton_Click", "Оброблений натиск кнопки Пошук.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("PerformerUserControl.addButton_Click", "Натиснута кнопка Додати.");

            ((PerformerUserControlVM)DataContext).AddButtonClick();

            Logger.Info("PerformerUserControl.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("PerformerUserControl.editButton_Click", "Натиснута кнопка Редагувати.");

            ((PerformerUserControlVM)DataContext).EditButtonClick();

            Logger.Info("PerformerUserControl.editButton_Click", "Оброблений натиск кнопки Редагувати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("PerformerUserControl.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((PerformerUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("PerformerUserControl.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }

        private void PerformersListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Logger.Info("PerformerUserControl.PerformersListBox_MouseDoubleClick", "Почата обробка подвійного натискання на PerformersListBox.");

            ((PerformerUserControlVM)DataContext).PerformersListBoxMouseDoubleClick();

            Logger.Info("PerformerUserControl.PerformersListBox_MouseDoubleClick", "Завершена обробка подвійного натискання на PerformersListBox.");
        }

    }
}
