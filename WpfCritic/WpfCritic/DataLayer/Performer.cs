using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WpfCritic.DataLayer
{
    [TableName("Performer")]
    [IdColumnName("PerformerId")]
    [NameColumnName("Name")]
    public class Performer : Entity<Performer>
    {
        public string Name
        {
            get { return Row["Name"].ToString(); }
            set { Row["Name"] = value; }
        }
        public string Surname
        {
            get { return Row["Surname"].ToString(); }
            set
            {
                if (value != String.Empty)
                    Row["Surname"] = value;
                else Row["Surname"] = DBNull.Value;
            }
        }
        public Performer.Type PerformerType
        {
            get { return (Performer.Type)Enum.Parse(typeof(Performer.Type), Row["PerformerType"].ToString()); }
            set { Row["PerformerType"] = value; }
        }
        public DateTime? DateOfBirth
        {
            get { return Row["DateOfBirth"].Equals(DBNull.Value) ? default(DateTime?) : (DateTime)Row["DateOfBirth"]; }
            set
            {
                if (value != null)
                    Row["DateOfBirth"] = value;
                else Row["DateOfBirth"] = DBNull.Value;
            }
        }
        public byte[] Image
        {
            get { return Row["Image"].Equals(DBNull.Value) ? null : (byte[])Row["Image"]; }
            set
            {
                if (value != null)
                    Row["Image"] = value;
                else Row["Image"] = DBNull.Value;
            }
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

        public static Performer[] GetByName(string partOfName, Performer.Type? type = null)
        {
            if (type == null)
                return Entity<Performer>.GetByName(partOfName);

            partOfName = partOfName.ToLower();

            List<Performer> result = new List<Performer>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(" + _nameColumnName + ") LIKE '%' + @partOfName + '%' AND PerformerType=@type";

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
                               where ((Performer.Type)Enum.Parse(typeof(Performer.Type), row["PerformerType"].ToString()) == type)
                               && (row[_nameColumnName].ToString().ToLower().Contains(partOfName))
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Performer(dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Performer[] GetRandomFirstTen(Performer.Type? type = null)
        {
            if (type == null)
                return Entity<Performer>.GetRandomFirstTen();

            List<Performer> result = new List<Performer>();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(10) * FROM " + _tableName + " WHERE PerformerType=@type;";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@type"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@type", type.ToString()));
            else
                _dataAdapter.SelectCommand.Parameters["@type"].Value = type.ToString();

            _dataAdapter.Fill(_dataTable);
            var selectedRows = (from row in _dataTable.AsEnumerable().AsParallel()
                                where (Performer.Type)Enum.Parse(typeof(Performer.Type), row["PerformerType"].ToString()) == type
                                select row).Take(10);
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Performer(dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Performer[] GetAlbumAuthorsByAlbum(Entertainment entertainment)
        {
            if (entertainment.EntertainmentType != Entertainment.Type.Album)
                return null;

            PerformerInEntertainment[] performerInEntertainments = PerformerInEntertainment.GetAlbumAuthorsPerformerInEntertainmentsByEntertainment(entertainment);
            if (performerInEntertainments == null)
                return null;
            List<Guid> ids = new List<Guid>();
            foreach (var performerInEntertainment in performerInEntertainments)
                ids.Add(performerInEntertainment.PerformerId);

            return Performer.GetByIds(ids.ToArray());
        }

        public Performer(DataRow row) : base(row)
        {
            if (PerformerType == Performer.Type.Person)
                _nameColumnName = "Surname"; // если Performer - человек, то поиск по имени в Entity будет производиться по фамилии
        }
        public Performer(string name, string surname, Performer.Type performerType, DateTime? dateOfBirth, byte[] image,
        string summary) : base()
        {
            Name = name;
            Surname = surname;
            PerformerType = performerType;
            DateOfBirth = dateOfBirth;
            Image = image;
            Summary = summary;
            if (PerformerType == Performer.Type.Person)
                _nameColumnName = "Surname"; // если Performer - человек, то поиск по имени в Entity будет производиться по фамилии
        }

        public enum Type { Person, GameDeveloperCompany, GamePlatform, MovieProduction, TVNetwork, RecordLabel, Band }
    }
}
