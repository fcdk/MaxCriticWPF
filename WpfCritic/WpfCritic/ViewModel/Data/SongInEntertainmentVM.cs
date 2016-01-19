using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class SongInEntertainmentVM : ViewModelBase
    {
        private SongInEntertainment _songInEntertainment;
        private SongVM _song;
        private EntertainmentVM _entertainment;

        public SongInEntertainment SongInEntertainmentDL
        {
            get { return _songInEntertainment; }
        }

        public SongVM Song
        {
            get { return _song; }
            set { _song = value; OnPropertyChanged("Song"); }
        }

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
            set { _entertainment = value; OnPropertyChanged("Entertainment"); }
        }

        public SongInEntertainmentVM(SongVM song, EntertainmentVM entertainment)
        {
            Song = song;
            Entertainment = entertainment;
            _songInEntertainment = new SongInEntertainment(Song.SongDL, Entertainment.EntertainmentDL);
        }

    }
}
