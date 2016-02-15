using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WpfCritic.Core;

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

        public Genre(DataRow row) : base(row)
        {
            Logger.Info("Genre.Genre", "Створено екземпляр Genre.");
        }
        public Genre(Genre parentGenre, string name, Entertainment.Type genreType, string summary) : base()
        {
            if (parentGenre == null)
                ParentGenreId = default(Guid?);
            else ParentGenreId = parentGenre.Id;
            Name = name;
            GenreType = genreType;
            Summary = summary;

            Logger.Info("Genre.Genre", "Створено екземпляр Genre.");
        }

        public static Genre[] GetByName(string partOfName, Entertainment.Type? type = null)
        {
            Logger.Info("Genre.GetByName", "Спроба взяти з БД записи Genre за назвою.");

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

            Logger.Info("Entity.GetByName", "Зчитано з БД записи Genre за назвою.");

            if (result.Count != 0)
                return result.ToArray();
            return null;            
        }

        public static Genre[] GetByNameExceptId(string partOfName, Entertainment.Type type, Guid id)
        {
            Logger.Info("Genre.GetByNameExceptId", "Спроба взяти з БД записи Genre за назвою, за виключенням одного за ID.");

            List<Genre> result = new List<Genre>();

            partOfName = partOfName.ToLower();

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(" + _nameColumnName + ") LIKE '%' + @partOfName + '%' AND GenreType=@type AND " + _idColumnName + "!=@id";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
            else
                _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;
            if (!_dataAdapter.SelectCommand.Parameters.Contains("@type"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@type", type.ToString()));
            else
                _dataAdapter.SelectCommand.Parameters["@type"].Value = type.ToString();
            if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            else
                _dataAdapter.SelectCommand.Parameters["@id"].Value = id;

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where ((Entertainment.Type)Enum.Parse(typeof(Entertainment.Type), row["GenreType"].ToString()) == type)
                               && (row[_nameColumnName].ToString().ToLower().Contains(partOfName))
                               && ((Guid)row[_idColumnName] != id)
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Genre(dr));
            }

            Logger.Info("Entity.GetByName", "Зчитано з БД записи Genre за назвою, за виключенням одного за ID.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Genre[] GetRandomFirstTen(Entertainment.Type? type = null)
        {
            Logger.Info("Genre.GetRandomFirstTen", "Спроба взяти з БД перші 10 записів Genre за типом.");

            if (type == null)
                return Entity<Genre>.GetRandomFirstTen();

            List<Genre> result = new List<Genre>();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(10) * FROM " + _tableName + " WHERE GenreType=@type;";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@type"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@type", type.ToString()));
            else
                _dataAdapter.SelectCommand.Parameters["@type"].Value = type.ToString();

            _dataAdapter.Fill(_dataTable);
            var selectedRows = (from row in _dataTable.AsEnumerable().AsParallel()
                                where (Entertainment.Type)Enum.Parse(typeof(Entertainment.Type), row["GenreType"].ToString()) == type
                                select row).Take(10);
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Genre(dr));
            }

            Logger.Info("Genre.GetRandomFirstTen", "Зчитано з БД перші 10 записів Genre за типом.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public bool CanBeParentGenre(Genre genre)
        {
            Logger.Info("Genre.CanBeParentGenre", "Початок перевірки на те, чи може бути екземпляр класу бути батьківський для даного.");

            if (genre.ParentGenreId == null)
                return true;
            if (genre.ParentGenreId == this.Id)
                return false;
            else return this.CanBeParentGenre(Genre.GetById((Guid)genre.ParentGenreId));
        }

    }
}
