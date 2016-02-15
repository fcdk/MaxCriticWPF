using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WpfCritic.Core;

namespace WpfCritic.DataLayer
{
    [TableName("PerformerInEntertainment")]
    [IdColumnName("PerformerInEntertainmentId")]
    [NameColumnName(null)]
    public class PerformerInEntertainment : Entity<PerformerInEntertainment>
    {
        public Guid PerformerId
        {
            get { return (Guid)Row["PerformerId"]; }
            set { Row["PerformerId"] = value; }
        }
        public Guid EntertainmentId
        {
            get { return (Guid)Row["EntertainmentId"]; }
            set { Row["EntertainmentId"] = value; }
        }
        public PerformerInEntertainment.Role PerformerRole
        {
            get { return (PerformerInEntertainment.Role)Enum.Parse(typeof(PerformerInEntertainment.Role), Row["PerformerRole"].ToString()); }
            set { Row["PerformerRole"] = value; }
        }               

        public PerformerInEntertainment(DataRow row) : base(row)
        {
            Logger.Info("PerformerInEntertainment.PerformerInEntertainment", "Створено екземпляр PerformerInEntertainment.");
        }
        public PerformerInEntertainment(Performer performer, Entertainment entertainment, PerformerInEntertainment.Role performerRole) : base()
        {
            PerformerId = performer.Id;
            EntertainmentId = entertainment.Id;
            PerformerRole = performerRole;

            Logger.Info("PerformerInEntertainment.PerformerInEntertainment", "Створено екземпляр PerformerInEntertainment.");
        }

        public static PerformerInEntertainment[] GetPerformerInEntertainmentByEntertainmentAndRole(Entertainment entertainment, PerformerInEntertainment.Role role)
        {
            Logger.Info("PerformerInEntertainment.GetPerformerInEntertainmentByEntertainmentAndRole", "Спроба взяти з БД записи PerformerInEntertainment за Entertainment та ролью.");

            List<PerformerInEntertainment> result = new List<PerformerInEntertainment>();

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE EntertainmentId=@id AND PerformerRole=@role";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", entertainment.Id));
            else
                _dataAdapter.SelectCommand.Parameters["@id"].Value = entertainment.Id;
            if (!_dataAdapter.SelectCommand.Parameters.Contains("@role"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@role", role.ToString()));
            else
                _dataAdapter.SelectCommand.Parameters["@role"].Value = role.ToString();

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where ((Guid)row["EntertainmentId"] == entertainment.Id)
                               && ((PerformerInEntertainment.Role)Enum.Parse(typeof(PerformerInEntertainment.Role), row["PerformerRole"].ToString()) == role)
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new PerformerInEntertainment(dr));
            }

            Logger.Info("PerformerInEntertainment.GetPerformerInEntertainmentByEntertainmentAndRole", "Зчитано з БД записи PerformerInEntertainment за Entertainment та ролью.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static PerformerInEntertainment[] GetAlbumAuthorsPerformerInEntertainmentsByEntertainment(Entertainment entertainment)
        {
            Logger.Info("PerformerInEntertainment.GetAlbumAuthorsPerformerInEntertainmentsByEntertainment", "Спроба взяти з БД записи PerformerInEntertainment авторів альбому за Entertainment.");

            List<PerformerInEntertainment> result = new List<PerformerInEntertainment>();

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE EntertainmentId=@id AND (PerformerRole='AlbumBand' OR PerformerRole='AlbumSinger')";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", entertainment.Id));
            else
                _dataAdapter.SelectCommand.Parameters["@id"].Value = entertainment.Id;

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where ((Guid)row["EntertainmentId"] == entertainment.Id)
                               && (((PerformerInEntertainment.Role)Enum.Parse(typeof(PerformerInEntertainment.Role), row["PerformerRole"].ToString()) == PerformerInEntertainment.Role.AlbumSinger)
                               || ((PerformerInEntertainment.Role)Enum.Parse(typeof(PerformerInEntertainment.Role), row["PerformerRole"].ToString()) == PerformerInEntertainment.Role.AlbumBand))
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new PerformerInEntertainment(dr));
            }

            Logger.Info("PerformerInEntertainment.GetPerformerInEntertainmentByEntertainmentAndRole", "Зчитано з БД записи PerformerInEntertainment авторів альбому за Entertainment.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public enum Role { MovieDirector, MoviePlotWriter, MoviePrincipalCast, MovieCast, MovieProducer, MovieProduction,
        GameCast, GameDeveloperCompany, GamePlatform, TVCast, TVNetwork, AlbumSinger, AlbumBand, AlbumRecordLabel }
    }
}
