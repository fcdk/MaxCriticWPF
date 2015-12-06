using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Critic.Data;

namespace WpfCritic.ViewModel
{
    public class AddMovieWindowVM : ViewModelBase
    {
        private Movie _newMovie = new Movie(string.Empty, 0, string.Empty, string.Empty, DateTime.Today, string.Empty, string.Empty);

        private AddMovieUserControlVM _addMovieViewModel = new AddMovieUserControlVM();
        public AddMovieUserControlVM AddMovieViewModel
        {
            get { return _addMovieViewModel; }
        }

        public AddMovieWindowVM()
        {
            _addMovieViewModel.SetMovie(_newMovie);
        }

        internal void OkButtonClick()
        {
            // тут надо как-то обновить ListBox в MainWindow!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ((MainWindow)App.Current.MainWindow).ViewModel.MovieMainList.Add(_newMovie);
        }

        internal void CancelButtonClick()
        {
            Movie.Items.Remove(_newMovie.Id);
        }
    }
}
