using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel
{
    public class MainMenuWindowVM : ViewModelBase
    {
        private EntertainmentUserControlVM _movieViewModel = new EntertainmentUserControlVM(Entertainment.Type.Movie);
        private EntertainmentUserControlVM _gameViewModel = new EntertainmentUserControlVM(Entertainment.Type.Game);
        private EntertainmentUserControlVM _tvViewModel = new EntertainmentUserControlVM(Entertainment.Type.TVSeries);
        private EntertainmentUserControlVM _albumViewModel = new EntertainmentUserControlVM(Entertainment.Type.Album);
        public EntertainmentUserControlVM MovieViewModel
        {
            get { return _movieViewModel; }
        }
        public EntertainmentUserControlVM GameViewModel
        {
            get { return _gameViewModel; }
        }
        public EntertainmentUserControlVM TVViewModel
        {
            get { return _tvViewModel; }
        }
        public EntertainmentUserControlVM AlbumViewModel
        {
            get { return _albumViewModel; }
        }

    }
}
