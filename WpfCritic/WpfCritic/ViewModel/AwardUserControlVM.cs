using System.Collections.ObjectModel;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class AwardUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<AwardVM> _awardCollection = new ObservableCollection<AwardVM>();
        private AwardVM _selectedAward;
        private string _partOfNameForSearch;

        public ObservableCollection<AwardVM> AwardCollection
        {
            get { return _awardCollection; }
        }
        public AwardVM SelectedAward
        {
            get { return _selectedAward; }
            set
            {
                _selectedAward = value;
                OnPropertyChanged("SelectedAward");
                OnPropertyChanged("WhenSelectedButtonEnabled");
            }
        }

        public string PartOfNameForSearch
        {
            get { return _partOfNameForSearch == null ? string.Empty : _partOfNameForSearch; }
            set
            {
                _partOfNameForSearch = value;
                OnPropertyChanged("PartOfNameForSearch");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return SelectedAward != null; }
        }

        public void Add(object item)
        {
            AwardVM newItem = item as AwardVM;
            if (newItem != null)
                _awardCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _awardCollection.Clear();

            Award[] awards = Award.GetByName(PartOfNameForSearch);
            if (awards != null)
                foreach (var award in awards)
                {
                    _awardCollection.Add(new AwardVM(award));
                }
        }

        internal void AddButtonClick()
        {
            EditOrAddAwardWindow addOrEditAward = new EditOrAddAwardWindow(this);
            addOrEditAward.ShowDialog();
        }

        internal void EditButtonClick()
        {
            EditOrAddAwardWindow addOrEditAward = new EditOrAddAwardWindow(this, SelectedAward);
            addOrEditAward.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedAward.AwardDL.Delete();
            _awardCollection.Remove(SelectedAward);
        }

        public AwardUserControlVM()
        {
            Award[] awards = Award.GetRandomFirstTen();
            if (awards != null)
                foreach (var award in awards)
                    _awardCollection.Add(new AwardVM(award));

            Logger.Info("AwardUserControlVM.AwardUserControlVM", "Екземпляр AwardUserControlVM створений.");
        }

    }
}
