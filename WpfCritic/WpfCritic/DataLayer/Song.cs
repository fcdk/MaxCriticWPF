using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        //public Song[] GetSongsByEntertainment(Entertainment entertainment)
        //{
        //    List<Song> result = new List<Song>();

        //    _dataAdapter.SelectCommand.CommandText = "SELECT SongId, Name, Duration, Lyrics FROM " + _tableName + ", " + SongInEntertainment._tableName + " WHERE EntertainmentId=@id;";

        //    if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
        //        _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", entertainment.Id.ToString()));
        //    else
        //        _dataAdapter.SelectCommand.Parameters["@id"].Value = entertainment.Id.ToString();

        //    _dataAdapter.Fill(_dataTable);


        //}

        public Song(DataRow row) : base(row) { }
        public Song(string name, TimeSpan duration, string lyrics) : base()
        {
            Name = name;
            Duration = duration;
            Lyrics = lyrics;
        }

    }
}
