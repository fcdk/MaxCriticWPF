using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.Model;
using Microsoft.Win32;
using System.Windows;

namespace WpfCritic.ViewModel
{
    public class EditMovieUserControlVM : ViewModelBase
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

        public uint? Runtime
        {
            get { return _movie == null ? default(uint?) : _movie.Runtime; }
                set
            {
                if (_movie == null)
                    return;
                _movie.Runtime = (uint)value;
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

        public DateTime? ReleaseDate
        {
            get { return _movie == null ? default(DateTime?) : _movie.ReleaseDate; }
            set
            {
                if (_movie == null)
                    return;
                _movie.ReleaseDate = (DateTime)value;
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
        
        internal void TrailerBrowseButtonClick()
        {
            OpenFileDialog trailerBrowse = new OpenFileDialog();
            trailerBrowse.Filter = "Файлы видео|*.mp4;*.avi;*.mkv;*.wmv";
            if (trailerBrowse.ShowDialog() == true)
                Trailer = trailerBrowse.FileName;
        }

        internal void PosterBrowseButtonClick()
        {
            OpenFileDialog posterBrowse = new OpenFileDialog();
            posterBrowse.Filter = "Файлы рисунков|*.png;*.jpg;*.bmp;*.tif;*.gif";
            if (posterBrowse.ShowDialog() == true)
                Poster = posterBrowse.FileName;
        }

    }
}
