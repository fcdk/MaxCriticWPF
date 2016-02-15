using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class SongUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<SongVM> _songCollection = new ObservableCollection<SongVM>();
        private SongVM _selectedSong;
        private string _partOfNameForSearch;
        private Visibility _addButtonVisibility;
        private Visibility _editButtonVisibility;
        private Visibility _deleteButtonVisibility;

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
                OnPropertyChanged("WhenSelectedButtonEnabled");
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
            get { return SelectedSong != null; }
        }

        public Visibility AddButtonVisibility
        {
            get{ return _addButtonVisibility; }
            set
            {
                _addButtonVisibility = value;
                OnPropertyChanged("AddButtonVisibility");
            }
        }

        public Visibility EditButtonVisibility
        {
            get { return _editButtonVisibility; }
            set
            {
                _editButtonVisibility = value;
                OnPropertyChanged("EditButtonVisibility");
            }
        }

        public Visibility DeleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged("DeleteButtonVisibility");
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
            EditOrAddSongWindow addOrEditSong = new EditOrAddSongWindow(this);
            addOrEditSong.ShowDialog();
        }

        internal void EditButtonClick()
        {
            EditOrAddSongWindow addOrEditSong = new EditOrAddSongWindow(this, SelectedSong);
            addOrEditSong.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedSong.SongDL.Delete();
            _songCollection.Remove(SelectedSong);
        }

        public SongUserControlVM()
        {
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Visible;
            DeleteButtonVisibility = Visibility.Visible;

            Song[] songs = Song.GetRandomFirstTen();
            if (songs != null)
                foreach (var song in songs)
                    _songCollection.Add(new SongVM(song));

            Logger.Info("SongUserControlVM.SongUserControlVM", "Екземпляр SongUserControlVM створений.");
        }

    }
}
