using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddPerformerInEntertainmentUserControlVM : ViewModelBase
    {
        private PerformerUserControlVM _performerViewModel;
        private EntertainmentVM _entertainment;
        private PerformerInEntertainment.Role _role;
        private ObservableCollection<PerformerVM> _addedPerformerCollection = new ObservableCollection<PerformerVM>();
        private PerformerVM _addedSelectedPerformer;
        List<PerformerInEntertainmentVM> _performerInEntertainmentCollection = new List<PerformerInEntertainmentVM>();
        List<PerformerVM> _deletedPerformerCollection = new List<PerformerVM>();

        public PerformerUserControlVM PerformerViewModel
        {
            get { return _performerViewModel; }
        }

        public ObservableCollection<PerformerVM> AddedPerformerCollection
        {
            get { return _addedPerformerCollection; }
        }

        public PerformerVM AddedSelectedPerformer
        {
            get { return _addedSelectedPerformer; }
            set
            {
                _addedSelectedPerformer = value;
                OnPropertyChanged("AddedSelectedPerformer");
                OnPropertyChanged("WhenSelectedButtonEnabled");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return AddedSelectedPerformer != null; }
        }

        public string AddedListHeader
        {
            get
            {
                switch (_role)
                {
                    case PerformerInEntertainment.Role.AlbumBand:
                        return "Музичні групи";
                    case PerformerInEntertainment.Role.AlbumRecordLabel:
                        return "Лейбли";
                    case PerformerInEntertainment.Role.AlbumSinger:
                        return "Співаки";
                    case PerformerInEntertainment.Role.GameCast:
                        return "Актори";
                    case PerformerInEntertainment.Role.GameDeveloperCompany:
                        return "Компанії-розробники";
                    case PerformerInEntertainment.Role.GamePlatform:
                        return "Ігрові платформи";
                    case PerformerInEntertainment.Role.MovieCast:
                        return "Актори";
                    case PerformerInEntertainment.Role.MovieDirector:
                        return "Режисери";
                    case PerformerInEntertainment.Role.MoviePlotWriter:
                        return "Автори сюжету";
                    case PerformerInEntertainment.Role.MoviePrincipalCast:
                        return "Головні герої (актори)";
                    case PerformerInEntertainment.Role.MovieProducer:
                        return "Продюсери";
                    case PerformerInEntertainment.Role.MovieProduction:
                        return "Компанії-виробники";
                    case PerformerInEntertainment.Role.TVCast:
                        return "Актори";
                    case PerformerInEntertainment.Role.TVNetwork:
                        return "Телевізійні канали";
                    default:
                        return null;
                }
            }
        }

        internal void AddButtonClick()
        {
            foreach (PerformerVM performer in _addedPerformerCollection)
                if (PerformerVM.Comparison(performer, PerformerViewModel.SelectedPerformer))
                    return;
            for (int i = 0; i < _deletedPerformerCollection.Count; i++)
                if (PerformerVM.Comparison(_deletedPerformerCollection[i], PerformerViewModel.SelectedPerformer))
                {
                    _deletedPerformerCollection.Remove(_deletedPerformerCollection[i]);
                    break;
                }
            _addedPerformerCollection.Add(PerformerViewModel.SelectedPerformer);
        }

        internal void DeleteButtonClick()
        {
            foreach (PerformerInEntertainmentVM performerInEntertainment in _performerInEntertainmentCollection)
                if (performerInEntertainment.PerformerComparison(AddedSelectedPerformer))
                {
                    _deletedPerformerCollection.Add(AddedSelectedPerformer);
                    break;
                }
            for (int i = 0; i < _addedPerformerCollection.Count; i++)
                if (PerformerVM.Comparison(_addedPerformerCollection[i], AddedSelectedPerformer))
                {
                    _addedPerformerCollection.Remove(_addedPerformerCollection[i]);
                    break;
                }
        }

        public void Save()
        {
            bool IsNew;

            foreach (PerformerVM performer in _addedPerformerCollection)
            {
                IsNew = true;
                foreach (PerformerInEntertainmentVM performerInEntertainment in _performerInEntertainmentCollection)
                    if (performerInEntertainment.PerformerComparison(performer))
                    {
                        IsNew = false;
                        break;
                    }
                if (IsNew)
                    (new PerformerInEntertainmentVM(performer, _entertainment, _role)).PerformerInEntertainmentDL.Save();
            }
            foreach (PerformerVM performer in _deletedPerformerCollection)
                for (int i = 0; i < _performerInEntertainmentCollection.Count; i++)
                    if (_performerInEntertainmentCollection[i].PerformerComparison(performer))
                    {
                        _performerInEntertainmentCollection[i].PerformerInEntertainmentDL.Delete();
                        _performerInEntertainmentCollection.Remove(_performerInEntertainmentCollection[i]);
                        break;
                    }
        }

        public EditOrAddPerformerInEntertainmentUserControlVM(EntertainmentVM entertainment, PerformerInEntertainment.Role role)
        {
            _entertainment = entertainment;
            _role = role;

            Performer.Type type;
            switch (role)
            {
                case PerformerInEntertainment.Role.AlbumBand:
                    type = Performer.Type.Band;
                    break;
                case PerformerInEntertainment.Role.AlbumRecordLabel:
                    type = Performer.Type.RecordLabel;
                    break;
                case PerformerInEntertainment.Role.AlbumSinger:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.GameCast:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.GameDeveloperCompany:
                    type = Performer.Type.GameDeveloperCompany;
                    break;
                case PerformerInEntertainment.Role.GamePlatform:
                    type = Performer.Type.GamePlatform;
                    break;
                case PerformerInEntertainment.Role.MovieCast:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.MovieDirector:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.MoviePlotWriter:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.MoviePrincipalCast:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.MovieProducer:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.MovieProduction:
                    type = Performer.Type.MovieProduction;
                    break;
                case PerformerInEntertainment.Role.TVCast:
                    type = Performer.Type.Person;
                    break;
                case PerformerInEntertainment.Role.TVNetwork:
                    type = Performer.Type.TVNetwork;
                    break;
                default:
                    type = Performer.Type.Person;
                    break;
            }

            _performerViewModel = new PerformerUserControlVM(type);

            _performerViewModel.PerformerTypesComboBoxVisibility = Visibility.Collapsed;
            _performerViewModel.AddButtonVisibility = Visibility.Collapsed;
            _performerViewModel.EditButtonVisibility = Visibility.Collapsed;
            _performerViewModel.DeleteButtonVisibility = Visibility.Collapsed;

            PerformerInEntertainment[] performerInEntertainments = PerformerInEntertainment.GetPerformerInEntertainmentByEntertainmentAndRole(_entertainment.EntertainmentDL, role);

            if (performerInEntertainments != null)
            {
                List<Guid> performerIds = new List<Guid>();

                foreach (var performerInEntertainment in performerInEntertainments)
                {
                    _performerInEntertainmentCollection.Add(new PerformerInEntertainmentVM(performerInEntertainment));
                    performerIds.Add(performerInEntertainment.PerformerId);
                }

                Performer[] performers = Performer.GetByIds(performerIds.ToArray());
                foreach (var performer in performers)
                    _addedPerformerCollection.Add(new PerformerVM(performer));
            }
        }

    }
}
