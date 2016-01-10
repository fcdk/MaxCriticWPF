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
        public Role PerformerRole
        {
            get { return (Role)Enum.Parse(typeof(Role), Row["PerformerRole"].ToString()); }
            set { Row["PerformerRole"] = value.ToString(); }
        }
        
        public PerformerInEntertainment(DataRow row) : base(row) { }
        public PerformerInEntertainment(Performer performer, Entertainment entertainment, Role performerRole) : base()
        {
            PerformerId = performer.Id;
            EntertainmentId = entertainment.Id;
            PerformerRole = performerRole;
        }

        public enum Role { MovieDirector, MoviePlotWriter, MoviePrincipalCast, MovieCast, MovieProducer, MovieProduction,
        GameCast, GameDeveloperCompany, TVCast, TVNetwork, AlbumSinger, AlbumBand, AlbumRecordLabel }
    }
}
