using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace WpfCritic.DataLayer
{
    public class Connection
    {
        private static Connection _instance;

        private bool _isReady = false;
        private string _connectionString;
        private SqlConnection _connection;

        private string _login;

        public static Connection Instance
        {
            get
            {
                if (_instance == null)
                    return _instance = new Connection();
                else return _instance;
            }
        }

        public bool IsReady
        {
            get { return _isReady; }
        }

        public string ConnectionString
        {
            set
            {
                if (!IsReady)
                {
                    _connectionString = value;

                    _connection = new SqlConnection(_connectionString);
                    try
                    {
                        _connection.Open();
                        _connection.Close();
                        _isReady = true;
                    }
                    catch (SqlException sqlException)
                    {
                        StringBuilder errors = new StringBuilder("Помилка підключення до бази даних! Перевірте правильність введених логіна та пароля." + Environment.NewLine);
                        foreach (SqlError error in sqlException.Errors)
                            errors.Append("Помилка " + error.Number + ": " + error.Message + Environment.NewLine);
                        MessageBox.Show(errors.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
            }
        }

        public SqlConnection MSSQLConnection
        {
            get { return _connection; }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                if (_login == null || _login == String.Empty)
                    _login = value;
            }
        }

        private Connection(){ }       
    }
}
