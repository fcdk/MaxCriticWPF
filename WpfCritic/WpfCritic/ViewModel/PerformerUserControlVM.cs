using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class PerformerUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<PerformerVM> _performerCollection = new ObservableCollection<PerformerVM>();
        private PerformerVM _selectedPerformer;
        private string _partOfNameForSearch;
        private string[] _performerTypes = new string[] { "Усі", "Музична група", "Розробник гри", "Ігрова платформа", "Продюсерська компанія", "Людина", "Лейбл", "Телевізійний канал" };
        private string _selectedType = "Усі";
        private Visibility _performerTypesComboBoxVisibility;
        private Visibility _addButtonVisibility;
        private Visibility _editButtonVisibility;
        private Visibility _deleteButtonVisibility;

        public ObservableCollection<PerformerVM> PerformerCollection
        {
            get { return _performerCollection; }
        }
        public PerformerVM SelectedPerformer
        {
            get { return _selectedPerformer; }
            set
            {
                _selectedPerformer = value;
                OnPropertyChanged("SelectedPerformer");
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

        public string[] PerformerTypes
        {
            get { return _performerTypes; }
        }

        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                OnPropertyChanged("SelectedType");
            }
        }

        public bool WhenSelectedButtonEnabled
        {
            get { return SelectedPerformer != null; }
        }

        public Visibility PerformerTypesComboBoxVisibility
        {
            get { return _performerTypesComboBoxVisibility; }
            set
            {
                _performerTypesComboBoxVisibility = value;
                OnPropertyChanged("PerformerTypesComboBoxVisibility");
            }
        }

        public Visibility AddButtonVisibility
        {
            get { return _addButtonVisibility; }
            set
            {
                _addButtonVisibility = value;
                OnPropertyChanged("AddButtonVisibility");
            }
        }

        public Visibility EditButtonVisibility
        {
            get { return _editButtonVisibility; }
            set
            {
                _editButtonVisibility = value;
                OnPropertyChanged("EditButtonVisibility");
            }
        }

        public Visibility DeleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set
            {
                _deleteButtonVisibility = value;
                OnPropertyChanged("DeleteButtonVisibility");
            }
        }

        public void Add(object item)
        {
            PerformerVM newItem = item as PerformerVM;
            if (newItem != null)
                _performerCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _performerCollection.Clear();

            Performer[] performers = Performer.GetByName(PartOfNameForSearch, PerformerVM.PerformerTypeUkrStringToEngEnum(SelectedType));
            if (performers != null)
                foreach (var performer in performers)
                {
                    _performerCollection.Add(new PerformerVM(performer));
                }
        }

        internal void PerformersListBoxMouseDoubleClick()
        {
            if (_selectedPerformer == null)
                return;
            else
            {
                PerformerDetailsWindow performerDetailsWindow = new PerformerDetailsWindow(_selectedPerformer);
                performerDetailsWindow.ShowDialog();
            }
        }

        internal void AddButtonClick()
        {
            //EditOrAddGenreWindow addOrEditGenre = new EditOrAddGenreWindow(this);
            //addOrEditGenre.ShowDialog();
        }

        internal void EditButtonClick()
        {
            //EditOrAddGenreWindow addOrEditGenre = new EditOrAddGenreWindow(this, SelectedPerformer);
            //addOrEditGenre.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedPerformer.PerformerDL.Delete();
            _performerCollection.Remove(SelectedPerformer);
        }

        public PerformerUserControlVM(Performer.Type? type = null)
        {
            PerformerTypesComboBoxVisibility = Visibility.Visible;
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Visible;
            DeleteButtonVisibility = Visibility.Visible;

            if (type != null)
                _selectedType = PerformerVM.PerformerTypeToUkrString((Performer.Type)type);

            Performer[] performers = Performer.GetRandomFirstTen(type);
            if (performers != null)
                foreach (var performer in performers)
                    _performerCollection.Add(new PerformerVM(performer));
        }

    }
}
