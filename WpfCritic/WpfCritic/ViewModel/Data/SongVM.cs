using System;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class SongVM : ViewModelBase
    {
        private Song _song;

        public Song SongDL
        {
            get { return _song; }
        }

        public string Name
        {
            get { return _song.Name; }
            set { _song.Name = value; OnPropertyChanged("Name"); }
        }

        public TimeSpan Duration
        {
            get { return _song.Duration; }
            set { _song.Duration = value; OnPropertyChanged("Duration"); }
        }

        public string Lyrics
        {
            get { return _song.Lyrics; }
            set { _song.Lyrics = value; OnPropertyChanged("Lyrics"); }
        }

        public SongVM(Song song)
        {
            _song = song;
        }

        public SongVM(string name, TimeSpan duration, string lyrics)
        {
            _song = new Song(name, duration, lyrics);
        }

        public override string ToString()
        {
            return Name + " " + Duration.ToString(@"hh\:mm\:ss");
        }

        public static bool Comparison (SongVM song1, SongVM song2)
        {
            if (song1 == null || song2 == null)
                return false;
            return Entity<Song>.Comparison(song1.SongDL, song2.SongDL);
        }

    }
}
