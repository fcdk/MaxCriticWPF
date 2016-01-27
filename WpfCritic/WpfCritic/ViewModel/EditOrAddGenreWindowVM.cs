using System;
using System.Collections.Generic;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddGenreWindowVM : ViewModelBase
    {
        private ICollectionsEntity _collectionEntity;
        private GenreVM _genre;

        private string[] _genreTypes = new string[] { "Фільм", "Гра", "Серіал", "Музика" };

        private string _partOfName;

        private bool _isError;
        private Visibility _nameErrorVisibility;
        private Visibility _parentGenreErrorVisibility;

        //кеширование свойств Genre
        private GenreVM _parentGenre;
        private string _name;
        private string _genreTypeUkr = "Фільм";
        private string _summary;

        public string[] GenreTypes
        {
            get { return _genreTypes; }
        }

        public GenreVM[] ParentGenresPick
        {
            get
            {
                if (PartOfName == null)
                    return null;
                if (PartOfName.Length < 3)
                    return null;

                Genre[] genres;

                if (_genre == null)
                    genres = Genre.GetByName(PartOfName, (Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(GenreTypeUkr));
                else genres = Genre.GetByNameExceptId(PartOfName, (Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(GenreTypeUkr),
                _genre.GenreDL.Id);

                if (genres == null)
                    return null;

                List<GenreVM> result = new List<GenreVM>();
                foreach (Genre genre in genres)
                    result.Add(new GenreVM(genre));
                return result.ToArray();
            }
        }

        public string PartOfName
        {
            get { return _partOfName; }
            set
            {
                _partOfName = value;
                OnPropertyChanged("PartOfName");
                OnPropertyChanged("ParentGenresPick");
            }
        }

        public GenreVM ParentGenre
        {
            get { return _parentGenre; }
            set { _parentGenre = value; OnPropertyChanged("ParentGenre"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string GenreTypeUkr
        {
            get { return _genreTypeUkr; }
            set { _genreTypeUkr = value; OnPropertyChanged("GenreTypeUkr"); }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("Summary"); }
        }

        public string HeaderText
        {
            get
            {
                if (_genre == null)
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

        public Visibility ParentGenreErrorVisibility
        {
            get { return _parentGenreErrorVisibility; }
            set
            {
                _parentGenreErrorVisibility = value;
                OnPropertyChanged("ParentGenreErrorVisibility");
            }
        }

        public EditOrAddGenreWindowVM(ICollectionsEntity collectionEntity, GenreVM genre = null)
        {
            _collectionEntity = collectionEntity;
            _genre = genre;

            if (_genre != null)
            {
                if (_genre.ParentGenreId != null)
                    ParentGenre = new GenreVM(Genre.GetById((Guid)_genre.ParentGenreId));
                Name = _genre.Name;
                GenreTypeUkr = _genre.GenreTypeUkr;
                Summary = _genre.Summary;
            }

            NameErrorVisibility = Visibility.Hidden;
            ParentGenreErrorVisibility = Visibility.Hidden;
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

            if(_genre != null && ParentGenre != null)
                if (!_genre.CanBeParentGenre(ParentGenre))
                {
                    ParentGenreErrorVisibility = Visibility.Visible;
                    _isError = true;
                }
                else ParentGenreErrorVisibility = Visibility.Hidden;

            if (_isError)
                return false;

            if (_genre == null)
            {
                GenreVM genre = new GenreVM(ParentGenre, Name, (Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(GenreTypeUkr),
                Summary);
                genre.GenreDL.Save();
                _collectionEntity.Add(genre);
            }
            else
            {
                if (ParentGenre != null)
                    _genre.ParentGenreId = ParentGenre.GenreDL.Id;
                else _genre.ParentGenreId = null;
                _genre.Name = Name;
                _genre.GenreType = (Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(GenreTypeUkr);
                _genre.Summary = Summary;

                _genre.GenreDL.Save();
            }
            return true;
        }

    }
}
