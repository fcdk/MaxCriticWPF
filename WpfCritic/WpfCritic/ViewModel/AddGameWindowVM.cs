using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.Model;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class AddGameWindowVM : ViewModelBase
    {
        private GameVM _newGame = new GameVM(new Game());
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
