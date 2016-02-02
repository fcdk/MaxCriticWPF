using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfCritic.DataLayer
{
    public class Entity<T> where T : Entity<T>
    {
        protected static SqlDataAdapter _dataAdapter;
        protected static DataTable _dataTable = new DataTable();
        private static string _connectionString;

        protected static string _idColumnName;
        private static string _connectionName;
        protected static string _tableName;
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
            _tableName = ((TableNameAttribute)typeof(T).GetCustomAttributes(typeof(TableNameAttribute), false)[0]).Name;
            _nameColumnName = ((NameColumnNameAttribute)typeof(T).GetCustomAttributes(typeof(NameColumnNameAttribute), false)[0]).Name;

            string selectSQL = "SELECT * FROM " + _tableName + ";";
            _dataAdapter = new SqlDataAdapter(selectSQL, Connection.Instance.MSSQLConnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(_dataAdapter);
            _dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            _dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            _dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(1) * FROM " + _tableName + ";";
            _dataAdapter.Fill(_dataTable);

            _dataTable.TableName = _tableName;
            _dataTable.PrimaryKey = new DataColumn[] { _dataTable.Columns[_idColumnName] };
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
            var query = from row in _dataTable.AsEnumerable().AsParallel()
                        where (Guid)row[_idColumnName] == id
                        select row;
            DataRow[] result = query.ToArray();
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
                {
                    var selectedRow = from row in _dataTable.AsEnumerable().AsParallel()
                                      where (Guid)row[_idColumnName] == id
                                      select row;
                    return (T)Activator.CreateInstance(typeof(T), selectedRow.ToArray()[0]);
                }
                return null;
            }
        }

        public static T[] GetByIds(Guid[] ids)
        {
            List<T> result = new List<T>();

            StringBuilder sqlSelect = new StringBuilder(_idColumnName + " IN (");
            foreach (Guid id in ids)
            {
                sqlSelect.Append("'");
                sqlSelect.Append(id.ToString());
                sqlSelect.Append("',");
            }
            sqlSelect.Length -= 1; // удалили последнюю запятую
            sqlSelect.Append(")");
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE " + sqlSelect.ToString();

            _dataAdapter.Fill(_dataTable);
            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where ids.Contains((Guid)row[_idColumnName])
                               select row;
            foreach (DataRow dr in selectedRows)
            {
                result.Add((T)Activator.CreateInstance(typeof(T), dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        protected static T[] GetByQuery(string query)
        {
            List<T> result = new List<T>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + ((query == "") ? ";" : " WHERE " + query + ";");
            _dataAdapter.Fill(_dataTable);
            DataRow[] selectedRows = _dataTable.Select(query);
            if (selectedRows.Length != 0)
            {
                foreach (DataRow dr in selectedRows)
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

            partOfName = partOfName.ToLower();

            List<T> result = new List<T>();
            _dataAdapter.SelectCommand.CommandText = "SELECT * FROM " + _tableName + " WHERE LOWER(" + _nameColumnName + ") LIKE '%' + @partOfName+ '%'";

            if (!_dataAdapter.SelectCommand.Parameters.Contains("@partOfName"))
                _dataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@partOfName", partOfName));
            else
                _dataAdapter.SelectCommand.Parameters["@partOfName"].Value = partOfName;

            _dataAdapter.Fill(_dataTable);

            var selectedRows = from row in _dataTable.AsEnumerable().AsParallel()
                               where row[_nameColumnName].ToString().ToLower().Contains(partOfName)
                               select row;

            foreach (DataRow dr in selectedRows)
            {
                result.Add((T)Activator.CreateInstance(typeof(T), dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }

        public static T[] GetRandomFirstTen()
        {
            List<T> result = new List<T>();

            _dataAdapter.SelectCommand.CommandText = "SELECT TOP(10) * FROM " + _tableName + ";";

            _dataAdapter.Fill(_dataTable);
            var selectedRows = (from row in _dataTable.AsEnumerable().AsParallel()
                                select row).Take(10);
            foreach (DataRow dr in selectedRows)
            {
                result.Add((T)Activator.CreateInstance(typeof(T), dr));
            }
            if (result.Count != 0)
                return result.ToArray();
            return null;
        }
        
        public static bool Comparison (Entity<T> entity1, Entity<T> entity2)
        {
            if (Object.ReferenceEquals(entity1, entity2)) { return true; }
            if (entity1 == null || entity2 == null) { return false; }
            return entity1.Id == entity2.Id;
        }

    }
}
