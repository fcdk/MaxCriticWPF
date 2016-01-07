using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

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

        private DataRow _row;
        public virtual DataRow Row
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

            _connectionString = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
            SqlConnection connection = new SqlConnection(_connectionString);

            string selectSQL = "SELECT * FROM " + _tableName;
            _dataAdapter = new SqlDataAdapter(selectSQL, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            _dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            _dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(10) * FROM " + _tableName;
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

    }
}
