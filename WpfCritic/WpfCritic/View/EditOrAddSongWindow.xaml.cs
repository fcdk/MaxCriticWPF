using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddSongWindow : Window
    {
        public EditOrAddSongWindow(ICollectionsEntity entity, SongVM song = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddSongWindowVM(entity, song);

            Logger.Info("EditOrAddSongWindow.EditOrAddSongWindow", "Екземпляр EditOrAddSongWindow створений.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongWindow.okButton_Click", "Натиснута кнопка ОК.");

            if (((EditOrAddSongWindowVM)DataContext).OkButtonClick())
                this.Close();

            Logger.Info("EditOrAddSongWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("EditOrAddSongWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("EditOrAddSongWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
