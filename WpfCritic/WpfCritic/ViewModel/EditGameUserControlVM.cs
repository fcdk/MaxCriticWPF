using Microsoft.Win32;
using System;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditGameUserControlVM : ViewModelBase
    {
        private EntertainmentVM _game;

        //сделать тут кеширование данных!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /*private string _name;
        private string _developer;
        private string _officialSite;
        private string _trailer;
        private DateTime _releaseDate;
        private string _company;
        private string _poster;*/

        public void SetGame(EntertainmentVM game)
        {
            _game = game;
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("OfficialSite");
            OnPropertyChanged("Trailer");
            OnPropertyChanged("ReleaseDate");
            OnPropertyChanged("Company");
            OnPropertyChanged("Poster");
        }

        public string Name
        {
            get { return _game == null ? string.Empty : _game.Name; }
            set
            {
                if (_game == null)
                    return;
                _game.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string OfficialSite
        {
            get { return _game == null ? string.Empty : _game.OfficialSite; }
            set
            {
                if (_game == null)
                    return;
                _game.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _game == null ? string.Empty : _game.TrailerLink; }
            set
            {
                if (_game == null)
                    return;
                _game.TrailerLink = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _game == null ? default(DateTime?) : _game.ReleaseDate; }
            set
            {
                if (_game == null)
                    return;
                _game.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _game == null ? string.Empty : _game.Company; }
            set
            {
                if (_game == null)
                    return;
                _game.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public byte[] Poster
        {
            get { return _game == null ? null : _game.Poster; }
            set
            {
                if (_game == null)
                    return;
                _game.Poster = value;
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
            //if (posterBrowse.ShowDialog() == true)
                //Poster = posterBrowse.FileName;
        }
    }
}
