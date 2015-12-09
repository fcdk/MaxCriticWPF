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
using WpfCritic.ViewModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic
{
    /// <summary>
    /// Логика взаимодействия для NewReview.xaml
    /// </summary>
    public partial class NewReviewWindow : Window
    {

        private ReviewMovieWindowVM _viewModel = new ReviewMovieWindowVM();
        public ReviewMovieWindowVM ViewModel
        {
            get { return _viewModel; }
        }

        public NewReviewWindow(Movie movie)
        {
            InitializeComponent();

            DataContext = _viewModel;
            _viewModel.SetReviewMovie(new ReviewMovieVM(new Review<Movie>(new User("lol"), movie, 11, DateTime.Today, string.Empty)));
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
