namespace WpfCritic.ViewModel
{
    public class MainMenuWindowVM : ViewModelBase
    {
        private EntertainmentUserControlVM _entertainmentViewModel = new EntertainmentUserControlVM();
        private SongUserControlVM _songViewModel = new SongUserControlVM();
        private GenreUserControlVM _genreViewModel = new GenreUserControlVM();
        private PerformerUserControlVM _performerViewModel = new PerformerUserControlVM();
        private AwardUserControlVM _awardViewModel = new AwardUserControlVM();

        public EntertainmentUserControlVM EntertainmentViewModel
        {
            get { return _entertainmentViewModel; }
        }

        public SongUserControlVM SongViewModel
        {
            get { return _songViewModel; }
        }

        public GenreUserControlVM GenreViewModel
        {
            get { return _genreViewModel; }
        }

        public PerformerUserControlVM PerformerViewModel
        {
            get { return _performerViewModel; }
        }

        public AwardUserControlVM AwardViewModel
        {
            get { return _awardViewModel; }
        }

    }
}
