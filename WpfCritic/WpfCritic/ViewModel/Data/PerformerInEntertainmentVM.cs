using System;
using WpfCritic.Core;
using WpfCritic.DataLayer;

namespace WpfCritic.ViewModel.Data
{
    public class PerformerInEntertainmentVM : ViewModelBase
    {
        private PerformerInEntertainment _performerInEntertainment;

        public PerformerInEntertainment PerformerInEntertainmentDL
        {
            get { return _performerInEntertainment; }
        }

        public Guid PerformerId
        {
            get { return _performerInEntertainment.PerformerId; }
            set { _performerInEntertainment.PerformerId = value; OnPropertyChanged("PerformerId"); }
        }

        public Guid EntertainmentId
        {
            get { return _performerInEntertainment.EntertainmentId; }
            set { _performerInEntertainment.EntertainmentId = value; OnPropertyChanged("EntertainmentId"); }
        }

        public PerformerInEntertainment.Role PerformerRole
        {
            get { return _performerInEntertainment.PerformerRole; }
            set { _performerInEntertainment.PerformerRole = value; OnPropertyChanged("PerformerRole"); }
        }

        public PerformerInEntertainmentVM(PerformerInEntertainment performerInEntertainment)
        {
            _performerInEntertainment = performerInEntertainment;

            Logger.Info("PerformerInEntertainmentVM.PerformerInEntertainmentVM", "Екземпляр PerformerInEntertainmentVM створений.");
        }

        public PerformerInEntertainmentVM(PerformerVM performer, EntertainmentVM entertainment, PerformerInEntertainment.Role performerRole)
        {
            _performerInEntertainment = new PerformerInEntertainment(performer.PerformerDL, entertainment.EntertainmentDL, performerRole);

            Logger.Info("PerformerInEntertainmentVM.PerformerInEntertainmentVM", "Екземпляр PerformerInEntertainmentVM створений.");
        }

        public bool PerformerComparison(PerformerVM performer)
        {
            Logger.Info("PerformerInEntertainmentVM.PerformerComparison", "Порівняння даного екзмпляра жанру з жанром у PerformerInEntertainmentVM.");

            return performer.PerformerDL.Id == this.PerformerId;
        }

        public static bool Comparison(PerformerInEntertainmentVM performerInEntertainment1, PerformerInEntertainmentVM performerInEntertainment2)
        {
            Logger.Info("PerformerInEntertainmentVM.Comparison", "Порівняння двох екземплярів PerformerInEntertainmentVM.");

            if (performerInEntertainment1 == null || performerInEntertainment2 == null)
                return false;
            return Entity<PerformerInEntertainment>.Comparison(performerInEntertainment1.PerformerInEntertainmentDL, performerInEntertainment2.PerformerInEntertainmentDL);
        }

    }
}
