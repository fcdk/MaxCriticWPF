﻿using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("Genre")]
    [IdColumnName("GenreId")]
    [NameColumnName("Name")]
    public class Genre : Entity<Genre>
    {
        public Guid? ParentGenreId
        {
            get { return Row["ParentGenreId"].Equals(DBNull.Value) ? default(Guid?) : (Guid)Row["ParentGenreId"]; }
            set { Row["ParentGenreId"] = value; }
        }
        public string Name
        {
            get { return Row[_nameColumnName].ToString(); }
            set { Row[_nameColumnName] = value; }
        }
        public Entertainment.Type GenreType
        {
            get { return (Entertainment.Type)Enum.Parse(typeof(Entertainment.Type), Row["GenreType"].ToString()); }
            set { Row["GenreType"] = value; }
        }
        public string Summary
        {
            get { return Row["Summary"].ToString(); }
            set { Row["Summary"] = value; }
        }

        public Genre(DataRow row) : base(row) { }
        public Genre(Genre parentGenre, string name, Entertainment.Type genreType, string summary) : base()
        {
            if (parentGenre == null)
                ParentGenreId = default(Guid?);
            else ParentGenreId = parentGenre.Id;
            Name = name;
            GenreType = genreType;
            Summary = summary;
        }

    }
}