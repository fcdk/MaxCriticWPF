using System;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class PerformerVM : ViewModelBase
    {
        private Performer _performer;

        public Performer PerformerDL
        {
            get { return _performer; }
        }

        public string Name
        {
            get { return _performer.Name; }
            set { _performer.Name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _performer.Surname; }
            set { _performer.Surname = value; OnPropertyChanged("Surname"); }
        }

        public Performer.Type PerformerType
        {
            get { return _performer.PerformerType; }
            set
            {
                _performer.PerformerType = value;
                OnPropertyChanged("PerformerType");
                OnPropertyChanged("PerformerTypeUkr");
            }
        }

        public string PerformerTypeUkr
        {
            get { return PerformerTypeToUkrString(PerformerType); }
        }

        public DateTime? DateOfBirth
        {
            get { return _performer.DateOfBirth; }
            set { _performer.DateOfBirth = value; OnPropertyChanged("DateOfBirth"); }
        }

        public byte[] Image
        {
            get { return _performer.Image; }
            set { _performer.Image = value; OnPropertyChanged("Image"); }
        }

        public string Summary
        {
            get { return _performer.Summary; }
            set { _performer.Summary = value; OnPropertyChanged("Summary"); }
        }

        public PerformerVM(Performer performer)
        {
            _performer = performer;
        }

        public PerformerVM(string name, string surname, Performer.Type performerType, DateTime? dateOfBirth, byte[] image, string summary)
        {
            _performer = new Performer(name, surname, performerType, dateOfBirth, image, summary);
        }

        public override string ToString()
        {
            if (_performer.PerformerType == Performer.Type.Person)
                return Name + " " + (Surname == null ? String.Empty : Surname) + (DateOfBirth == null ? String.Empty : " (" + ((DateTime)DateOfBirth).ToString("dd/MM/yyyy") + ")");
            else return Name;
        }

        public static string PerformerTypeToUkrString(Performer.Type type)
        {
            switch (type)
            {
                case Performer.Type.Band:
                    return "Музична група";
                case Performer.Type.GameDeveloperCompany:
                    return "Розробник гри";
                case Performer.Type.GamePlatform:
                    return "Ігрова платформа";
                case Performer.Type.MovieProduction:
                    return "Продюсерська компанія";
                case Performer.Type.Person:
                    return "Людина";
                case Performer.Type.RecordLabel:
                    return "Лейбл";
                case Performer.Type.TVNetwork:
                    return "Телевізійний канал";
                default:
                    return "";
            }
        }

        public static Performer.Type? PerformerTypeUkrStringToEngEnum(string type)
        {
            switch (type)
            {
                case "Музична група":
                    return Performer.Type.Band;
                case "Розробник гри":
                    return Performer.Type.GameDeveloperCompany;
                case "Ігрова платформа":
                    return Performer.Type.GamePlatform;
                case "Продюсерська компанія":
                    return Performer.Type.MovieProduction;
                case "Людина":
                    return Performer.Type.Person;
                case "Лейбл":
                    return Performer.Type.RecordLabel;
                case "Телевізійний канал":
                    return Performer.Type.TVNetwork;
                default:
                    return null;
            }
        }

        public static bool Comparison(PerformerVM performer1, PerformerVM performer2)
        {
            if (performer1 == null || performer2 == null)
                return false;
            return Entity<Performer>.Comparison(performer1.PerformerDL, performer2.PerformerDL);
        }

    }
}
