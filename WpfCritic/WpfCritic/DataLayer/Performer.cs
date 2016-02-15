using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WpfCritic.Core;

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
            Logger.Info("Performer.GetByName", "Спроба взяти з БД записи Performer за назвою.");

            List<Performer> result = new List<Performer>();
            partOfName = partOfName.ToLower();
            
            if (type == null)
            {
                _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(Name) + ' ' + LOWER(ISNULL(Surname,'')) LIKE '%' + @partOfName + '%'";

                if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                    _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
                else
                    _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;

                _dataAdapter.Fill(_dataTable);
                var selectedRows1 = from row in _dataTable.AsEnumerable().AsParallel()
                                   where (row["Name"].ToString().ToLower()+ " " + row["Surname"].ToString().ToLower()).Contains(partOfName)
                                   select row;
                foreach (DataRow dr in selectedRows1)
                {
                    result.Add(new Performer(dr));
                }

                Logger.Info("Performer.GetByName", "Зчитано з БД записи Performer за назвою.");

                if (result.Count != 0)
                    return result.ToArray();
                return null;
            }              

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE (LOWER(Name) LIKE '%' + @partOfName + '%' OR LOWER(Surname) LIKE '%' + @partOfName + '%') AND PerformerType=@type";

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
                               && (row["Name"].ToString().ToLower().Contains(partOfName) || row["Surname"].ToString().ToLower().Contains(partOfName))
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new Performer(dr));
            }

            Logger.Info("Performer.GetByName", "Зчитано з БД записи Performer за назвою.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Performer[] GetForAutoCompleteBox(string partOfName)
        {
            Logger.Info("Performer.GetForAutoCompleteBox", "Спроба взяти з БД записи Performer для автозаповнення текстового поля.");

            List<Performer> result = new List<Performer>();
            partOfName = partOfName.ToLower();

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(Name) + ISNULL(' ' + LOWER(Surname), '') + ISNULL(' (' + FORMAT(DateOfBirth, 'dd.MM.yyyy') + ')','') LIKE '%' + @partOfName + '%'";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                    _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
            else
                _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;

            _dataAdapter.Fill(_dataTable);
            var selectedRows1 = from row in _dataTable.AsEnumerable().AsParallel()
                                where (row["Name"].ToString().ToLower() + (row["Surname"] == DBNull.Value ? "" : " " + row["Surname"].ToString().ToLower()) + 
                                (row["DateOfBirth"] == DBNull.Value ? "" : " (" + ((DateTime)row["DateOfBirth"]).ToString("dd/MM/yyyy")) + ")").Contains(partOfName)
                                select row;
            foreach (DataRow dr in selectedRows1)
            {
                result.Add(new Performer(dr));
            }

            Logger.Info("Performer.GetForAutoCompleteBox", "Зчитано з БД записи Performer для автозаповнення текстового поля.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Performer[] GetRandomFirstTen(Performer.Type? type = null)
        {
            Logger.Info("Performer.GetRandomFirstTen", "Спроба взяти з БД перші 10 записів Performer.");

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

            Logger.Info("Performer.GetRandomFirstTen", "Зчитано з БД перші 10 записів Performer.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static Performer[] GetAlbumAuthorsByAlbum(Entertainment entertainment)
        {
            Logger.Info("Performer.GetAlbumAuthorsByAlbum", "Спроба взяти з БД записи альбомів за виконавцем.");

            if (entertainment.EntertainmentType != Entertainment.Type.Album)
                return null;

            PerformerInEntertainment[] performerInEntertainments = PerformerInEntertainment.GetAlbumAuthorsPerformerInEntertainmentsByEntertainment(entertainment);
            if (performerInEntertainments == null)
                return null;
            List<Guid> ids = new List<Guid>();
            foreach (var performerInEntertainment in performerInEntertainments)
                ids.Add(performerInEntertainment.PerformerId);

            Logger.Info("Performer.GetAlbumAuthorsByAlbum", "Зчитано з БД записи альбомів за виконавцем.");

            return Performer.GetByIds(ids.ToArray());
        }

        public Performer(DataRow row) : base(row)
        {
            Logger.Info("Performer.Performer", "Створено екземпляр Performer.");
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

            Logger.Info("Performer.Performer", "Створено екземпляр Performer.");
        }

        public enum Type { Person, GameDeveloperCompany, GamePlatform, MovieProduction, TVNetwork, RecordLabel, Band }
    }
}
