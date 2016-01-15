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

        private bool _isError;
        private Visibility _nameErrorVisibility;
        private Visibility _posterErrorVisibility;
        private Visibility _releaseDateErrorVisibility;
        private Visibility _companyErrorVisibility;
        private Visibility _mainLanguageErrorVisibility;
        private Visibility _summaryErrorVisibility;
        private Visibility _movieRuntimeMinuteErrorVisibility;
        private Visibility _trailerLinkErrorVisibility;

        //кеширование свойств Entertainment
        private string _entertainmentTypeUkr = "Фільм";
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
        public string _trailerLink;

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

        public Visibility MovieRuntimeMinuteVisibility
        {
            get
            {
                if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.Movie)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility TVSeasonVisibility
        {
            get
            {
                if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.TVSeries)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility MovieCountriesVisibility
        {
            get
            {
                if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.Movie)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility TrailerLinkVisibility
        {
            get
            {
                if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) != Entertainment.Type.Album)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility NameErrorVisibility
        {
            get { return _nameErrorVisibility; }
            set
            {
                _nameErrorVisibility = value;
                OnPropertyChanged("NameErrorVisibility");
            }
        }

        public Visibility PosterErrorVisibility
        {
            get { return _posterErrorVisibility; }
            set
            {
                _posterErrorVisibility = value;
                OnPropertyChanged("PosterErrorVisibility");
            }
        }

        public Visibility ReleaseDateErrorVisibility
        {
            get { return _releaseDateErrorVisibility; }
            set
            {
                _releaseDateErrorVisibility = value;
                OnPropertyChanged("ReleaseDateErrorVisibility");
            }
        }

        public Visibility CompanyErrorVisibility
        {
            get { return _companyErrorVisibility; }
            set
            {
                _companyErrorVisibility = value;
                OnPropertyChanged("CompanyErrorVisibility");
            }
        }
        public Visibility MainLanguageErrorVisibility
        {
            get { return _mainLanguageErrorVisibility; }
            set
            {
                _mainLanguageErrorVisibility = value;
                OnPropertyChanged("MainLanguageErrorVisibility");
            }
        }

        public Visibility SummaryErrorVisibility
        {
            get { return _summaryErrorVisibility; }
            set
            {
                _summaryErrorVisibility = value;
                OnPropertyChanged("SummaryErrorVisibility");
            }
        }

        public Visibility MovieRuntimeMinuteErrorVisibility
        {
            get { return _movieRuntimeMinuteErrorVisibility; }
            set
            {
                _movieRuntimeMinuteErrorVisibility = value;
                OnPropertyChanged("MovieRuntimeMinuteErrorVisibility");
            }
        }

        public Visibility TrailerLinkErrorVisibility
        {
            get { return _trailerLinkErrorVisibility; }
            set
            {
                _trailerLinkErrorVisibility = value;
                OnPropertyChanged("TrailerLinkErrorVisibility");
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

            NameErrorVisibility = Visibility.Hidden;
            PosterErrorVisibility = Visibility.Hidden;
            ReleaseDateErrorVisibility = Visibility.Hidden;
            CompanyErrorVisibility = Visibility.Hidden;
            MainLanguageErrorVisibility = Visibility.Hidden;
            SummaryErrorVisibility = Visibility.Hidden;
            if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) != Entertainment.Type.Movie)
                MovieRuntimeMinuteErrorVisibility = Visibility.Collapsed;
            else MovieRuntimeMinuteErrorVisibility = Visibility.Hidden;
            if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.Album)
                TrailerLinkErrorVisibility = Visibility.Collapsed;
            else TrailerLinkErrorVisibility = Visibility.Hidden;
        }

        internal void entertainmentTypeUkrComboBoxSelectionChanged()
        {
            OnPropertyChanged("MovieRuntimeMinuteVisibility");
            OnPropertyChanged("TVSeasonVisibility");
            OnPropertyChanged("TrailerLinkVisibility");
            OnPropertyChanged("MovieCountriesVisibility");
            if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) != Entertainment.Type.Movie)
                MovieRuntimeMinuteErrorVisibility = Visibility.Collapsed;
            if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.Album)
                TrailerLinkErrorVisibility = Visibility.Collapsed;
        }

        internal void PosterBrowseButtonClick()
        {
            OpenFileDialog posterBrowse = new OpenFileDialog();
            posterBrowse.Filter = "Файлы рисунков|*.png;*.jpg;*.bmp;*.tif;*.gif";
            if (posterBrowse.ShowDialog() == true)
                Poster = posterBrowse.FileName;
        }

        internal bool OkButtonClick()
        {
            _isError = false;

            if (Name == null || Name == String.Empty)
            {
                NameErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else NameErrorVisibility = Visibility.Hidden;


            if (_enterteinment == null && (Poster == null || Poster == String.Empty))
            {
                PosterErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else PosterErrorVisibility = Visibility.Hidden;

            if (ReleaseDate == null)
            {
                ReleaseDateErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else ReleaseDateErrorVisibility = Visibility.Hidden;

            if (Company == null || Company == String.Empty)
            {
                CompanyErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else CompanyErrorVisibility = Visibility.Hidden;

            if (MainLanguage == null || MainLanguage == String.Empty)
            {
                MainLanguageErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else MainLanguageErrorVisibility = Visibility.Hidden;

            if (Summary == null || Summary == String.Empty)
            {
                SummaryErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else SummaryErrorVisibility = Visibility.Hidden;
                        
            if (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr) == Entertainment.Type.Movie &&
            MovieRuntimeMinute == null)
            {
                MovieRuntimeMinuteErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else MovieRuntimeMinuteErrorVisibility = Visibility.Collapsed;
                        
            if (TrailerLink.Replace("https://www.youtube.com/watch?v=","").Contains(" "))
            {
                TrailerLinkErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else TrailerLinkErrorVisibility = Visibility.Collapsed;

            if (TrailerLink == "https://www.youtube.com/watch?v=")
                TrailerLink = null;

            if (_isError)
                return false;

            switch (EntertainmentVM.EntertainmentTypeUkrStringToEngEnum(EntertainmentTypeUkr))
            {
                case Entertainment.Type.Album:
                    MovieRuntimeMinute = null;
                    MovieCountries = null;
                    TVSeason = null;
                    TrailerLink = null;
                    break;
                case Entertainment.Type.Game:
                    MovieRuntimeMinute = null;
                    MovieCountries = null;
                    TVSeason = null;
                    break;
                case Entertainment.Type.Movie:
                    TVSeason = null;
                    break;
                case Entertainment.Type.TVSeries:
                    MovieRuntimeMinute = null;
                    MovieCountries = null;
                    break;
            }

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

                _enterteinment.EntertainmentDL.Save();
            }
            return true;
        }

    }
}
