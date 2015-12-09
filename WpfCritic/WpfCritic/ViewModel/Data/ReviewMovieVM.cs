using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.Model;

namespace WpfCritic.ViewModel.Data
{
    public class ReviewMovieVM : ViewModelBase
    {
        private Review<Movie> _review;

        public User User
        {
            get { return _review.User; }
            set { _review.User = value; OnPropertyChanged("User"); }
        }

        public Movie Movie
        {
            get { return _review.Stuff; }
            set { _review.Stuff = value; OnPropertyChanged("Movie"); }
        }

        public byte Point
        {
            get { return _review.Point; }
            set { _review.Point = value; OnPropertyChanged("Point"); }
        }

        public DateTime DateReview
        {
            get { return _review.DateReview; }
            set { _review.DateReview = value; OnPropertyChanged("DateReview"); }
        }

        public string Opinion
        {
            get { return _review.Opinion; }
            set { _review.Opinion = value; OnPropertyChanged("Opinion"); }
        }

        public ReviewMovieVM(Review<Movie> review)
        {
            _review = review;
        }

    }
}
