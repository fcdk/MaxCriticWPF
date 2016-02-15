using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class MainMenuWindow : Window
    {
        private MainMenuWindowVM _viewModel = new MainMenuWindowVM();
        
        public MainMenuWindow()
        {
            InitializeComponent();

            DataContext = _viewModel;

            Logger.Info("MainMenuWindow.MainMenuWindow", "Екземпляр MainMenuWindow створений.");
        }

    }
}
