using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class GenreUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<GenreVM> _genreCollection = new ObservableCollection<GenreVM>();
        private GenreVM _selectedGenre;
        private string _partOfNameForSearch;
        private string[] _genreTypes = new string[] { "Усі", "Фільм", "Гра", "Серіал", "Музика" };
        private string _selectedType = "Усі";
        private Visibility _addButtonVisibility;
        private Visibility _editButtonVisibility;
        private Visibility _deleteButtonVisibility;
      
        public ObservableCollection<GenreVM> GenreCollection
        {
            get { return _genreCollection; }
        }
        public GenreVM SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
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

        public string[] GenreTypes
        {
            get { return _genreTypes; }
        }

        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return SelectedGenre != null; }
        }

        public Visibility AddButtonVisibility
        {
            get { return _addButtonVisibility; }
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
            GenreVM newItem = item as GenreVM;
            if (newItem != null)
                _genreCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _genreCollection.Clear();

            Genre[] genres = Genre.GetByName(PartOfNameForSearch, EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(SelectedType));
            if (genres != null)
                foreach (var genre in genres)
                {
                    _genreCollection.Add(new GenreVM(genre));
                }
        }

        internal void AddButtonClick()
        {
            ////EditOrAddSongWindow addOrEditSong = new EditOrAddSongWindow(this);
            ////addOrEditSong.ShowDialog();
        }

        internal void EditButtonClick()
        {
            ////EditOrAddSongWindow addOrEditSong = new EditOrAddSongWindow(this, SelectedSong);
            ////addOrEditSong.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedGenre.GenreDL.Delete();
            _genreCollection.Remove(SelectedGenre);
        }

        public GenreUserControlVM()
        {
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Visible;
            DeleteButtonVisibility = Visibility.Visible;

            Genre[] genres = Genre.GetRandomFirstTen();
            if (genres != null)
                foreach (var genre in genres)
                    _genreCollection.Add(new GenreVM(genre));
        }

    }
}
