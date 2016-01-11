using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("Song")]
    [IdColumnName("SongId")]
    [NameColumnName("Name")]
    public class Song : Entity<Song>
    {
        public string Name
        {
            get { return Row[_nameColumnName].ToString(); }
            set { Row[_nameColumnName] = value; }
        }
        public TimeSpan Duration
        {
            get { return (TimeSpan)Row["Duration"]; }
            set { Row["Duration"] = value; }
        }
        public string Lyrics
        {
            get { return Row["Lyrics"].ToString(); }
            set { Row["Lyrics"] = value; }
        }

        public Song(DataRow row) : base(row) { }
        public Song(string name, TimeSpan duration, string lyrics) : base()
        {
            Name = name;
            Duration = duration;
            Lyrics = lyrics;
        }

    }
}
