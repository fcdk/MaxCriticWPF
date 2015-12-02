using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Critic.Data;
using System.Collections.ObjectModel;

namespace WpfCritic.ViewModel
{
    public class MainWindowCriticVM : ViewModelBase
    {
        private ObservableCollection<Movie> _movieMainList = new ObservableCollection<Movie>();
        private Movie _selectedMainMovie;
        private AddMovieUserControlVM _addMovieViewModel = new AddMovieUserControlVM();
        
        public AddMovieUserControlVM AddMovieViewModel
        {
            get { return _addMovieViewModel; }
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
                _addMovieViewModel.SetMovie(_selectedMainMovie);

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
            }
        }

        public uint Runtime
        {
            get { return _selectedMainMovie == null ? 0 : _selectedMainMovie.Runtime; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.Runtime = value;
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
            }
        }

        public DateTime ReleaseDate
        {
            get { return _selectedMainMovie == null ? new DateTime(0, 0, 0) : _selectedMainMovie.ReleaseDate; }
            set
            {
                if (_selectedMainMovie == null)
                    return;
                _selectedMainMovie.ReleaseDate = value;
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
            }
        }

        public void LoadData()
        {
            Movie m1 = new Movie("Джанго освобожденный", 150, "http://unchainedmovie.com/", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2012, 12, 12), "Weinstein Company", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.png");
            Movie m2 = new Movie("Убить Билла 2", 136, "", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2004, 08, 10), "Miramax Films", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\kill_bill_2.png");
            foreach (var movie in Movie.Items.Values)
                _movieMainList.Add(movie);
        }

    }
}
