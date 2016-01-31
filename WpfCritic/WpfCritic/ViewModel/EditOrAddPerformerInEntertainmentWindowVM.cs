using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddPerformerInEntertainmentWindowVM : ViewModelBase
    {
        private EntertainmentVM _entertainment;
        private int _selectedTabIndex;
        private EditOrAddPerformerInEntertainmentUserControlVM _movieDirectorViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _moviePlotWriterViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _moviePrincipalCastViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _movieCastViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _movieProducerViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _movieProductionViewModel; 
        private EditOrAddPerformerInEntertainmentUserControlVM _gameCastViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _gameDeveloperCompanyViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _gamePlatformViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _tVCastViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _tVNetworkViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _albumSingerViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _albumBandViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _albumRecordLabelViewModel;

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
        }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { _selectedTabIndex = value; OnPropertyChanged("SelectedTabIndex"); }
        }

        public Visibility MovieTabItemVisibility
        {
            get
            {
                if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Movie)
                    return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public Visibility GameTabItemVisibility
        {
            get
            {
                if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Game)
                    return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public Visibility TVSeriesTabItemVisibility
        {
            get
            {
                if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.TVSeries)
                    return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public Visibility AlbumTabItemVisibility
        {
            get
            {
                if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Album)
                    return Visibility.Visible;
                else return Visibility.Collapsed;
            }
}

        public EditOrAddPerformerInEntertainmentUserControlVM MovieDirectorViewModel
        {
            get { return _movieDirectorViewModel; }
        }
                
        public EditOrAddPerformerInEntertainmentUserControlVM MoviePlotWriterViewModel
        {
            get { return _moviePlotWriterViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM MoviePrincipalCastViewModel
        {
            get { return _moviePrincipalCastViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM MovieCastViewModel
        {
            get { return _movieCastViewModel; }
        }
        
        public EditOrAddPerformerInEntertainmentUserControlVM MovieProducerViewModel
        {
            get { return _movieProducerViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM MovieProductionViewModel
        {
            get { return _movieProductionViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM GameCastViewModel
        {
            get { return _gameCastViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM GameDeveloperCompanyViewModel
        {
            get { return _gameDeveloperCompanyViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM GamePlatformViewModel
        {
            get { return _gamePlatformViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM TVCastViewModel
        {
            get { return _tVCastViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM TVNetworkViewModel
        {
            get { return _tVNetworkViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM AlbumSingerViewModel
        {
            get { return _albumSingerViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM AlbumBandViewModel
        {
            get { return _albumBandViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM AlbumRecordLabelViewModel
        {
            get { return _albumRecordLabelViewModel; }
        }

        internal void OkButtonClick()
        {
            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Movie)
            {
                _movieDirectorViewModel.Save();
                _moviePlotWriterViewModel.Save();
                _moviePrincipalCastViewModel.Save();
                _movieCastViewModel.Save();
                _movieProducerViewModel.Save();
                _movieProductionViewModel.Save();
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Game)
            {
                _gameCastViewModel.Save();
                _gameDeveloperCompanyViewModel.Save();
                _gamePlatformViewModel.Save();
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.TVSeries)
            {
                _tVCastViewModel.Save();
                _tVNetworkViewModel.Save();
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Album)
            {
                _albumSingerViewModel.Save();
                _albumBandViewModel.Save();
                _albumRecordLabelViewModel.Save();

                // обновляем авторов альбома
                _entertainment.AuthorsUpdate();
            }
        }

        public EditOrAddPerformerInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Movie)
            {
                _movieDirectorViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieDirector);
                _moviePlotWriterViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MoviePlotWriter);
                _moviePrincipalCastViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MoviePrincipalCast);
                _movieCastViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieCast);
                _movieProducerViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieProducer);
                _movieProductionViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieProduction);
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Game)
            {
                _gameCastViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.GameCast);
                _gameDeveloperCompanyViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.GameDeveloperCompany);
                _gamePlatformViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.GamePlatform);
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.TVSeries)
            {
                _tVCastViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.TVCast);
                _tVNetworkViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.TVNetwork);
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Album)
            {
                _albumSingerViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.AlbumSinger);
                _albumBandViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.AlbumBand);
                _albumRecordLabelViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.AlbumRecordLabel);
            }

            switch (_entertainment.EntertainmentType)
            {
                case DataLayer.Entertainment.Type.Album:
                    SelectedTabIndex = 11;
                    break;
                case DataLayer.Entertainment.Type.Game:
                    SelectedTabIndex = 6;
                    break;
                case DataLayer.Entertainment.Type.Movie:
                    SelectedTabIndex = 0;
                    break;
                case DataLayer.Entertainment.Type.TVSeries:
                    SelectedTabIndex = 9;
                    break;
            }

        }

    }
}
