using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WpfCritic.ViewModel
{
    public class MovieDetailsWindowVM : ViewModelBase
    {
        private Movie _movie;

        public void SetMovie(Movie movie)
        {
            _movie = movie;
            RefreshProperties();
        }
        
        private void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Runtime");
            OnPropertyChanged("OfficialSite");
            OnPropertyChanged("Trailer");
            OnPropertyChanged("ReleaseDate");
            OnPropertyChanged("Company");
            OnPropertyChanged("Poster");
        }

        public string Name
        {
            get { return _movie == null ? string.Empty : _movie.Name; }
            set
            {
                if (_movie == null)
                    return;
                _movie.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public uint Runtime
        {
            get { return _movie == null ? 0 : _movie.Runtime; }
            set
            {
                if (_movie == null)
                    return;
                _movie.Runtime = value;
                OnPropertyChanged("Runtime");
            }
        }

        public string OfficialSite
        {
            get { return _movie == null ? string.Empty : _movie.OfficialSite; }
            set
            {
                if (_movie == null)
                    return;
                _movie.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _movie == null ? string.Empty : _movie.Trailer; }
            set
            {
                if (_movie == null)
                    return;
                _movie.Trailer = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime ReleaseDate
        {
            get { return _movie == null ? DateTime.Today : _movie.ReleaseDate; }
            set
            {
                if (_movie == null)
                    return;
                _movie.ReleaseDate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _movie == null ? string.Empty : _movie.Company; }
            set
            {
                if (_movie == null)
                    return;
                _movie.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Poster
        {
            get { return _movie == null ? string.Empty : _movie.Poster; }
            set
            {
                if (_movie == null)
                    return;
                _movie.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        internal void EllipseMouseLeave(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00167C"));
        }

        internal void AddReviewClick()
        {
            NewReviewWindow nR = new NewReviewWindow(_movie);
            nR.ShowDialog();
        }

        internal void EllipseMouseEnter(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0074FF"));
        }

    }
}
