using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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
            throw new NotImplementedException();
        }

        internal void DeleteButtonClick()
        {
            throw new NotImplementedException();
        }

        internal void OkButtonClick()
        {
            throw new NotImplementedException();
        }

        public EditOrAddSongInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _album = entertainment;

            _songViewModel.AddButtonVisibility = Visibility.Collapsed;
            _songViewModel.EditButtonVisibility = Visibility.Collapsed;
            _songViewModel.DeleteButtonVisibility = Visibility.Collapsed;

            SongInEntertainment[] songInEntertainments = SongInEntertainment.GetSongInEntertainmentByEntertainment(_album.EntertainmentDL);
            foreach (var songInEntertainment in songInEntertainments)
                _songInEntertainmentCollection.Add();

            Song[] songs = Song.GetSongsByAlbum(_album.EntertainmentDL);
            if (songs != null)
                foreach (var song in songs)
                    _addedSongCollection.Add(new SongVM(song));
        }

    }
}
