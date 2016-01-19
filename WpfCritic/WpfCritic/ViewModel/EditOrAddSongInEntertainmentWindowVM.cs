using System;
using System.Collections.ObjectModel;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddSongInEntertainmentWindowVM : ViewModelBase
    {
        private SongUserControlVM _songViewModel = new SongUserControlVM();
        private EntertainmentVM _album;
        private ObservableCollection<SongVM> _addedSongCollection = new ObservableCollection<SongVM>();
        private SongVM _addedSelectedSong;      

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
            get { return SelectedSong != null; }
        }

        internal void AddButtonClick()
        {
            throw new NotImplementedException();
        }

        internal void OkButtonClick()
        {
            throw new NotImplementedException();
        }

        internal void CancelButtonClick()
        {
            throw new NotImplementedException();
        }

        internal void DeleteButtonClick()
        {
            throw new NotImplementedException();
        }

        public EditOrAddSongInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _album = entertainment;
        }

    }
}
