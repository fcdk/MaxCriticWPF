using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddGenreWindow : Window
    {
        public EditOrAddGenreWindow(ICollectionsEntity entity, GenreVM genre = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddGenreWindowVM(entity, genre);

            Logger.Info("EditOrAddGenreWindow.EditOrAddGenreWindow", "Екземпляр EditOrAddGenreWindow створений.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreWindow.okButton_Click", "Натиснута кнопка ОК.");

            if (((EditOrAddGenreWindowVM)DataContext).OkButtonClick())
                this.Close();

            Logger.Info("EditOrAddGenreWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddGenreWindow.okButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddGenreWindow.okButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
