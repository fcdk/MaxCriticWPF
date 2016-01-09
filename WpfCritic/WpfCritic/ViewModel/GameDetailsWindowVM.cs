using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class GameDetailsWindowVM : ViewModelBase
    {
        private EntertainmentVM _game;
        public EntertainmentVM Game
        { get { return _game; } }

        public void SetGame(EntertainmentVM game)
        {
            _game = game;
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("OfficialSite");
            OnPropertyChanged("Trailer");
            OnPropertyChanged("ReleaseDate");
            OnPropertyChanged("Company");
            OnPropertyChanged("Poster");
        }

        public string Name
        {
            get { return _game == null ? string.Empty : _game.Name; }
            set
            {
                if (_game == null)
                    return;
                _game.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string OfficialSite
        {
            get { return _game == null ? string.Empty : _game.OfficialSite; }
            set
            {
                if (_game == null)
                    return;
                _game.OfficialSite = value;
                OnPropertyChanged("OfficialSite");
            }
        }

        public string Trailer
        {
            get { return _game == null ? string.Empty : _game.TrailerLink; }
            set
            {
                if (_game == null)
                    return;
                _game.TrailerLink = value;
                OnPropertyChanged("Trailer");
            }
        }

        public DateTime? ReleaseDate
        {
            get { return _game == null ? default(DateTime?) : _game.ReleaseDate; }
            set
            {
                if (_game == null)
                    return;
                _game.ReleaseDate = (DateTime)value;
                OnPropertyChanged("ReleaseDate");
            }
        }

        public string Company
        {
            get { return _game == null ? string.Empty : _game.Company; }
            set
            {
                if (_game == null)
                    return;
                _game.Company = value;
                OnPropertyChanged("Company");
            }
        }

        public byte[] Poster
        {
            get { return _game == null ? null : _game.Poster; }
            set
            {
                if (_game == null)
                    return;
                _game.Poster = value;
                OnPropertyChanged("Poster");
            }
        }

        internal void EllipseMouseLeave(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00167C"));
        }

        internal void AddReviewClick()
        {
            //надо сделать добавление ревью
        }

        internal void EllipseMouseEnter(object sender)
        {
            ((Ellipse)sender).Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0074FF"));
        }
    }
}
