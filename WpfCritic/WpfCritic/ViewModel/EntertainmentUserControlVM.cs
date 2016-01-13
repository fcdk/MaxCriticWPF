﻿using System.Collections.ObjectModel;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EntertainmentUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<EntertainmentVM> _entertainmentCollection = new ObservableCollection<EntertainmentVM>();
        private EntertainmentVM _selectedEntertainment;
        private string[] _entertainmentTypes = new string[] { "Усі", "Фільм", "Гра", "Серіал", "Музика" };
        private string _selectedType = "Усі";
        private string _partOfNameForSearch;

        public ObservableCollection<EntertainmentVM> EntertainmentCollection
        {
            get { return _entertainmentCollection; }
        }
        public EntertainmentVM SelectedEntertainment
        {
            get { return _selectedEntertainment; }
            set
            {
                _selectedEntertainment = value;
                OnPropertyChanged("SelectedEntertainment");
            }
        }

        public string[] EntertainmentTypes
        {
            get { return _entertainmentTypes; }
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

        public string PartOfNameForSearch
        {
            get { return _partOfNameForSearch == null ? string.Empty : _partOfNameForSearch; }
            set
            {
                _partOfNameForSearch = value;
                OnPropertyChanged("PartOfNameForSearch"); 
            }
        }

        public void Add(object item)
        {
            EntertainmentVM newItem = item as EntertainmentVM;
            if (newItem != null)
                _entertainmentCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _entertainmentCollection.Clear();

            Entertainment[] entertainments = Entertainment.GetByName(PartOfNameForSearch, EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(SelectedType));
            if (entertainments != null)
                foreach (var entert in entertainments)
                {
                    _entertainmentCollection.Add(new EntertainmentVM(entert));
                }
        }

        internal void EntertainmentsListBoxMouseDoubleClick()
        {
            if (_selectedEntertainment == null)
                return;
            else
            {
                EntertainmentDetailsWindow entertainmentDetailsWindow = new EntertainmentDetailsWindow(_selectedEntertainment);
                entertainmentDetailsWindow.ShowDialog();
            }
        }

        internal void AddButtonClick()
        {
            EditOrAddEntertainmentWindow addGame = new EditOrAddEntertainmentWindow(new EditOrAddEntertainmentWindowVM(this));
            addGame.ShowDialog(); 
        }

        internal void deleteButtonClick()
        {
            SelectedEntertainment.EntertainmentDL.Delete();
            _entertainmentCollection.Remove(SelectedEntertainment);
        }

        public EntertainmentUserControlVM()
        {
            Entertainment[] entertainments = Entertainment.GetRandomFirstTen();
            if (entertainments != null)
                foreach (var entert in entertainments)
                {
                    _entertainmentCollection.Add(new EntertainmentVM(entert));
                }
        }

    }
}
