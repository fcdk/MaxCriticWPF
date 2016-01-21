using System;
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
        }

        public SongInEntertainmentVM(SongVM song, EntertainmentVM entertainment)
        {
            _songInEntertainment = new SongInEntertainment(song.SongDL, entertainment.EntertainmentDL);
        }

    }
}
