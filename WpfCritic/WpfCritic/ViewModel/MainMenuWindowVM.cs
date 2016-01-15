namespace WpfCritic.ViewModel
{
    public class MainMenuWindowVM : ViewModelBase
    {
        private EntertainmentUserControlVM _entertainmentViewModel = new EntertainmentUserControlVM();
        private SongUserControlVM _songViewModel = new SongUserControlVM();

        public EntertainmentUserControlVM EntertainmentViewModel
        {
            get { return _entertainmentViewModel; }
        }

        public SongUserControlVM SongViewModel
        {
            get { return _songViewModel; }
        }
    }
}
