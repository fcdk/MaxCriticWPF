using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using WpfCritic.Core;
using WpfCritic.View;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EntertainmentDetailsWindowVM : ViewModelBase
    {
        private EntertainmentVM _entertainment;

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
        }

        public string ReleaseDate
        {
            get { return _entertainment.ReleaseDate.ToShortDateString(); }
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

        public Visibility BuyLinkVisibility
        {
            get
            {
                if (_entertainment.BuyLink == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility RatingVisibility
        {
            get
            {
                if (_entertainment.Rating == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility RatingCommentVisibility
        {
            get
            {
                if (_entertainment.RatingComment == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility MovieRuntimeMinuteVisibility
        {
            get
            {
                if (_entertainment.MovieRuntimeMinute == null)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility OfficialSiteVisibility
        {
            get
            {
                if (_entertainment.OfficialSite == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility MovieCountriesVisibility
        {
            get
            {
                if (_entertainment.MovieCountries == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility TVSeasonVisibility
        {
            get
            {
                if (_entertainment.TVSeason == null)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility BudgetVisibility
        {
            get
            {
                if (_entertainment.Budget == null)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        public Visibility TrailerVisibility
        {
            get
            {
                if (_entertainment.TrailerLink == String.Empty)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }

        internal void RequestNavigate(RequestNavigateEventArgs e)
        {
            if (e.Uri.ToString() != String.Empty)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                    e.Handled = true;
                }
                catch { MessageBox.Show("Невірне посилання!"); }
            }
        }

        internal void WindowClosing(object sender)
        {
            ((EntertainmentDetailsWindow)sender).YoutubeVideo.Source = new Uri("about:blank");
        }

        public EntertainmentDetailsWindowVM(EntertainmentVM entertainment)
        {
            _entertainment = entertainment;

            Logger.Info("EntertainmentDetailsWindowVM.EntertainmentDetailsWindowVM", "Екземпляр EntertainmentDetailsWindowVM створений.");
        }

    }
}
