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
    public partial class AddMovieUserControl : UserControl
    {
        public AddMovieUserControl()
        {
            InitializeComponent();

        }

        private void posterBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            ((AddMovieUserControlVM)DataContext).BrowserButtonClick();
        }

        private void trailerBrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog trailerBrowse = new OpenFileDialog();
            trailerBrowse.Filter = "Файлы видео|*.mp4;*.avi;*.mkv;*.wmv";
            //if (trailerBrowse.ShowDialog() == true)
                //trailerTextBox.Text = trailerBrowse.FileName;
        }

    }
        
}

