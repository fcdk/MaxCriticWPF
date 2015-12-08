using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Game g1 = new Game("Fallout 4", "Bethesda Game Studios", "https://www.fallout4.com/", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\fallout4.mp4", new DateTime(2015, 11, 10), "Bethesda Softworks", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\fallout4.png");
            _gameCollection.Add(new GameVM(g1));
            Game g2 = new Game("Call of Duty: Black Ops III", "Treyarch", "https://www.callofduty.com/blackops3", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\django.mp4", new DateTime(2015, 11, 6), "Activision", @"C:\Users\max\Documents\Visual Studio 2015\Projects\WpfCritic\WpfCritic\Assets\codblackops3.png");
            _gameCollection.Add(new GameVM(g2));
        }

        public void Add(object item)
        {
            GameVM newItem = item as GameVM;
            if (newItem != null)
                _gameCollection.Add(newItem);
        }

        internal void MoviesListBoxMouseDoubleClick()
        {
            
        }

        internal void AddButtonClick()
        {
            
        }

        internal void MenuButtonClick()
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
        }

    }
}
