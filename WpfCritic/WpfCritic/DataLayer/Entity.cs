using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WpfCritic.DataLayer
{
    [ConnectionString("MaxCritic")]
    public class Entity<T> where T : Entity<T>
    {
        private SqlDataAdapter _dataAdapter;
        private DataSet _dataSet = new DataSet();
        private string _connectionString;

        private string _idColumnName;
        private string _connectionName;
        private string _tableName;

        private DataRow _row;
        public virtual DataRow Row
        {
            get { return _row; }
            set
            {
                if (_row == null)
                {
                    _row = value;
                    Id = (Guid)value[_idColumnName];
                }
                else
                {
                    Id = (Guid)value[_idColumnName];
                }
            }
        }

        public Guid Id { get; private set; }

        public Entity(DataRow row = null)
        {
            if (row != null)
                Row = row;
            else Id = Guid.NewGuid();

            _idColumnName = ((IdColumnNameAttribute)typeof(T).GetCustomAttributes(typeof(IdColumnNameAttribute), false)[0]).Name;
            _connectionName = ((ConnectionStringAttribute)this.GetType().GetCustomAttributes(typeof(ConnectionStringAttribute), false)[0]).Name;
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
            _dataAdapter.Fill(_dataSet);
        }

    }
}
