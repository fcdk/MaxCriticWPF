using System;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class GenreVM : ViewModelBase
    {
        private Genre _genre;

        public Genre SongDL
        {
            get { return _genre; }
        }

        public Guid? ParentGenreId
        {
            get { return _genre.ParentGenreId; }
            set { _genre.ParentGenreId = value; OnPropertyChanged("ParentGenreId"); }
        }

        public string Name
        {
            get { return _genre.Name; }
            set { _genre.Name = value; OnPropertyChanged("Name"); }
        }

        public Entertainment.Type GenreType
        {
            get { return _genre.GenreType; }
            set
            {
                _genre.GenreType = value;
                OnPropertyChanged("GenreType");
                OnPropertyChanged("GenreTypeUkr");
            }
        }

        public string GenreTypeUkr
        {
            get { return EntertainmentVM.EntertainmentTypeToUkrString(GenreType); }
        }

        public string Summary
        {
            get { return _genre.Summary; }
            set { _genre.Name = value; OnPropertyChanged("Summary"); }
        }

        public GenreVM(Genre genre)
        {
            _genre = genre;
        }

        public GenreVM(Genre parentGenre, string name, Entertainment.Type genreType, string summary)
        {
            _genre = new Genre(parentGenre, name, genreType, summary);
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
