using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.View
{
    public partial class EditOrAddAwardWindow : Window
    {
        public EditOrAddAwardWindow(ICollectionsEntity entity, AwardVM award = null)
        {
            InitializeComponent();

            DataContext = new EditOrAddAwardWindowVM(entity, award);

            Logger.Info("EditOrAddAwardWindow.EditOrAddAwardWindow", "Екземпляр EditOrAddAwardWindow створений.");
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.ImageButton_Click", "Натиснута кнопка Додавання зображення.");

            ((EditOrAddAwardWindowVM)DataContext).ImageButtonClick();

            Logger.Info("AuthorizationWindow.ImageButton_Click", "Оброблений натиск кнопки Додавання зображення.");
        }

        private void ImageClearButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.ImageClearButton_Click", "Натиснута кнопка Очищення зображення.");

            ((EditOrAddAwardWindowVM)DataContext).ImageClearButtonClick();

            Logger.Info("AuthorizationWindow.ImageClearButton_Click", "Оброблений натиск кнопки Очищення зображення.");
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.okButton_Click", "Натиснута кнопка ОК.");

            if (((EditOrAddAwardWindowVM)DataContext).OkButtonClick())
                this.Close();

            Logger.Info("AuthorizationWindow.okButton_Click", "Оброблений натиск кнопки ОК.");
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Logger.Info("AuthorizationWindow.cancelButton_Click", "Натиснута кнопка Відмінити.");

            this.Close();

            Logger.Info("AuthorizationWindow.cancelButton_Click", "Оброблений натиск кнопки Відмінити.");
        }

    }
}
