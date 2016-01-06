using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.DataLayer
{
    public class Game
    {
        private DataRow _row;

        public DataRow Row
        {
            get { return _row; }
        }

        public int GameID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public string Poster { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public string OfficialSite { get; set; }
        public string Trailer { get; set; }

        public Game(DataRow row)
        {
            _row = row;
        }

        public Game(int gameID, DateTime releaseDate, string company, string poster, string name, string developer, string officialSite, string trailer)
        {
            GameID = gameID;
            ReleaseDate = releaseDate;
            Company = company;
            Poster = poster;
            Name = name;
            Developer = developer;
            OfficialSite = officialSite;
            Trailer = trailer;
        }

        public GameVM ToGameVM()
        {
            return new GameVM(GameID, Name, OfficialSite, Developer, Trailer, ReleaseDate, Company, Poster);
        }

        internal void SetRow(DataRow dataRow)
        {
            if (_row == null)
                _row = dataRow;
        }
    }
}
