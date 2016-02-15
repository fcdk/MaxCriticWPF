using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class PerformerDetailsWindow : Window
    {
        public PerformerDetailsWindow(PerformerVM _performer)
        {
            InitializeComponent();

            DataContext = new PerformerDetailsWindowVM(_performer);

            Logger.Info("PerformerDetailsWindow.PerformerDetailsWindow", "Екземпляр PerformerDetailsWindow створений.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("PerformerDetailsWindow.cancelButton_Click", "Натиснута кнопка Закрити.");

            this.Close();

            Logger.Info("PerformerDetailsWindow.SearchButton_Click", "Оброблений натиск кнопки Закрити.");
        }
    }
}
