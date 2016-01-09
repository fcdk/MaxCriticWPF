using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class AllGamesWindowVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<EntertainmentVM> _entertainmentCollection = new ObservableCollection<EntertainmentVM>();
        private EntertainmentVM _selectedEntertainment;
        private EditGameUserControlVM _editGameViewModel = new EditGameUserControlVM();

        public EditGameUserControlVM EditGameViewModel
        {
            get { return _editGameViewModel; }
        }

        public ObservableCollection<EntertainmentVM> GameCollection
        {
            get { return _entertainmentCollection; }
        }

        public EntertainmentVM SelectedGame
        {
            get { return _selectedEntertainment; }
            set
            {
                _selectedEntertainment = value;
                _editGameViewModel.SetGame(_selectedEntertainment);

                OnPropertyChanged("SelectedGame");
                OnPropertyChanged("Name");
                OnPropertyChanged("OfficialSite");
                OnPropertyChanged("Trailer");
                OnPropertyChanged("ReleaseDate");
                OnPropertyChanged("Company");
                OnPropertyChanged("Poster");
            }
        } 

        public string Name
        {
            get { return _selectedEntertainment == null ? string.Empty : _selectedEntertainment.Name; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string OfficialSite
        {
            get { return _selectedEntertainment == null ? string.Empty : _selectedEntertainment.OfficialSite; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _selectedEntertainment == null ? string.Empty : _selectedEntertainment.TrailerLink; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.TrailerLink = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _selectedEntertainment == null ? default(DateTime?) : _selectedEntertainment.ReleaseDate; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _selectedEntertainment == null ? string.Empty : _selectedEntertainment.Company; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public byte[] Poster
        {
            get { return _selectedEntertainment == null ? null : _selectedEntertainment.Poster; }
            set
            {
                if (_selectedEntertainment == null)
                    return;
                _selectedEntertainment.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public void LoadData()
        {
            foreach (var entert in Entertainment.GetRandomFirstTen())
            {
                _entertainmentCollection.Add(new EntertainmentVM(entert));
            }

            Logger.Info("AllGamesWindowVM.LoadData", "Коллекция фильмов заполнена");
        }

        public void Add(object item)
        {
            EntertainmentVM newItem = item as EntertainmentVM;
            if (newItem != null)
                _entertainmentCollection.Add(newItem);
        }

        internal void GamesListBoxMouseDoubleClick()
        {
            if (_selectedEntertainment == null)
                return;
            else
            {
                GameDetailsWindow mG = new GameDetailsWindow();
                //mG.ViewModel.SetGame(_selectedEntertainment);
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
            List<Game> games = new List<Game>();
            //foreach (var game in _entertainmentCollection)
                //games.Add(game.ToGameDL(gameManager));
            //gameManager.Save(games.ToArray());
        }

    }
}
