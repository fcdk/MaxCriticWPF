﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WpfCritic.Core;

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
            set { Row["SongId"] = value; }
        }
        public Guid EntertainmentId
        {
            get { return (Guid)Row["EntertainmentId"]; }
            set { Row["EntertainmentId"] = value; }
        }

        public SongInEntertainment(DataRow row) : base(row)
        {
            Logger.Info("SongInEntertainment.SongInEntertainment", "Створено екземпляр SongInEntertainment.");
        }
        public SongInEntertainment(Song song, Entertainment entertainment) : base()
        {
            SongId = song.Id;
            EntertainmentId = entertainment.Id;

            Logger.Info("SongInEntertainment.SongInEntertainment", "Створено екземпляр SongInEntertainment.");
        }

        public static SongInEntertainment[] GetSongInEntertainmentByEntertainment(Entertainment entertainment)
        {
            Logger.Info("SongInEntertainment.GetSongInEntertainmentByEntertainment", "Спроба взяти з БД записи SongInEntertainment за Entertainment.");

            List<SongInEntertainment> result = new List<SongInEntertainment>();

            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE EntertainmentId=@id";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", entertainment.Id));
            else
                _dataAdapter.SelectCommand.Parameters["@id"].Value = entertainment.Id;

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where (Guid)row["EntertainmentId"] == entertainment.Id
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add(new SongInEntertainment(dr));
            }

            Logger.Info("SongInEntertainment.GetSongInEntertainmentByEntertainment", "Зчитано з БД записи SongInEntertainment за Entertainment.");

            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

    }
}
