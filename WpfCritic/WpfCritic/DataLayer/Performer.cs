namespace WpfCritic.DataLayer
{
    [TableName("Performer")]
    [IdColumnName("PerformerId")]
    [NameColumnName("Surname")]
    public class Performer : Entity<Performer>
    {

    }
}
