﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class GenreUserControlVM : ViewModelBase, ICollectionsEntity
    {
        private ObservableCollection<GenreVM> _genreCollection = new ObservableCollection<GenreVM>();
        private GenreVM _selectedGenre;
        private string _partOfNameForSearch;
        private string[] _genreTypes = new string[] { "Усі", "Фільм", "Гра", "Серіал", "Музика" };
        private string _selectedType = "Усі";
        private Visibility _genreTypesComboBoxVisibility;
        private Visibility _addButtonVisibility;
        private Visibility _editButtonVisibility;
        private Visibility _deleteButtonVisibility;
      
        public ObservableCollection<GenreVM> GenreCollection
        {
            get { return _genreCollection; }
        }
        public GenreVM SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
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

        public string[] GenreTypes
        {
            get { return _genreTypes; }
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
            get { return SelectedGenre != null; }
        }

        public Visibility GenreTypesComboBoxVisibility
        {
            get { return _genreTypesComboBoxVisibility; }
            set
            {
                _genreTypesComboBoxVisibility = value;
                OnPropertyChanged("GenreTypesComboBoxVisibility");
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
            GenreVM newItem = item as GenreVM;
            if (newItem != null)
                _genreCollection.Add(newItem);
        }

        internal void SearchButtonClick()
        {
            _genreCollection.Clear();

            Genre[] genres = Genre.GetByName(PartOfNameForSearch, EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(SelectedType));
            if (genres != null)
                foreach (var genre in genres)
                {
                    _genreCollection.Add(new GenreVM(genre));
                }
        }

        internal void AddButtonClick()
        {
            EditOrAddGenreWindow addOrEditGenre = new EditOrAddGenreWindow(this);
            addOrEditGenre.ShowDialog();
        }

        internal void EditButtonClick()
        {
            EditOrAddGenreWindow addOrEditGenre = new EditOrAddGenreWindow(this, SelectedGenre);
            addOrEditGenre.ShowDialog();
        }

        internal void DeleteButtonClick()
        {
            SelectedGenre.GenreDL.Delete();
            _genreCollection.Remove(SelectedGenre);

            // заново берутся все, кроме удаленного, потому что здесь есть ссылка на самого себя, срабатывает триггер при удалении
            // (см. триггер)
            List<Guid> ids = new List<Guid>();
            foreach (GenreVM genre in _genreCollection)
                ids.Add(genre.GenreDL.Id);
            _genreCollection.Clear();
            Genre[] genres = Genre.GetByIds(ids.ToArray());
            foreach (Genre genre in genres)
                _genreCollection.Add(new GenreVM(genre));
        }

        public GenreUserControlVM(Entertainment.Type? type = null)
        {
            GenreTypesComboBoxVisibility = Visibility.Visible;
            AddButtonVisibility = Visibility.Visible;
            EditButtonVisibility = Visibility.Visible;
            DeleteButtonVisibility = Visibility.Visible;

            if (type != null)
                _selectedType = EntertainmentVM.EntertainmentTypeToUkrString((Entertainment.Type)type);

            Genre[] genres = Genre.GetRandomFirstTen(type);
            if (genres != null)
                foreach (var genre in genres)
                    _genreCollection.Add(new GenreVM(genre));

            Logger.Info("GenreUserControlVM.GenreUserControlVM", "Екземпляр GenreUserControlVM створений.");
        }

    }
}
