using System;
using WpfCritic.Core;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class GenreVM : ViewModelBase
    {
        private Genre _genre;

        public Genre GenreDL
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
            set { _genre.Summary = value; OnPropertyChanged("Summary"); }
        }

        public GenreVM(Genre genre)
        {
            _genre = genre;

            Logger.Info("GenreVM.GenreVM", "Екземпляр GenreVM створений.");
        }

        public GenreVM(GenreVM parentGenre, string name, Entertainment.Type genreType, string summary)
        {
            if (parentGenre != null)
                _genre = new Genre(parentGenre.GenreDL, name, genreType, summary);
            else _genre = new Genre(null, name, genreType, summary);

            Logger.Info("GenreVM.GenreVM", "Екземпляр GenreVM створений.");
        }

        public override string ToString()
        {
            return Name;
        }
        
        public bool CanBeParentGenre(GenreVM genre)
        {
            Logger.Info("GenreVM.CanBeParentGenre", "Перевірка на те, чи може бути екземпляр класу бути батьківський для даного.");

            return this.GenreDL.CanBeParentGenre(genre.GenreDL);
        }

        public static bool Comparison(GenreVM genre1, GenreVM genre2)
        {
            Logger.Info("GenreVM.Comparison", "Порівняння двох екземплярів GenreVM.");

            if (genre1 == null || genre2 == null)
                return false;
            return Entity<Genre>.Comparison(genre1.GenreDL, genre2.GenreDL);
        }

    }
}
