using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class EditOrAddPerformerWindowVM : ViewModelBase
    {
        private ICollectionsEntity _collectionEntity;
        private PerformerVM _performer;

        private string[] _performerTypes = new string[] { "Музична група", "Розробник гри", "Ігрова платформа", "Продюсерська компанія", "Людина", "Лейбл", "Телевізійний канал" };

        private bool _isError;
        private bool _clearImage = false;
        private Visibility _nameErrorVisibility;
        private Visibility _imageClearButtonVisibility;

        //кеширование свойств Performer
        private string _performerTypeUkr = "Людина";
        private string _name;
        private string _surname;
        private DateTime? _dateOfBirth;
        private string _image;
        private string _summary;

        public string[] PerformerTypes
        {
            get { return _performerTypes; }
        }

        public string PerformerTypeUkr
        {
            get { return _performerTypeUkr; }
            set { _performerTypeUkr = value; OnPropertyChanged("PerformerTypeUkr"); }
        }

        public string NameLabel
        {
            get
            {
                if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) == Performer.Type.Person)
                    return "Ім'я:";
                else return "Назва:";
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }

        public string DateOfBirthLabel
        {
            get
            {
                if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) == Performer.Type.Person)
                    return "Дата народження:";
                if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) == Performer.Type.GamePlatform)
                    return "Дата виходу:";
                else return "Дата заснування:";
            }
        }

        public DateTime? DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; OnPropertyChanged("Image"); }
        }

        public string SummaryLabel
        {
            get
            {
                if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) == Performer.Type.Person)
                    return "Біографія:";
                else return "Опис:";
            }
        }

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; OnPropertyChanged("Summary"); }
        }

        public string HeaderText
        {
            get
            {
                if (_performer == null)
                    return "Додавання нового додаткового контенту";
                return "Редагування додаткового контенту";
            }
        }

        public Visibility SurnameVisibility
        {
            get
            {
                if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) == Performer.Type.Person)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
        }

        public Visibility NameErrorVisibility
        {
            get { return _nameErrorVisibility; }
            set { _nameErrorVisibility = value; OnPropertyChanged("NameErrorVisibility"); }
        }

        public Visibility ImageClearButtonVisibility
        {
            get { return _imageClearButtonVisibility; }
            set { _imageClearButtonVisibility = value; OnPropertyChanged("ImageClearButtonVisibility"); }
        }

        public EditOrAddPerformerWindowVM(ICollectionsEntity collectionEntity, PerformerVM performer = null)
        {
            _collectionEntity = collectionEntity;
            _performer = performer;

            ImageClearButtonVisibility = Visibility.Collapsed;

            if (_performer != null)
            {
                PerformerTypeUkr = _performer.PerformerTypeUkr;
                Name = _performer.Name;
                Surname = _performer.Surname;
                DateOfBirth = _performer.DateOfBirth;
                Summary = _performer.Summary;

                if (_performer.Image != null)
                    ImageClearButtonVisibility = Visibility.Visible;
            }
            NameErrorVisibility = Visibility.Hidden;

            Logger.Info("EditOrAddPerformerWindowVM.EditOrAddPerformerWindowVM", "Екземпляр EditOrAddPerformerWindowVM створений.");
        }

        internal void PerformerTypeUkrComboBoxSelectionChanged()
        {
            OnPropertyChanged("SurnameVisibility");
            OnPropertyChanged("NameLabel");
            OnPropertyChanged("DateOfBirthLabel");
            OnPropertyChanged("SummaryLabel");
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

            if (_isError)
                return false;

            if (PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr) != Performer.Type.Person)
                Surname = null;

            if (_performer == null)
            {
                PerformerVM perfomer = new PerformerVM(Name, Surname, (Performer.Type)PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr),
                DateOfBirth, Image == null ? null : File.ReadAllBytes(Image), Summary);
                perfomer.PerformerDL.Save();
                _collectionEntity.Add(perfomer);
            }
            else
            {
                _performer.PerformerType = (Performer.Type)PerformerVM.PerformerTypeUkrStringToEngEnum(PerformerTypeUkr);
                _performer.Name = Name;
                _performer.Surname = Surname;
                _performer.DateOfBirth = DateOfBirth;
                if (Image != null && Image != String.Empty)
                    _performer.Image = File.ReadAllBytes(Image);
                else if (_clearImage)
                    _performer.Image = null;
                _performer.Summary = Summary;

                _performer.PerformerDL.Save();
            }
            return true;
        }

    }
}
