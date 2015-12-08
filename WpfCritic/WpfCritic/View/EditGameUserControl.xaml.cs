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
using WpfCritic.ViewModel;

namespace WpfCritic.View
{
    /// <summary>
    /// Логика взаимодействия для EditGameUserControl.xaml
    /// </summary>
    public partial class EditGameUserControl : UserControl
    {
        public EditGameUserControl()
        {
            InitializeComponent();
        }

        private void trailerBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditGameUserControlVM)DataContext).TrailerBrowseButtonClick();
        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditGameUserControlVM)DataContext).PosterBrowseButtonClick();
        }
    }
}
