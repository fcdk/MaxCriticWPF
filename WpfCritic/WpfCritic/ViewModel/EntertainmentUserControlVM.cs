using System.Collections.ObjectModel;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EntertainmentUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<EntertainmentVM> _entertainmentCollection = new ObservableCollection<EntertainmentVM>();
        private EntertainmentVM _selectedEntertainment;

        public ObservableCollection<EntertainmentVM> EntertainmentCollection
        {
            get { return _entertainmentCollection; }
        }
        public EntertainmentVM SelectedEntertainment
        {
            get { return _selectedEntertainment; }
            set
            {
                _selectedEntertainment = value;
                OnPropertyChanged("SelectedEntertainment");
            }
        }

        private void LoadData()
        {
            foreach (var entert in Entertainment.GetRandomFirstTen())
            {
                _entertainmentCollection.Add(new EntertainmentVM(entert));
            }
        }

        public void Add(object item)
        {
            EntertainmentVM newItem = item as EntertainmentVM;
            if (newItem != null)
                _entertainmentCollection.Add(newItem);
        }

        internal void EntertainmentsListBoxMouseDoubleClick()
        {
            if (_selectedEntertainment == null)
                return;
            else
            {
                GameDetailsWindow mG = new GameDetailsWindow();
                mG.ViewModel.SetGame(_selectedEntertainment);
                mG.ShowDialog();
            }
        }

        internal void AddButtonClick()
        {
            AddGameWindow addGame = new AddGameWindow(new AddGameWindowVM(this));
            addGame.ShowDialog(); 
        }

        internal void AllGamesWindowClosing()
        {
            //GameManager gameManager = new GameManager();
            //List<Game> games = new List<Game>();
            //foreach (var game in _entertainmentCollection)
                //games.Add(game.ToGameDL(gameManager));
            //gameManager.Save(games.ToArray());
        }

        public EntertainmentUserControlVM(Entertainment.Type type)
        {
            LoadData();
        }

    }
}
