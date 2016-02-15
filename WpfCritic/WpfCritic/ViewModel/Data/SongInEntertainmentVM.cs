using System;
using WpfCritic.Core;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class SongInEntertainmentVM : ViewModelBase
    {
        private SongInEntertainment _songInEntertainment;

        public SongInEntertainment SongInEntertainmentDL
        {
            get { return _songInEntertainment; }
        }

        public Guid SongId
        {
            get { return _songInEntertainment.SongId; }
            set { _songInEntertainment.SongId = value; OnPropertyChanged("SongId"); }
        }
        public Guid EntertainmentId
        {
            get { return _songInEntertainment.EntertainmentId; }
            set { _songInEntertainment.EntertainmentId = value; OnPropertyChanged("EntertainmentId"); }
        }

        public SongInEntertainmentVM(SongInEntertainment songInEntertainment)
        {
            _songInEntertainment = songInEntertainment;

            Logger.Info("SongInEntertainmentVM.SongInEntertainmentVM", "Екземпляр SongInEntertainmentVM створений.");
        }

        public SongInEntertainmentVM(SongVM song, EntertainmentVM entertainment)
        {
            _songInEntertainment = new SongInEntertainment(song.SongDL, entertainment.EntertainmentDL);

            Logger.Info("SongInEntertainmentVM.SongInEntertainmentVM", "Екземпляр SongInEntertainmentVM створений.");
        }

        public bool SongComparison(SongVM song)
        {
            Logger.Info("SongInEntertainmentVM.GenreComparison", "Порівняння даного екзмпляра жанру з жанром у SongInEntertainmentVM.");

            return song.SongDL.Id == this.SongId;
        }

        public static bool Comparison (SongInEntertainmentVM songInEntertainment1, SongInEntertainmentVM songInEntertainment2)
        {
            Logger.Info("SongInEntertainmentVM.Comparison", "Порівняння двох екземплярів SongInEntertainmentVM.");

            if (songInEntertainment1 == null || songInEntertainment2 == null)
                return false;
            return Entity<SongInEntertainment>.Comparison(songInEntertainment1.SongInEntertainmentDL, songInEntertainment2.SongInEntertainmentDL);
        }

    }
}
