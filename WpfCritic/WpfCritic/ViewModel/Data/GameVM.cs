using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.Model;

namespace WpfCritic.ViewModel.Data
{
    public class GameVM : ViewModelBase
    {
        private Game _game;

        public string Name
        {
            get { return _game.Name; }
            set { _game.Name = value; OnPropertyChanged("Name"); }
        }

        public string OfficialSite
        {
            get { return _game.OfficialSite; }
            set { _game.OfficialSite = value; OnPropertyChanged("OfficialSite"); }
        }

        public string Developer
        {
            get { return _game.Developer; }
            set { _game.Developer = value; OnPropertyChanged("Developer"); }
        }
        
        public string Trailer
        {
            get { return _game.Trailer; }
            set { _game.Trailer = value; OnPropertyChanged("Trailer"); }
        }

        public DateTime ReleaseDate
        {
            get { return _game.ReleaseDate; }
            set { _game.ReleaseDate = value; OnPropertyChanged("ReleaseDate"); }
        }

        public string Company
        {
            get { return _game.Company; }
            set { _game.Company = value; OnPropertyChanged("Company"); }
        }

        public string Poster
        {
            get { return _game.Poster; }
            set { _game.Poster = value; OnPropertyChanged("Poster"); }
        }

        public GameVM(Game game)
        {
            _game = game;
        }

        public override string ToString()
        {
            return Name + " (" + ReleaseDate.Year + ")";
        }

    }
}
