using System;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddPerformerInEntertainmentWindowVM : ViewModelBase
    {
        private EntertainmentVM _entertainment;
        private EditOrAddPerformerInEntertainmentUserControlVM _movieDirectorViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _moviePlotWriterViewModel;
        private EditOrAddPerformerInEntertainmentUserControlVM _gameCastViewModel;

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
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

        public EditOrAddPerformerInEntertainmentUserControlVM MovieDirectorViewModel
        {
            get { return _movieDirectorViewModel; }
        }
                
        public EditOrAddPerformerInEntertainmentUserControlVM MoviePlotWriterViewModel
        {
            get { return _moviePlotWriterViewModel; }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM GameCastViewModel
        {
            get { return _gameCastViewModel; }
        }

        internal void OkButtonClick()
        {
            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Movie)
            {
                _movieDirectorViewModel.Save();
                _moviePlotWriterViewModel.Save();
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Game)
            {
                _gameCastViewModel.Save();
            }
        }

        public EditOrAddPerformerInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Movie)
            {
                _movieDirectorViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieDirector);
                _moviePlotWriterViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MoviePlotWriter);
            }

            if (_entertainment.EntertainmentType == DataLayer.Entertainment.Type.Game)
            {
                _gameCastViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.GameCast);
            }

        }

    }
}
