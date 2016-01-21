using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("GenreInEntertainment")]
    [IdColumnName("GenreInEntertainmentId")]
    [NameColumnName(null)]
    public class GenreInEntertainment : Entity<GenreInEntertainment>
    {
        public Guid EntertainmentId
        {
            get { return (Guid)Row["EntertainmentId"]; }
            set { Row["EntertainmentId"] = value; }
        }
        public Guid GenreId
        {
            get { return (Guid)Row["GenreId"]; }
            set { Row["GenreId"] = value; }
        }

        public GenreInEntertainment(DataRow row) : base(row) { }
        public GenreInEntertainment(Entertainment entertainment, Genre genre) : base()
        {
            EntertainmentId = entertainment.Id;
            GenreId = genre.Id;
        }

    }
}
