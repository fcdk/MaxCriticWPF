using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("SongInEntertainment")]
    [IdColumnName("SongInEntertainmentId")]
    [NameColumnName(null)]
    public class SongInEntertainment : Entity<SongInEntertainment>
    {
        public Guid SongId
        {
            get { return (Guid)Row["SongId"]; }
            private set { Row["SongId"] = value; }
        }
        public Guid EntertainmentId
        {
            get { return (Guid)Row["EntertainmentId"]; }
            private set { Row["EntertainmentId"] = value; }
        }

        public SongInEntertainment(DataRow row) : base(row) { }
        public SongInEntertainment(Song song, Entertainment entertainment) : base()
        {
            SongId = song.Id;
            EntertainmentId = entertainment.Id;
        }

    }
}
