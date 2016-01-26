using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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
            set
            {
                if (value != null)
                    Row["ParentGenreId"] = value;
                else Row["ParentGenreId"] = DBNull.Value;
            }
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
            set
            {
                if (value != String.Empty)
                    Row["Summary"] = value;
                else Row["Summary"] = DBNull.Value;
            }
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

        public static Genre[] GetByName(string partOfName, Entertainment.Type? type = null)
        {
            if (type == null)
                return Entity<Genre>.GetByName(partOfName);

            partOfName = partOfName.ToLower();

            List<Genre> result = new List<Genre>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(" + _nameColumnName + ") LIKE '%' + @partOfName + '%' AND GenreType=@type";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
            else
                _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;
            if (!_dataAdapter.SelectCommand.Parameters.Contains("@type"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@type", type.ToString()));
            else
                _dataAdapter.SelectCommand.Parameters["@type"].Value = type.ToString();

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where ((Entertainment.Type)Enum.Parse(typeof(Entertainment.Type), row["GenreType"].ToString()) == type)
                               && (row[_nameColumnName].ToString().ToLower().Contains(partOfName))
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Genre(dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

    }
}
