using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.Model;
using System.Collections.ObjectModel;
using WpfCritic.View;

namespace WpfCritic.ViewModel
{
    public class AllMoviesWindowVM : ViewModelBase
    {
        private ObservableCollection<Movie> _movieCollection = new ObservableCollection<Movie>();
        private Movie _selectedMovie;
        private EditMovieUserControlVM _editMovieViewModel = new EditMovieUserControlVM();
        
        public EditMovieUserControlVM EditMovieViewModel
        {
            get { return _editMovieViewModel; }
        }

        public ObservableCollection<Movie> MovieCollection
        {
            get { return _movieCollection; }
        }

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                _editMovieViewModel.SetMovie(_selectedMovie);

                OnPropertyChanged("SelectedMainMovie");
                OnPropertyChanged("Name");
                OnPropertyChanged("Runtime");
                OnPropertyChanged("OfficialSite");
                OnPropertyChanged("Trailer");
                OnPropertyChanged("ReleaseDate");
                OnPropertyChanged("Company");
                OnPropertyChanged("Poster");
            }
        }

        public string Name
        {
            get { return _selectedMovie == null ? string.Empty : _selectedMovie.Name; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public uint? Runtime
        {
            get { return _selectedMovie == null ? default(uint?) : _selectedMovie.Runtime; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.Runtime = (uint)value;
                OnPropertyChanged("Runtime");
            }
        }

        public string OfficialSite
        {
            get { return _selectedMovie == null ? string.Empty : _selectedMovie.OfficialSite; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _selectedMovie == null ? string.Empty : _selectedMovie.Trailer; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.Trailer = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _selectedMovie == null ? default(DateTime?) : _selectedMovie.ReleaseDate; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _selectedMovie == null ? string.Empty : _selectedMovie.Company; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Poster
        {
            get { return _selectedMovie == null ? string.Empty : _selectedMovie.Poster; }
            set
            {
                if (_selectedMovie == null)
                    return;
                _selectedMovie.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public void LoadData()
        {
            Movie m1 = new Movie("Джанго освобожденный", 150, "http://unchainedmovie.com/", @"C:\Users\max\Documents\Visual Studio 2015\Projects\Critic\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2012, 12, 12), "Weinstein Company", @"\Assets\django.png");
            _movieCollection.Add(m1);
            Movie m2 = new Movie("Убить Билла 2", 136, "", @"C:\Users\max\Documents\Visual Studio 2015\Projects\Critic\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2004, 08, 10), "Miramax Films", @"\Assets\kill_bill_2.png");
            _movieCollection.Add(m2);
        }

        internal void MoviesListBoxMouseDoubleClick()
        {
            if (_selectedMovie == null)
                return;
            else
            {
                MovieDetailsWindow mD = new MovieDetailsWindow();
                mD.ViewModel.SetMovie(_selectedMovie);
                mD.ShowDialog();
            }
        }

        internal void AddButtonClick()
        {
            AddMovieWindow aM = new AddMovieWindow();
            aM.ShowDialog();
        }

        internal void MenuButtonClick()
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
        }

    }
}
