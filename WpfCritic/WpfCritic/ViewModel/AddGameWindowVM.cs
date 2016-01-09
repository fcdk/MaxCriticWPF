using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class AddGameWindowVM : ViewModelBase
    {
        private EntertainmentVM _newGame = new EntertainmentVM(new Entertainment());
        ICollectionsEntity _collectionEntity;

        private EditGameUserControlVM _editGameViewModel = new EditGameUserControlVM();
        public EditGameUserControlVM EditGameViewModel
        {
            get { return _editGameViewModel; }
        }

        public AddGameWindowVM(ICollectionsEntity collectionEntity)
        {
            _collectionEntity = collectionEntity;
            _editGameViewModel.SetGame(_newGame);
        }

        internal void OkButtonClick()
        {
            _collectionEntity.Add(_newGame);
        }

    }
}
