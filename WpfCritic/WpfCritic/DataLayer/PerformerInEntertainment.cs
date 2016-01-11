using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("PerformerInEntertainment")]
    [IdColumnName("PerformerInEntertainmentId")]
    [NameColumnName(null)]
    public class PerformerInEntertainment : Entity<PerformerInEntertainment>
    {
        public Guid PerformerId
        {
            get { return (Guid)Row["PerformerId"]; }
            private set { Row["PerformerId"] = value; }
        }
        public Guid EntertainmentId
        {
            get { return (Guid)Row["EntertainmentId"]; }
            private set { Row["EntertainmentId"] = value; }
        }
        public PerformerInEntertainment.Role PerformerRole
        {
            get { return (PerformerInEntertainment.Role)Enum.Parse(typeof(PerformerInEntertainment.Role), Row["PerformerRole"].ToString()); }
            set { Row["PerformerRole"] = value; }
        }
        
        public PerformerInEntertainment(DataRow row) : base(row) { }
        public PerformerInEntertainment(Performer performer, Entertainment entertainment, PerformerInEntertainment.Role performerRole) : base()
        {
            PerformerId = performer.Id;
            EntertainmentId = entertainment.Id;
            PerformerRole = performerRole;
        }

        public enum Role { MovieDirector, MoviePlotWriter, MoviePrincipalCast, MovieCast, MovieProducer, MovieProduction,
        GameCast, GameDeveloperCompany, TVCast, TVNetwork, AlbumSinger, AlbumBand, AlbumRecordLabel }
    }
}
