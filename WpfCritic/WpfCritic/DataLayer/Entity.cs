using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WpfCritic.DataLayer
{
    [ConnectionName("MaxCritic")]
    public class Entity<T> where T : Entity<T>
    {
        private static SqlDataAdapter _dataAdapter;
        private static DataTable _dataTable = new DataTable();
        private static string _connectionString;

        private static string _idColumnName;
        private static string _connectionName;
        private static string _tableName;
        protected static string _nameColumnName;

        private DataRow _row;
        protected DataRow Row
        {
            get { return _row; }
            set
            {
                if (_row == null)
                    _row = value;
            }
        }

        private bool _isNew;
        public bool IsNew { get { return _isNew; } }

        public Guid Id
        {
            get { return (Guid)Row[_idColumnName]; }
            private set { Row[_idColumnName] = value; }
        }

        static Entity()
        {
            _idColumnName = ((IdColumnNameAttribute)typeof(T).GetCustomAttributes(typeof(IdColumnNameAttribute), false)[0]).Name;
            _connectionName = ((ConnectionNameAttribute)typeof(Entity<T>).GetCustomAttributes(typeof(ConnectionNameAttribute), false)[0]).Name;
            _tableName = ((TableNameAttribute)typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false)[0]).Name;
            _nameColumnName = ((NameColumnNameAttribute)typeof(T).GetCustomAttributes(typeof(NameColumnNameAttribute), false)[0]).Name;

            _connectionString = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
            SqlConnection connection = new SqlConnection(_connectionString);

            string selectSQL = "SELECT * FROM " + _tableName + ";";
            _dataAdapter = new SqlDataAdapter(selectSQL, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            _dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            _dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(1) * FROM " + _tableName + ";";
            _dataTable.TableName = _tableName;
            _dataAdapter.Fill(_dataTable);
        }

        public Entity(DataRow row = null)
        {
            if (row != null)
            {
                Row = row;
                _isNew = false;
            }
            else
            {
                _row = _dataTable.NewRow();
                Id = Guid.NewGuid();
                _isNew = true;
            }
        }

        public void Save()
        {
            if (IsNew)
            {
                _dataTable.Rows.Add(_row);
                _isNew = false;
            }
            _dataAdapter.Update(new DataRow[] { _row });
        }

        public void Delete()
        {
            _row.Delete();
            _dataAdapter.Update(new DataRow[] { _row });
        }

        public static T GetById(Guid id)
        {
            DataRow[] result = _dataTable.Select(_idColumnName + " = '" + id.ToString() + "'");
            if (result.Length == 1)
                return (T)Activator.CreateInstance(typeof(T), result[0]);
            else
            {
                _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE " + _idColumnName + "=@id;";

                if (!_dataAdapter.SelectCommand.Parameters.Contains("@id"))
                    _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
                else
                    _dataAdapter.SelectCommand.Parameters["@id"].Value = id;

                if (_dataAdapter.Fill(_dataTable) == 1)
                    return (T)Activator.CreateInstance(typeof(T), _dataTable.Select(_idColumnName + " = '" + id.ToString() + "'")[0]);
                return null;
            }
        } 

        protected static T[] GetByQuery(string query)
        {
            List<T> result = new List<T>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + ((query == "") ? ";" : " WHERE " + query + ";");
            _dataTable.Clear();
            if (_dataAdapter.Fill(_dataTable) > 0)
            {
                foreach (DataRow dr in _dataTable.Rows)
                {
                    result.Add((T)Activator.CreateInstance(typeof(T), dr));
                }
                return result.ToArray();
            }
            return null;
        }

        public static T[] GetAllItems()
        { return GetByQuery(""); }

        public static T[] GetByName(string partOfName)
        {
            if (_nameColumnName == null)
                return null;
            List<T> result = new List<T>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE " + _nameColumnName + " LIKE '%' + @partOfName+ '%'";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
            else
                _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;

            _dataTable.Clear();
            if (_dataAdapter.Fill(_dataTable) > 0)
            {
                foreach (DataRow dr in _dataTable.Rows)
                {
                    result.Add((T)Activator.CreateInstance(typeof(T), dr));
                }
                return result.ToArray();
            }
            return null;
        }

        public static T[] GetRandomFirstTen()
        {
            List<T> result = new List<T>();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(10) * FROM " + _tableName + ";";
            _dataTable.Clear();
            if (_dataAdapter.Fill(_dataTable) > 0)
            {
                foreach (DataRow dr in _dataTable.Rows)
                {
                    result.Add((T)Activator.CreateInstance(typeof(T), dr));
                }
                return result.ToArray();
            }
            return null;
        }

    }
}
