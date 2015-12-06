using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Critic.Data;
using System.Drawing;
using WpfCritic.ViewModel;

namespace WpfCritic
{
    ////<summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowCriticVM _viewModel = new MainWindowCriticVM();
        public MainWindowCriticVM ViewModel
        {
            get { return _viewModel; }
        }

        public MainWindow()
        {
            this.InitializeComponent();

            DataContext = _viewModel;
                        
            _viewModel.LoadData();
        }

        private void MoviesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainWindowCriticVM)DataContext).MoviesListBoxMouseDoubleClick();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowCriticVM)DataContext).AddButtonClick();
        }
    }
}
