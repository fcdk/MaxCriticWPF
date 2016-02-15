using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddGenreInEntertainmentWindowVM : ViewModelBase
    {
        private GenreUserControlVM _genreViewModel;
        private EntertainmentVM _entertainment;
        private ObservableCollection<GenreVM> _addedGenreCollection = new ObservableCollection<GenreVM>();
        private GenreVM _addedSelectedGenre;
        List<GenreInEntertainmentVM> _genreInEntertainmentCollection = new List<GenreInEntertainmentVM>();
        List<GenreVM> _deletedGenreCollection = new List<GenreVM>();

        public GenreUserControlVM GenreViewModel
        {
            get { return _genreViewModel; }
        }

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
        }

        public ObservableCollection<GenreVM> AddedGenreCollection
        {
            get { return _addedGenreCollection; }
        }

        public GenreVM AddedSelectedGenre
        {
            get { return _addedSelectedGenre; }
            set
            {
                _addedSelectedGenre = value;
                OnPropertyChanged("AddedSelectedGenre");
                OnPropertyChanged("WhenSelectedButtonEnabled");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return AddedSelectedGenre != null; }
        }

        internal void AddButtonClick()
        {
            foreach (GenreVM genre in _addedGenreCollection)
                if (GenreVM.Comparison(genre, GenreViewModel.SelectedGenre))
                    return;
            for (int i = 0; i < _deletedGenreCollection.Count; i++)
                if (GenreVM.Comparison(_deletedGenreCollection[i], GenreViewModel.SelectedGenre))
                {
                    _deletedGenreCollection.Remove(_deletedGenreCollection[i]);
                    break;
                }
            _addedGenreCollection.Add(GenreViewModel.SelectedGenre);
        }

        internal void DeleteButtonClick()
        {
            foreach (GenreInEntertainmentVM genreInEntertainment in _genreInEntertainmentCollection)
                if (genreInEntertainment.GenreComparison(AddedSelectedGenre))
                {
                    _deletedGenreCollection.Add(AddedSelectedGenre);
                    break;
                }
            for (int i = 0; i < _addedGenreCollection.Count; i++)
                if (GenreVM.Comparison(_addedGenreCollection[i], AddedSelectedGenre))
                {
                    _addedGenreCollection.Remove(_addedGenreCollection[i]);
                    break;
                }
        }

        internal void OkButtonClick()
        {
            bool IsNew;

            foreach (GenreVM genre in _addedGenreCollection)
            {
                IsNew = true;
                foreach (GenreInEntertainmentVM genreInEntertainment in _genreInEntertainmentCollection)
                    if (genreInEntertainment.GenreComparison(genre))
                    {
                        IsNew = false;
                        break;
                    }
                if (IsNew)
                    (new GenreInEntertainmentVM(genre, Entertainment)).GenreInEntertainmentDL.Save();
            }
            foreach (GenreVM genre in _deletedGenreCollection)
                for (int i = 0; i < _genreInEntertainmentCollection.Count; i++)
                    if (_genreInEntertainmentCollection[i].GenreComparison(genre))
                    {
                        _genreInEntertainmentCollection[i].GenreInEntertainmentDL.Delete();
                        _genreInEntertainmentCollection.Remove(_genreInEntertainmentCollection[i]);
                        break;
                    }
        }

        public EditOrAddGenreInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;
            _genreViewModel = new GenreUserControlVM(_entertainment.EntertainmentType);

            _genreViewModel.GenreTypesComboBoxVisibility = Visibility.Collapsed;
            _genreViewModel.AddButtonVisibility = Visibility.Collapsed;
            _genreViewModel.EditButtonVisibility = Visibility.Collapsed;
            _genreViewModel.DeleteButtonVisibility = Visibility.Collapsed;

            GenreInEntertainment[] genreInEntertainments = GenreInEntertainment.GetGenreInEntertainmentByEntertainment(_entertainment.EntertainmentDL);

            if (genreInEntertainments != null)
            {
                List<Guid> genreIds = new List<Guid>();

                foreach (var genreInEntertainment in genreInEntertainments)
                {
                    _genreInEntertainmentCollection.Add(new GenreInEntertainmentVM(genreInEntertainment));
                    genreIds.Add(genreInEntertainment.GenreId);
                }

                Genre[] genres = Genre.GetByIds(genreIds.ToArray());
                foreach (var genre in genres)
                    _addedGenreCollection.Add(new GenreVM(genre));
            }

            Logger.Info("EditOrAddGenreInEntertainmentWindowVM.EditOrAddGenreInEntertainmentWindowVM", "Екземпляр EditOrAddGenreInEntertainmentWindowVM створений.");
        }

    }
}
