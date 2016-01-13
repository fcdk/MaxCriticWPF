using Microsoft.Win32;

namespace WpfCritic.ViewModel
{
    public class EditOrAddEntertainmentWindowVM : ViewModelBase
    {
        ICollectionsEntity _collectionEntity;

        private EditGameUserControlVM _editGameViewModel = new EditGameUserControlVM();
        public EditGameUserControlVM EditGameViewModel
        {
            get { return _editGameViewModel; }
        }

        public EditOrAddEntertainmentWindowVM(ICollectionsEntity collectionEntity)
        {
            _collectionEntity = collectionEntity;
            //_editGameViewModel.SetGame(_newGame);
        }

        internal void OkButtonClick()
        {
            //_collectionEntity.Add(_newGame);
        }

        internal void TrailerBrowseButtonClick()
        {
            OpenFileDialog trailerBrowse = new OpenFileDialog();
            trailerBrowse.Filter = "Файлы видео|*.mp4;*.avi;*.mkv;*.wmv";
            //if (trailerBrowse.ShowDialog() == true)
                //Trailer = trailerBrowse.FileName;
        }

        internal void PosterBrowseButtonClick()
        {
            OpenFileDialog posterBrowse = new OpenFileDialog();
            posterBrowse.Filter = "Файлы рисунков|*.png;*.jpg;*.bmp;*.tif;*.gif";
            //if (posterBrowse.ShowDialog() == true)
            //Poster = posterBrowse.FileName;
        }
    }
}
