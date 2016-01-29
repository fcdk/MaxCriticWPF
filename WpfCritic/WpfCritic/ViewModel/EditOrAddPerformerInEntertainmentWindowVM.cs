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

        public EditOrAddPerformerInEntertainmentUserControlVM MovieDirectorViewModel
        {
            get { return _movieDirectorViewModel; }
        }

        internal void OkButtonClick()
        {
            _movieDirectorViewModel.Save();
        }

        public EditOrAddPerformerInEntertainmentWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;

            _movieDirectorViewModel = new EditOrAddPerformerInEntertainmentUserControlVM(entertainment, PerformerInEntertainment.Role.MovieDirector);
        }

    }
}
