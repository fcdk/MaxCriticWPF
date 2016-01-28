using System;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class GenreInEntertainmentVM : ViewModelBase
    {

        private GenreInEntertainment _genreInEntertainment;

        public GenreInEntertainment GenreInEntertainmentDL
        {
            get { return _genreInEntertainment; }
        }

        public Guid GenreId
        {
            get { return _genreInEntertainment.GenreId; }
            set { _genreInEntertainment.GenreId = value; OnPropertyChanged("GenreId"); }
        }
        public Guid EntertainmentId
        {
            get { return _genreInEntertainment.EntertainmentId; }
            set { _genreInEntertainment.EntertainmentId = value; OnPropertyChanged("EntertainmentId"); }
        }

        public GenreInEntertainmentVM(GenreInEntertainment genreInEntertainment)
        {
            _genreInEntertainment = genreInEntertainment;
        }

        public GenreInEntertainmentVM(GenreVM genre, EntertainmentVM entertainment)
        {
            _genreInEntertainment = new GenreInEntertainment(entertainment.EntertainmentDL, genre.GenreDL);
        }

        public bool GenreComparison(GenreVM genre)
        {
            return genre.GenreDL.Id == this.GenreId;
        }

        public static bool Comparison(GenreInEntertainmentVM genreInEntertainment1, GenreInEntertainmentVM genreInEntertainment2)
        {
            if (genreInEntertainment1 == null || genreInEntertainment2 == null)
                return false;
            return Entity<GenreInEntertainment>.Comparison(genreInEntertainment1.GenreInEntertainmentDL, genreInEntertainment2.GenreInEntertainmentDL);
        }

    }
}
