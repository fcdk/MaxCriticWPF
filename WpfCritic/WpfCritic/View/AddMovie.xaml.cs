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
using System.Windows.Shapes;
using Critic.Data;
using WpfCritic.ViewModel;

namespace WpfCritic
{
    /// <summary>
    /// Логика взаимодействия для AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Window
    {
        private AddMovieWindowVM _viewModel = new AddMovieWindowVM();
        public AddMovieWindowVM ViewModel
        { get { return _viewModel; } }
        public AddMovie()
        {
            this.InitializeComponent();

            DataContext = _viewModel;
        }

        /*private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string error = "Ошибка(и):\n";
            bool isError = false;
            nameLabel.Foreground = new SolidColorBrush(Colors.Black);
            posterLabel.Foreground = new SolidColorBrush(Colors.Black);
            releaseDateLabel.Foreground = new SolidColorBrush(Colors.Black);
            companyLabel.Foreground = new SolidColorBrush(Colors.Black);
            runtimeLabel.Foreground = new SolidColorBrush(Colors.Black);
            if (nameTextBox.Text == String.Empty)
            {
                isError = true;
                error += "Поле с названием не должно быть пустым!\n";
                nameLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (posterTextBox.Text == String.Empty)
            {
                isError = true;
                error += "Поле с путем к постеру не должно быть пустым!\n";
                posterLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (releaseDateDatePicker.Text == String.Empty)
            {
                isError = true;
                error += "Поле с датой релиза не должно быть пустым!\n";
                releaseDateLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (companyTextBox.Text == String.Empty)
            {
                isError = true;
                error += "Поле с названием компании не должно быть пустым!\n";
                companyLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (runtimeTextBox.Text == String.Empty)
            {
                isError = true;
                error += "Поле с продолжительностью фильма не должно быть пустым!\n";
                runtimeLabel.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (isError)
                MessageBox.Show(error);
            else
            {
                new Movie(nameTextBox.Text, uint.Parse(runtimeTextBox.Text), officialSiteTextBox.Text, trailerTextBox.Text, releaseDateDatePicker.SelectedDate.Value, companyTextBox.Text, posterTextBox.Text);
                this.Close();
                ((MainWindow)App.Current.MainWindow).UpdateMoviesListBox();
            }    
        }*/
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // тут надо как-то обновить ListBox в MainWindow!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ((MainWindow)App.Current.MainWindow).ViewModel.MovieMainList.Add(_viewModel.NewMovie);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Movie.Items.Remove(_viewModel.NewMovie.Id);
        }
    }
}
