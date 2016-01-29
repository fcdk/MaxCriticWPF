using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using WpfCritic.DataLayer;
using WpfCritic.ViewModel.Data;

namespace WpfCritic.ViewModel
{
    public class PerformerDetailsWindowVM : ViewModelBase
    {
        private PerformerVM _performer;
        private byte[] _noImage;

        public byte[] Image
        {
            get
            {
                return _performer.Image == null ? _noImage : _performer.Image;
            }
        }

        public string PerformerTypeUkr
        {
            get { return _performer.PerformerTypeUkr; }
        }

        public string NameLabel
        {
            get
            {
                if (_performer.PerformerType == Performer.Type.Person)
                    return "Ім'я:";
                else return "Назва:";
            }
        }

        public string Name
        {
            get { return _performer.Name; }
        }

        public string Surname
        {
            get { return _performer.Surname; }
        }

        public string DateOfBirthLabel
        {
            get
            {
                if (_performer.PerformerType == Performer.Type.Person)
                    return "Дата народження:";
                if (_performer.PerformerType == Performer.Type.GamePlatform)
                    return "Дата виходу:";
                else return "Дата заснування:";
            }
        }

        public string DateOfBirth
        {
            get
            {
                if (_performer.DateOfBirth != null)
                    return ((DateTime)_performer.DateOfBirth).ToString("dd/MM/yyyy");
                else return null;
            }
        }

        public string SummaryLabel
        {
            get
            {
                if (_performer.PerformerType == Performer.Type.Person)
                    return "Біографія:";
                else return "Опис:";
            }
        }

        public string Summary
        {
            get { return _performer.Summary; }
        }

        public Visibility SurnameVisibility
        {
            get
            {
                if (_performer.PerformerType != Performer.Type.Person || Surname == null || Surname == String.Empty)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public Visibility DateOfBirthVisibility
        {
            get
            {
                if (DateOfBirth == null)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public Visibility SummaryVisibility
        {
            get
            {
                if (Summary == null || Summary == String.Empty)
                    return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public PerformerDetailsWindowVM(PerformerVM performer)
        {
            _performer = performer;

            if (performer.Image == null)
            {                
                _noImage = File.ReadAllBytes(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\noImage.png");
            }

        }

    }
}
