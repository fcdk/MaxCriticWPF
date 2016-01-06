﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.ViewModel
{
    public class AddMovieWindowVM : ViewModelBase
    {
        private Movie _newMovie = new Movie(string.Empty, 0, string.Empty, string.Empty, DateTime.Today, string.Empty, string.Empty);

        private EditMovieUserControlVM _editMovieViewModel = new EditMovieUserControlVM();
        public EditMovieUserControlVM EditMovieViewModel
        {
            get { return _editMovieViewModel; }
        }

        public AddMovieWindowVM()
        {
            _editMovieViewModel.SetMovie(_newMovie);
        }

        internal void OkButtonClick()
        {
            // тут надо как-то обновить ListBox в MainWindow!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ((AllMoviesWindow)App.Current.MainWindow).ViewModel.MovieCollection.Add(_newMovie);
        }
    }
}
