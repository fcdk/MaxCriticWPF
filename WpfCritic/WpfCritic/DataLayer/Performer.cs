using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("Performer")]
    [IdColumnName("PerformerId")]
    [NameColumnName("Name")]
    public class Performer : Entity<Performer>
    {
        public string Name
        {
            get { return Row["Name"].ToString(); }
            set { Row["Name"] = value; }
        }
        public string Surname
        {
            get { return Row["Surname"].ToString(); }
            set { Row["Surname"] = value; }
        }
        public Performer.Type PerformerType
        {
            get { return (Performer.Type)Enum.Parse(typeof(Performer.Type), Row["PerformerType"].ToString()); }
            set { Row["PerformerType"] = value; }
        }
        public DateTime? DateOfBirth
        {
            get { return Row["DateOfBirth"].Equals(DBNull.Value) ? default(DateTime?) : (DateTime)Row["DateOfBirth"]; }
            set { Row["DateOfBirth"] = value; }
        }
        public byte[] Image
        {
            get { return Row["Image"].Equals(DBNull.Value) ? null : (byte[])Row["Image"]; }
            set { Row["Image"] = value; }
        }
        public string Summary
        {
            get { return Row["Summary"].ToString(); }
            set { Row["Summary"] = value; }
        }

        public Performer(DataRow row) : base(row)
        {
            if (PerformerType == Performer.Type.Person)
                _nameColumnName = "Surname"; // если Performer - человек, то поиск по имени в Entity будет производиться по фамилии
        }
        public Performer(string name, string surname, Performer.Type performerType, DateTime? dateOfBirth, byte[] image,
        string summary) : base()
        {
            Name = name;
            Surname = surname;
            PerformerType = performerType;
            DateOfBirth = dateOfBirth;
            Image = image;
            Summary = summary;
            if (PerformerType == Performer.Type.Person)
                _nameColumnName = "Surname"; // если Performer - человек, то поиск по имени в Entity будет производиться по фамилии
        }

        public enum Type { Person, Band, GameDeveloperCompany, MovieProduction, TVNetwork, RecordLabel }
    }
}
