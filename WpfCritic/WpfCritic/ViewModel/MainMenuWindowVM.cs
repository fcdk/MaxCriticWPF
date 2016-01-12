namespace WpfCritic.ViewModel
{
    public class MainMenuWindowVM : ViewModelBase
    {
        private EntertainmentUserControlVM _entertainmentViewModel = new EntertainmentUserControlVM();
        public EntertainmentUserControlVM EntertainmentViewModel
        {
            get { return _entertainmentViewModel; }
        }

    }
}
