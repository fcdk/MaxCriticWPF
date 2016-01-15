using System.Collections.ObjectModel;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class SongUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<SongVM> _songCollection = new ObservableCollection<SongVM>();
        private SongVM _selectedSong;
        private string _partOfNameForSearch;
        private bool _whenSelectedButtonEnabled;

        public ObservableCollection<SongVM> SongCollection
        {
            get { return _songCollection; }
        }
        public SongVM SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                _selectedSong = value;
                OnPropertyChanged("SelectedSong");
                if (_selectedSong != null)
                    WhenSelectedButtonEnabled = true;
                else WhenSelectedButtonEnabled = false;
            }
        }

        public string PartOfNameForSearch
        {
            get { return _partOfNameForSearch == null ? string.Empty : _partOfNameForSearch; }
            set
            {
                _partOfNameForSearch = value;
                OnPropertyChanged("PartOfNameForSearch");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return _whenSelectedButtonEnabled; }
            set
            {
                _whenSelectedButtonEnabled = value;
                OnPropertyChanged("WhenSelectedButtonEnabled");
            }
        }

        public void Add(object item)
        {
            SongVM newItem = item as SongVM;
            if (newItem != null)
                _songCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _songCollection.Clear();

            Song[] songs = Song.GetByName(PartOfNameForSearch);
            if (songs != null)
                foreach (var song in songs)
                {
                    _songCollection.Add(new SongVM(song));
                }
        }

        internal void AddButtonClick()
        {
            //добавление новой песни
            //EditOrAddEntertainmentWindow addOrEditEntertainment = new EditOrAddEntertainmentWindow(new EditOrAddEntertainmentWindowVM(this));
            //addOrEditEntertainment.ShowDialog();
        }

        internal void EditButtonClick()
        {
            //редактирование песни
            //EditOrAddEntertainmentWindow addOrEditEntertainment = new EditOrAddEntertainmentWindow(new EditOrAddEntertainmentWindowVM(this, SelectedEntertainment));
            //addOrEditEntertainment.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedSong.SongDL.Delete();
            _songCollection.Remove(SelectedSong);
        }

        public SongUserControlVM()
        {
            Song[] songs = Song.GetRandomFirstTen();
            if (songs != null)
                foreach (var song in songs)
                {
                    _songCollection.Add(new SongVM(song));
                }
        }

    }
}
