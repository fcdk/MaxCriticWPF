using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.DataLayer;
using WpfCritic.Model;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class AllGamesWindowVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<GameVM> _gameCollection = new ObservableCollection<GameVM>();
        private GameVM _selectedGame;
        private EditGameUserControlVM _editGameViewModel = new EditGameUserControlVM();

        public EditGameUserControlVM EditGameViewModel
        {
            get { return _editGameViewModel; }
        }

        public ObservableCollection<GameVM> GameCollection
        {
            get { return _gameCollection; }
        }

        public GameVM SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                _editGameViewModel.SetGame(_selectedGame);

                OnPropertyChanged("SelectedGame");
                OnPropertyChanged("Name");
                OnPropertyChanged("Developer");
                OnPropertyChanged("OfficialSite");
                OnPropertyChanged("Trailer");
                OnPropertyChanged("ReleaseDate");
                OnPropertyChanged("Company");
                OnPropertyChanged("Poster");
            }
        }

        public string Name
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.Name; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Developer
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.Developer; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.Developer = value;
                OnPropertyChanged("Developer");
            }
        }

        public string OfficialSite
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.OfficialSite; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.Trailer; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.Trailer = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _selectedGame == null ? default(DateTime?) : _selectedGame.ReleaseDate; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.Company; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Poster
        {
            get { return _selectedGame == null ? string.Empty : _selectedGame.Poster; }
            set
            {
                if (_selectedGame == null)
                    return;
                _selectedGame.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public void LoadData()
        {
            /*Game g1 = new Game("Fallout 4", "https://www.fallout4.com/", "Bethesda Game Studios", @"C:\Users\max\Documents\Visual Studio 2015\Projects\Critic\WpfCritic\WpfCritic\Assets\fallout4.mp4", new DateTime(2015, 11, 10), "Bethesda Softworks", @"\Assets\fallout4.png");
            _gameCollection.Add(new GameVM(g1));
            Game g2 = new Game("Call of Duty: Black Ops III", "https://www.callofduty.com/blackops3", "Treyarch", @"C:\Users\max\Documents\Visual Studio 2015\Projects\Critic\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2015, 11, 6), "Activision", @"\Assets\codblackops3.jpg");
            _gameCollection.Add(new GameVM(g2));*/

            GameManager gameManager = new GameManager();
            GameDL[] gameList = gameManager.GetGames();
            foreach (var game in gameList)
            {
                GameVM gameVM = game.ToGameVM();
                _gameCollection.Add(gameVM);
            }
        }

        public void Add(object item)
        {
            GameVM newItem = item as GameVM;
            if (newItem != null)
                _gameCollection.Add(newItem);
        }

        internal void GamesListBoxMouseDoubleClick()
        {
            if (_selectedGame == null)
                return;
            else
            {
                GameDetailsWindow mG = new GameDetailsWindow();
                mG.ViewModel.SetGame(_selectedGame);
                mG.ShowDialog();
            }
        }

        internal void AddButtonClick()
        {
            AddGameWindow addGame = new AddGameWindow(new AddGameWindowVM(this));
            addGame.ShowDialog(); 
        }

        internal void MenuButtonClick()
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
        }

        internal void AllGamesWindowClosing()
        {
            GameManager gameManager = new GameManager();
            List<GameDL> games = new List<GameDL>();
            foreach (var game in _gameCollection)

                games.Add(game.ToGameDL(gameManager));
            gameManager.Save(games.ToArray());
        }

    }
}
