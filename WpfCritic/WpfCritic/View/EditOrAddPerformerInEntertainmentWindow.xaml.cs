using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddPerformerInEntertainmentWindow : Window
    {
        public EditOrAddPerformerInEntertainmentWindow(EntertainmentVM entertainment)
        {
            InitializeComponent();

            DataContext = new EditOrAddPerformerInEntertainmentWindowVM(entertainment);

            Logger.Info("EditOrAddPerformerInEntertainmentWindow.EditOrAddPerformerInEntertainmentWindow", "Екземпляр EditOrAddPerformerInEntertainmentWindow створений.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.okButton_Click", "Натиснута кнопка ОК.");

            ((EditOrAddPerformerInEntertainmentWindowVM)DataContext).OkButtonClick();
            this.Close();

            Logger.Info("AuthorizationWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.cancelButton_Click", "Натиснута кнопка Закрити.");

            this.Close();

            Logger.Info("AuthorizationWindow.cancelButton_Click", "Оброблений натиск кнопки Закрити.");
        }
    }
}
