using System;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EntertainmentDetailsWindowVM : ViewModelBase
    {
        private EntertainmentVM _entertainment;

        public DateTime ReleaseDate
        {
            get { return _entertainment.ReleaseDate; }
        }

        public string Company
        {
            get { return _entertainment.Company; }
        }

        public byte[] Poster
        {
            get { return _entertainment.Poster; }
        }

        public string Summary
        {
            get { return _entertainment.Summary; }
        }

        public string BuyLink
        {
            get { return _entertainment.BuyLink; }
        }

        public string MainLanguage
        {
            get { return _entertainment.MainLanguage; }
        }

        public string Rating
        {
            get { return _entertainment.Rating; }
        }

        public string RatingComment
        {
            get { return _entertainment.RatingComment;  }
        }

        public int? MovieRuntimeMinute
        {
            get { return _entertainment.MovieRuntimeMinute; }
        }

        public string OfficialSite
        {
            get { return _entertainment.OfficialSite; }
        }

        public string MovieCountries
        {
            get { return _entertainment.MovieCountries; }
        }

        public byte? TVSeason
        {
            get { return _entertainment.TVSeason; }
        }

        public decimal? Budget
        {
            get { return _entertainment.Budget; }
        }

        public string TrailerLink
        {
            get { return _entertainment.TrailerLink; }
        }

        internal void EllipseMouseLeave(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00167C"));
        }

        internal void EllipseMouseEnter(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0074FF"));
        }

        public EntertainmentDetailsWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;
        }

    }
}
