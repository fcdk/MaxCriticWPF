using System.Windows;
using System.Windows.Controls;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class EditOrAddPerformerInEntertainmentUserControl : UserControl
    {
        public EditOrAddPerformerInEntertainmentUserControl()
        {
            InitializeComponent();

            Logger.Info("EditOrAddPerformerInEntertainmentUserControl.EditOrAddPerformerInEntertainmentUserControl", "Екземпляр EditOrAddPerformerInEntertainmentUserControl створений.");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerInEntertainmentUserControl.addButton_Click", "Натиснута кнопка Додати.");

            ((EditOrAddPerformerInEntertainmentUserControlVM)DataContext).AddButtonClick();

            Logger.Info("EditOrAddPerformerInEntertainmentUserControl.addButton_Click", "Оброблений натиск кнопки Додати.");
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddPerformerInEntertainmentUserControl.deleteButton_Click", "Натиснута кнопка Видалити.");

            ((EditOrAddPerformerInEntertainmentUserControlVM)DataContext).DeleteButtonClick();

            Logger.Info("EditOrAddPerformerInEntertainmentUserControl.deleteButton_Click", "Оброблений натиск кнопки Видалити.");
        }
    }
}
