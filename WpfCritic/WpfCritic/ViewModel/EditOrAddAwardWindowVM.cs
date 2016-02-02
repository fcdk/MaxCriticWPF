using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddAwardWindowVM : ViewModelBase
    {
        private ICollectionsEntity _collectionEntity;
        private AwardVM _award;

        private string _partOfNamePerformer;
        private string _partOfNameEntertainment;

        private bool _isError;
        private bool _clearImage = false;
        private Visibility _nameErrorVisibility;
        private Visibility _dateErrorVisibility;
        private Visibility _imageClearButtonVisibility;

        //кеширование свойств Award
        private PerformerVM _performer;
        private EntertainmentVM _entertainment;
        private string _name;
        private string _nomination;
        private DateTime? _date;
        private string _image;

        public string PartOfNamePerformer
        {
            get { return _partOfNamePerformer; }
            set
            {
                _partOfNamePerformer = value;
                OnPropertyChanged("PartOfNamePerformer");
                OnPropertyChanged("PerformersPick");
            }
        }

        public PerformerVM[] PerformersPick
        {
            get
            {
                if (PartOfNamePerformer == null)
                    return null;
                if (PartOfNamePerformer.Length < 3)
                    return null;

                Performer[] performers = DataLayer.Performer.GetForAutoCompleteBox(PartOfNamePerformer);

                if (performers == null)
                    return null;

                List<PerformerVM> result = new List<PerformerVM>();
                foreach (Performer performer in performers)
                    result.Add(new PerformerVM(performer));
                return result.ToArray();
            }
        }

        public string PartOfNameEntertainment
        {
            get { return _partOfNameEntertainment; }
            set
            {
                _partOfNameEntertainment = value;
                OnPropertyChanged("PartOfNameEntertainment");
                OnPropertyChanged("EntertainmentsPick");
            }
        }

        public EntertainmentVM[] EntertainmentsPick
        {
            get
            {
                if (PartOfNameEntertainment == null)
                    return null;
                if (PartOfNameEntertainment.Length < 3)
                    return null;

                Entertainment[] entertainments = DataLayer.Entertainment.GetForAutoCompleteBox(PartOfNameEntertainment);

                if (entertainments == null)
                    return null;

                List<EntertainmentVM> result = new List<EntertainmentVM>();
                foreach (Entertainment entertainment in entertainments)
                    result.Add(new EntertainmentVM(entertainment));
                return result.ToArray();
            }
        }

        public PerformerVM Performer
        {
            get { return _performer; }
            set { _performer = value; OnPropertyChanged("Performer"); }
        }

        public EntertainmentVM Entertainment
        {
            get { return _entertainment; }
            set { _entertainment = value; OnPropertyChanged("Entertainment"); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Nomination
        {
            get { return _nomination; }
            set { _nomination = value; OnPropertyChanged("Nomination"); }
        }

        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged("Date"); }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged("Image"); }
        }

        public string HeaderText
        {
            get
            {
                if (_award == null)
                    return "Додавання нової нагороди";
                return "Редагування нагороди";
            }
        }

        public Visibility NameErrorVisibility
        {
            get { return _nameErrorVisibility; }
            set { _nameErrorVisibility = value; OnPropertyChanged("NameErrorVisibility"); }
        }

        public Visibility DateErrorVisibility
        {
            get { return _dateErrorVisibility; }
            set { _dateErrorVisibility = value; OnPropertyChanged("DateErrorVisibility"); }
        }

        public Visibility ImageClearButtonVisibility
        {
            get { return _imageClearButtonVisibility; }
            set { _imageClearButtonVisibility = value; OnPropertyChanged("ImageClearButtonVisibility"); }
        }

        public EditOrAddAwardWindowVM(ICollectionsEntity collectionEntity, AwardVM award = null)
        {
            _collectionEntity = collectionEntity;
            _award = award;

            ImageClearButtonVisibility = Visibility.Collapsed;

            if (_award != null)
            {
                if (_award.PerformerId != null)
                    Performer = new PerformerVM(DataLayer.Performer.GetById((Guid)_award.PerformerId));
                if (_award.EntertainmentId != null)
                    Entertainment = new EntertainmentVM(DataLayer.Entertainment.GetById((Guid)_award.EntertainmentId));
                Name = _award.Name;
                Nomination = _award.Nomination;
                Date = _award.Date;

                if (_award.Image != null)
                    ImageClearButtonVisibility = Visibility.Visible;
            }
            NameErrorVisibility = Visibility.Hidden;
            DateErrorVisibility = Visibility.Hidden;
        }

        internal void ImageButtonClick()
        {
            OpenFileDialog imageBrowse = new OpenFileDialog();
            imageBrowse.Filter = "Файлы рисунков|*.png;*.jpg;*.bmp;*.tif;*.gif";
            if (imageBrowse.ShowDialog() == true)
                Image = imageBrowse.FileName;
        }

        internal void ImageClearButtonClick()
        {
            _clearImage = true;
            ImageClearButtonVisibility = Visibility.Collapsed;
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

            if (Date == null)
            {
                DateErrorVisibility = Visibility.Visible;
                _isError = true;
            }
            else DateErrorVisibility = Visibility.Hidden;

            if (_isError)
                return false;

            if (_award == null)
            {
                AwardVM award = new AwardVM(Performer == null ? null : Performer, Entertainment == null ? null : Entertainment, Name, 
                Nomination, (DateTime)Date, Image == null ? null : File.ReadAllBytes(Image));
                award.AwardDL.Save();
                _collectionEntity.Add(award);
            }
            else
            {
                if (Performer != null)
                    _award.PerformerId = Performer.PerformerDL.Id;
                else _award.PerformerId = null;
                if (Entertainment != null)
                    _award.EntertainmentId = Entertainment.EntertainmentDL.Id;
                else _award.EntertainmentId = null;
                _award.Name = Name;
                _award.Nomination = Nomination;
                _award.Date = (DateTime)Date;
                if (Image != null && Image != String.Empty)
                    _award.Image = File.ReadAllBytes(Image);
                else if (_clearImage)
                    _award.Image = null;

                _award.AwardDL.Save();
            }
            return true;
        }

        public AutoCompleteFilterPredicate<object> PerformerFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as PerformerVM).ToString().ToLower().Contains(searchText.ToLower());
            }
        }

        public AutoCompleteFilterPredicate<object> EntertainmentFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as EntertainmentVM).ToString().ToLower().Contains(searchText.ToLower());
            }
        }


    }
}
