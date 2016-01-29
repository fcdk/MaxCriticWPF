using System.Windows;
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
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
