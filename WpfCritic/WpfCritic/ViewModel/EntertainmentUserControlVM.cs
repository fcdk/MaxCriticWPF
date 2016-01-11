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
        private Entertainment.Type _entertainmentType;

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
        public string EntertainmentType
        {
            get
            {
                if (_entertainmentType == Entertainment.Type.Album)
                    return "Музика";
                if (_entertainmentType == Entertainment.Type.Game)
                    return "Ігри";
                if (_entertainmentType == Entertainment.Type.Movie)
                    return "Фільми";
                if (_entertainmentType == Entertainment.Type.TVSeries)
                    return "Серіали";
                return null;
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
            _entertainmentType = type;
            Entertainment[] entertainments = Entertainment.GetRandomFirstTen(type);
            if (entertainments != null)
                foreach (var entert in entertainments)
                {
                    _entertainmentCollection.Add(new EntertainmentVM(entert));
                }
        }

    }
}
