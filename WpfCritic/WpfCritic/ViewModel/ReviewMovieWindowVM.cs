using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class ReviewMovieWindowVM : ViewModelBase
    {
        private ReviewMovieVM _review;

        public void SetReviewMovie(ReviewMovieVM review)
        {
            _review = review;
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged("User");
            OnPropertyChanged("Movie");
            OnPropertyChanged("Point");
            OnPropertyChanged("DateReview");
            OnPropertyChanged("Opinion");
        }

        public User User
        {
            get { return _review == null ? null : _review.User; }
            set
            {
                if (_review == null)
                    return;
                _review.User = value;
                OnPropertyChanged("User");
            }
        }

        public Movie Movie
        {
            get { return _review == null ? null : _review.Movie; }
            set
            {
                if (_review == null)
                    return;
                _review.Movie = value;
                OnPropertyChanged("Movie");
            }
        }

        public byte? Point
        {
            get { return _review == null ? default(byte?) : _review.Point; }
            set
            {
                if (_review == null)
                    return;
                _review.Point = (byte)value;
                OnPropertyChanged("Point");
            }
        }

        public DateTime? DateReview
        {
            get { return _review == null ? default(DateTime?) : _review.DateReview; }
            set
            {
                if (_review == null)
                    return;
                _review.DateReview = (DateTime)value;
                OnPropertyChanged("DateReview");
            }
        }

        public string Opinion
        {
            get { return _review == null ? string.Empty : _review.Opinion; }
            set
            {
                if (_review == null)
                    return;
                _review.Opinion = value;
                OnPropertyChanged("Opinion");
            }
        }

    }
}
