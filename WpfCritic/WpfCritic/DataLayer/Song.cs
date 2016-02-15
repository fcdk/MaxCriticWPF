using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WpfCritic.Core;

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
            set
            {
                if (value != String.Empty)
                    Row["Lyrics"] = value;
                else Row["Lyrics"] = DBNull.Value;
            }
        }

        public Song(DataRow row) : base(row)
        {
            Logger.Info("Song.Song", "Створено екземпляр Song.");
        }
        public Song(string name, TimeSpan duration, string lyrics) : base()
        {
            Name = name;
            Duration = duration;
            Lyrics = lyrics;

            Logger.Info("Song.Song", "Створено екземпляр Song.");
        }

    }
}
