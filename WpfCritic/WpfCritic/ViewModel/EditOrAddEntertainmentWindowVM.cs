using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddEntertainmentWindowVM : ViewModelBase
    {
        private ICollectionsEntity _collectionEntity;
        private EntertainmentVM _enterteinment;

        private string[] _entertainmentTypes = new string[] { "Фільм", "Гра", "Серіал", "Музика" };

        //кеширование свойств Entertainment
        private string _entertainmentTypeUkr;
        private string _name;
        private DateTime? _releaseDate;
        private string _company;
        private string _poster;
        private string _summary;
        private string _buyLink;
        private string _mainLanguage;
        private string _rating;
        private string _ratingComment;
        private int? _movieRuntimeMinute;
        private string _officialSite;
        private string _movieCountries;
        private byte? _tVSeason;
        private decimal? _budget;
        public string _trailerLink = "https://www.youtube.com/watch?v=";

        public string[] EntertainmentTypes
        {
            get { return _entertainmentTypes; }
        }

        public string EntertainmentTypeUkr
        {
            get { return _entertainmentTypeUkr; }
            set { _entertainmentTypeUkr = value; OnPropertyChanged("EntertainmentTypeUkr"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; OnPropertyChanged("ReleaseDate"); }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; OnPropertyChanged("Company"); }
        }

        public string Poster
        {
            get { return _poster; }
            set { _poster = value; OnPropertyChanged("Poster"); }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("Summary"); }
        }

        public string BuyLink
        {
            get { return _buyLink; }
            set { _buyLink = value; OnPropertyChanged("BuyLink"); }
        }

        public string MainLanguage
        {
            get { return _mainLanguage; }
            set { _mainLanguage = value; OnPropertyChanged("MainLanguage"); }
        }

        public string Rating
        {
            get { return _rating; }
            set { _rating = value; OnPropertyChanged("Rating"); }
        }

        public string RatingComment
        {
            get { return _ratingComment; }
            set { _ratingComment = value; OnPropertyChanged("RatingComment"); }
        }

        public int? MovieRuntimeMinute
        {
            get { return _movieRuntimeMinute; }
            set { _movieRuntimeMinute = value; OnPropertyChanged("MovieRuntimeMinute"); }
        }

        public string OfficialSite
        {
            get { return _officialSite; }
            set { _officialSite = value; OnPropertyChanged("OfficialSite"); }
        }

        public string MovieCountries
        {
            get { return _movieCountries; }
            set { _movieCountries = value; OnPropertyChanged("MovieCountries"); }
        }

        public byte? TVSeason
        {
            get { return _tVSeason; }
            set { _tVSeason = value; OnPropertyChanged("TVSeason"); }
        }

        public decimal? Budget
        {
            get { return _budget; }
            set { _budget = value; OnPropertyChanged("Budget"); }
        }

        public string TrailerLink
        {
            get { return _trailerLink; }
            set { _trailerLink = value; OnPropertyChanged("TrailerLink"); }
        }

        public string HeaderText
        {
            get
            {
                if (_enterteinment == null)
                    return "Додавання нового контенту";
                return "Редагування контенту";
            }
        }

        public EditOrAddEntertainmentWindowVM(ICollectionsEntity collectionEntity, EntertainmentVM enterteinment = null)
        {
            _collectionEntity = collectionEntity;
            _enterteinment = enterteinment;

            if (_enterteinment != null)
            {
                EntertainmentTypeUkr = _enterteinment.EntertainmentTypeUkr;
                Name = _enterteinment.Name;
                ReleaseDate = _enterteinment.ReleaseDate;
                Company = _enterteinment.Company;
                Summary = _enterteinment.Summary;
                BuyLink = _enterteinment.BuyLink;
                MainLanguage = _enterteinment.MainLanguage;
                Rating = _enterteinment.Rating;
                RatingComment = _enterteinment.RatingComment;
                MovieRuntimeMinute = _enterteinment.MovieRuntimeMinute;
                OfficialSite = _enterteinment.OfficialSite;
                MovieCountries = _enterteinment.MovieCountries;
                TVSeason = _enterteinment.TVSeason;
                Budget = _enterteinment.Budget;
                TrailerLink = _enterteinment.TrailerLink;
            }
        }

        internal void PosterBrowseButtonClick()
        {
            OpenFileDialog posterBrowse = new OpenFileDialog();
            posterBrowse.Filter = "Файлы рисунков|*.png;*.jpg;*.bmp;*.tif;*.gif";
            if (posterBrowse.ShowDialog() == true)
                Poster = posterBrowse.FileName;
        }

        internal void OkButtonClick()
        {
            if (_enterteinment == null)
            {
                EntertainmentVM entertainment = new EntertainmentVM((Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr),
                Name, (DateTime)ReleaseDate, Company, File.ReadAllBytes(Poster), Summary, BuyLink, MainLanguage, Rating, RatingComment, MovieRuntimeMinute,
                OfficialSite, MovieCountries, TVSeason, Budget, TrailerLink);
                entertainment.EntertainmentDL.Save();
                _collectionEntity.Add(entertainment);
            }
            else
            {
                _enterteinment.EntertainmentType = (Entertainment.Type)EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr);
                _enterteinment.Name = Name;
                _enterteinment.ReleaseDate = (DateTime)ReleaseDate;
                _enterteinment.Company = Company;
                if (Poster != null)
                    _enterteinment.Poster = File.ReadAllBytes(Poster);
                _enterteinment.Summary = Summary;
                _enterteinment.BuyLink = BuyLink;
                _enterteinment.MainLanguage = MainLanguage;
                _enterteinment.Rating = Rating;
                _enterteinment.RatingComment = RatingComment;
                _enterteinment.MovieRuntimeMinute = MovieRuntimeMinute;
                _enterteinment.OfficialSite = OfficialSite;
                _enterteinment.MovieCountries = MovieCountries;
                _enterteinment.TVSeason = TVSeason;
                _enterteinment.Budget = Budget;
                _enterteinment.TrailerLink = TrailerLink;
            }
        }

    }
}
