using Microsoft.Win32;
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

namespace WpfCritic
{
    /// <summary>
    /// Логика взаимодействия для AddMovieUserControl.xaml
    /// </summary>
    public partial class EditMovieUserControl : UserControl
    {
        public EditMovieUserControl()
        {
            InitializeComponent();

        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditMovieUserControlVM)DataContext).PosterBrowseButtonClick();
        }

        private void trailerBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((EditMovieUserControlVM)DataContext).TrailerBrowseButtonClick();
        }

    }
        
}

