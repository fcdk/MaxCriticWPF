using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    public partial class AddGameWindow : Window
    {
        private AddGameWindowVM _viewModel;
        public AddGameWindowVM ViewModel
        { get { return _viewModel; } }

        public AddGameWindow(AddGameWindowVM viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Logger.Info("AddGameWindow", "Форма добавления игры создана");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ((AddGameWindowVM)DataContext).OkButtonClick();
            this.Close();

            Logger.Info("AddGameWindow.okButton_Click", "Фильм добавлен");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
