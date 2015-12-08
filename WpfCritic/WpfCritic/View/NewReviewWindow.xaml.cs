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
using System.Windows.Shapes;
using WpfCritic.Model;

namespace WpfCritic
{
    /// <summary>
    /// Логика взаимодействия для NewReview.xaml
    /// </summary>
    public partial class NewReviewWindow : Window
    {
        public NewReviewWindow(Movie movie)
        {
            InitializeComponent();

            nameTextBlock.Text += movie.ToString();
            pointTextBlock.Text = "0";
        }

        private void pointSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pointTextBlock.Text = pointSlider.Value.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
