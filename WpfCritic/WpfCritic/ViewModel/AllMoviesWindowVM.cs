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
        private ObservableCollection<Movie> _movieMainList = new ObservableCollection<Movie>();
        private Movie _selectedMainMovie;
        private EditMovieUserControlVM _editMovieViewModel = new EditMovieUserControlVM();
        
        public EditMovieUserControlVM EditMovieViewModel
        {
            get { return _editMovieViewModel; }
        }

        public ObservableCollection<Movie> MovieMainList
        {
            get { return _movieMainList; }
        }

        public Movie SelectedMainMovie
        {
            get { return _selectedMainMovie; }
            set
            {
                _selectedMainMovie = value;
                _editMovieViewModel.SetMovie(_selectedMainMovie);

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
            get { return _selectedMainMovie == null ? string.Empty : _selectedMainMovie.Name; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public uint? Runtime
        {
            get { return _selectedMainMovie == null ? default(uint?) : _selectedMainMovie.Runtime; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Runtime = (uint)value;
                OnPropertyChanged("Runtime");
            }
        }

        public string OfficialSite
        {
            get { return _selectedMainMovie == null ? string.Empty : _selectedMainMovie.OfficialSite; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _selectedMainMovie == null ? string.Empty : _selectedMainMovie.Trailer; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Trailer = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _selectedMainMovie == null ? default(DateTime?) : _selectedMainMovie.ReleaseDate; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _selectedMainMovie == null ? string.Empty : _selectedMainMovie.Company; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Poster
        {
            get { return _selectedMainMovie == null ? string.Empty : _selectedMainMovie.Poster; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public void LoadData()
        {
            Movie m1 = new Movie("Джанго освобожденный", 150, "http://unchainedmovie.com/", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2012, 12, 12), "Weinstein Company", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.png");
            _movieMainList.Add(m1);
            Movie m2 = new Movie("Убить Билла 2", 136, "", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2004, 08, 10), "Miramax Films", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\kill_bill_2.png");
            _movieMainList.Add(m2);
        }

        internal void MoviesListBoxMouseDoubleClick()
        {
            if (_selectedMainMovie == null)
                return;
            else
            {
                MovieDetailsWindow mD = new MovieDetailsWindow();
                mD.ViewModel.SetMovie(_selectedMainMovie);
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
