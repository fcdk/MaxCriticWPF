using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddSongInEntertainmentWindowVM : ViewModelBase
    {
        private SongUserControlVM _songViewModel = new SongUserControlVM();
        private EntertainmentVM _album;
        private ObservableCollection<SongVM> _addedSongCollection = new ObservableCollection<SongVM>();
        private SongVM _addedSelectedSong;
        List<SongInEntertainmentVM> _songInEntertainmentCollection = new List<SongInEntertainmentVM>();
        List<SongVM> _deletedSongCollection = new List<SongVM>();

        public SongUserControlVM SongViewModel
        {
            get { return _songViewModel; }
        }

        public EntertainmentVM Album
        {
            get { return _album; }
        }

        public ObservableCollection<SongVM> AddedSongCollection
        {
            get { return _addedSongCollection; }
        }

        public SongVM AddedSelectedSong
        {
            get { return _addedSelectedSong; }
            set
            {
                _addedSelectedSong = value;
                OnPropertyChanged("AddedSelectedSong");
                OnPropertyChanged("WhenSelectedButtonEnabled");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return AddedSelectedSong != null; }
        }

        internal void AddButtonClick()
        {
            foreach (SongVM song in _addedSongCollection)
                if (SongVM.Comparison(song,SongViewModel.SelectedSong))
                    return;
            for (int i = 0; i < _deletedSongCollection.Count; i++)
                if (SongVM.Comparison(_deletedSongCollection[i], SongViewModel.SelectedSong))
                {
                    _deletedSongCollection.Remove(_deletedSongCollection[i]);
                    break;
                }
            _addedSongCollection.Add(SongViewModel.SelectedSong);
        }

        internal void DeleteButtonClick()
        {
            foreach (SongInEntertainmentVM songInEntertainment in _songInEntertainmentCollection)
                if (songInEntertainment.SongComparison(AddedSelectedSong))
                {
                    _deletedSongCollection.Add(AddedSelectedSong);
                    break;
                }
            for (int i = 0; i < _addedSongCollection.Count; i++)
                if (SongVM.Comparison(_addedSongCollection[i], AddedSelectedSong))
                {
                    _addedSongCollection.Remove(_addedSongCollection[i]);
                    break;
                }
        }

        internal void OkButtonClick()
        {
            bool IsNew;

            foreach (SongVM song in _addedSongCollection)
            {
                IsNew = true;
                foreach (SongInEntertainmentVM songInEntertainment in _songInEntertainmentCollection)
                    if (songInEntertainment.SongComparison(song))
                    {
                        IsNew = false;
                        break;
                    }
                if (IsNew)
                    (new SongInEntertainmentVM(song, Album)).SongInEntertainmentDL.Save();
            }
            foreach (SongVM song in _deletedSongCollection)
                for (int i = 0; i < _songInEntertainmentCollection.Count; i++)
                    if (_songInEntertainmentCollection[i].SongComparison(song))
                    {
                        _songInEntertainmentCollection[i].SongInEntertainmentDL.Delete();
                        _songInEntertainmentCollection.Remove(_songInEntertainmentCollection[i]);
                        break;
                    }
        }

        public EditOrAddSongInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _album = entertainment;

            _songViewModel.AddButtonVisibility = Visibility.Collapsed;
            _songViewModel.EditButtonVisibility = Visibility.Collapsed;
            _songViewModel.DeleteButtonVisibility = Visibility.Collapsed;

            SongInEntertainment[] songInEntertainments = SongInEntertainment.GetSongInEntertainmentByEntertainment(_album.EntertainmentDL);

            if (songInEntertainments != null)
            {
                List<Guid> songIds = new List<Guid>();

                foreach (var songInEntertainment in songInEntertainments)
                {
                    _songInEntertainmentCollection.Add(new SongInEntertainmentVM(songInEntertainment));
                    songIds.Add(songInEntertainment.SongId);
                }

                Song[] songs = Song.GetByIds(songIds.ToArray());
                foreach (var song in songs)
                    _addedSongCollection.Add(new SongVM(song));

                Logger.Info("EditOrAddSongInEntertainmentWindowVM.EditOrAddSongInEntertainmentWindowVM", "Екземпляр EditOrAddSongInEntertainmentWindowVM створений.");
            }
        }

    }
}
