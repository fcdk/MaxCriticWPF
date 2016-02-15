using System;
using System.Windows;
using WpfCritic.Core;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class AwardVM : ViewModelBase
    {
        private Award _award;

        public Award AwardDL
        {
            get { return _award; }
        }

        public Guid? PerformerId
        {
            get { return _award.PerformerId; }
            set { _award.PerformerId = value; OnPropertyChanged("PerformerId"); }
        }

        public Guid? EntertainmentId
        {
            get { return _award.EntertainmentId; }
            set { _award.EntertainmentId = value; OnPropertyChanged("EntertainmentId"); }
        }

        public string Name
        {
            get { return _award.Name; }
            set { _award.Name = value; OnPropertyChanged("Name"); }
        }

        public string Nomination
        {
            get { return _award.Nomination; }
            set { _award.Nomination = value; OnPropertyChanged("Nomination"); OnPropertyChanged("NominationVisibility"); }
        }

        public DateTime Date
        {
            get { return _award.Date; }
            set { _award.Date = value; OnPropertyChanged("Date"); }
        }

        public byte[] Image
        {
            get { return _award.Image; }
            set { _award.Image = value; OnPropertyChanged("Image"); }
        }

        public Visibility NominationVisibility
        {
            get
            {
                if (Nomination != null && Nomination != String.Empty)
                    return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public AwardVM(Award award)
        {
            _award = award;

            Logger.Info("AwardVM.AwardVM", "Екземпляр AwardVM створений.");
        }

        public AwardVM(PerformerVM performer, EntertainmentVM entertainment, string name, string nomination, DateTime date, byte[] image)
        {
            _award = new Award(performer == null ? null : performer.PerformerDL, entertainment == null ? null : entertainment.EntertainmentDL, name, nomination, date, image);

            Logger.Info("AwardVM.AwardVM", "Екземпляр AwardVM створений.");
        }

        public override string ToString()
        {
            return Name + (Nomination == null ? String.Empty : ": " + Nomination) + " (" + Date.ToString("dd/MM/yyyy") + ")";
        }

        public static bool Comparison(AwardVM award1, AwardVM award2)
        {
            Logger.Info("AwardVM.Comparison", "Порівняння двох екземплярів AwardVM.");

            if (award1 == null || award2 == null)
                return false;
            return Entity<Award>.Comparison(award1.AwardDL, award2.AwardDL);
        }
    }
}
