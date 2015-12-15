using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    public class GameManager
    {
        private DataSet _dataSet = new DataSet();
        private SqlDataAdapter _gameAdapter;

        public GameDL[] GetGames()
        {
            List<GameDL> gameList = new List<GameDL>();

            SqlDataAdapter gameAdapter = GetGameDataAdapter();

            gameAdapter.Fill(_dataSet, "Game");

            foreach (DataRow row in _dataSet.Tables["Game"].Rows)
            {
                GameDL game = new GameDL(row);
                game.GameID = Convert.ToInt32(row["ID"]);
                game.ReleaseDate = Convert.ToDateTime(row["ReleaseDate"]);
                game.Company = row["Company"].ToString();
                game.Poster = row["Poster"].ToString();
                game.Name = row["Name"].ToString();
                game.Developer = row["Developer"].ToString();
                game.OfficialSite = row["OfficialSite"].ToString();
                game.Trailer = row["Trailer"].ToString();

                gameList.Add(game);
            }

            return gameList.ToArray();
        }

        private SqlDataAdapter GetGameDataAdapter()
        {
            if (_gameAdapter == null)
            {
                string connectionString = GetConnectionString();
                SqlConnection connection = new SqlConnection(connectionString);

                string selectGameSQL = "SELECT * FROM Game";

                _gameAdapter = new SqlDataAdapter(selectGameSQL, connection);

                CreateAllCommands(_gameAdapter);
            }
            return _gameAdapter;
        }

        private void CreateAllCommands(SqlDataAdapter adapter)
        {
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.InsertCommand = commandBuilder.GetInsertCommand();
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
        }

        private string GetConnectionString()
        {
            return @"Data Source=MAX\SQLEXPRESS;Initial Catalog=maxcritic;Integrated Security=True";
        }
    }
}
