using System;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddSongWindowVM : ViewModelBase
    {
        private ICollectionsEntity _collectionEntity;
        private SongVM _song;

        private bool _isError;
        private Visibility _nameErrorVisibility;
        private Visibility _durationErrorVisibility;

        //кеширование свойств Song
        private string _name;
        private TimeSpan? _duration;
        private string _lyrics;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public TimeSpan? Duration
        {
            get { return _duration; }
            set { _duration = value; OnPropertyChanged("Duration"); }
        }

        public string Lyrics
        {
            get { return _lyrics; }
            set { _lyrics = value; OnPropertyChanged("Lyrics"); }
        }

        public string HeaderText
        {
            get
            {
                if (_song == null)
                    return "Додавання нової пісні";
                return "Редагування пісні";
            }
        }

        public Visibility NameErrorVisibility
        {
            get { return _nameErrorVisibility; }
            set
            {
                _nameErrorVisibility = value;
                OnPropertyChanged("NameErrorVisibility");
            }
        }

        public Visibility DurationErrorVisibility
        {
            get { return _durationErrorVisibility; }
            set
            {
                _durationErrorVisibility = value;
                OnPropertyChanged("DurationErrorVisibility");
            }
        }

        public EditOrAddSongWindowVM(ICollectionsEntity collectionEntity, SongVM song = null)
        {
            _collectionEntity = collectionEntity;
            _song = song;

            if (_song != null)
            {
                Name = _song.Name;
                Duration = _song.Duration;
                Lyrics = _song.Lyrics;
            }

            NameErrorVisibility = Visibility.Hidden;
            DurationErrorVisibility = Visibility.Hidden;

            Logger.Info("EditOrAddSongWindow.EditOrAddSongWindow", "Екземпляр EditOrAddSongWindow створений.");
        }

        internal bool OkButtonClick()
        {
            _isError = false;

            if (Name == null || Name == String.Empty)
            {
                NameErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else NameErrorVisibility = Visibility.Hidden;

            if (Duration == null)
            {
                DurationErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else DurationErrorVisibility = Visibility.Hidden;

            if (_isError)
                return false;

            if (_song == null)
            {
                SongVM song = new SongVM(Name, (TimeSpan)Duration, Lyrics);
                song.SongDL.Save();
                _collectionEntity.Add(song);
            }
            else
            {
                _song.Name = Name;
                _song.Duration = (TimeSpan)Duration;
                _song.Lyrics = Lyrics;

                _song.SongDL.Save();
            }
            return true;
        }

    }
}
