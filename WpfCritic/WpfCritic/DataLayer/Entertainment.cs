using System;

namespace WpfCritic.DataLayer
{
    [TableName("Entertainment")]
    [IdColumnName("EntertainmentId")]
    [NameColumnName("Name")]
    public class Entertainment : Entity<Entertainment>
    {
        public string EntertainmentType
        {
            get { return Row["EntertainmentType"].ToString(); }
            set { Row["EntertainmentType"] = value; }
        }
        public string Name
        {
            get { return Row[_nameColumnName].ToString(); }
            set { Row[_nameColumnName] = value; }
        }
        public DateTime ReleaseDate
        {
            get { return (DateTime)Row["ReleaseDate"]; }
            set { Row["ReleaseDate"] = value; }
        }
        public string Company
        {
            get { return Row["Company"].ToString(); }
            set { Row["Company"] = value; }
        }
        public byte[] Poster
        {
            get { return (byte[])Row["Poster"]; }
            set { Row["Poster"] = value; }
        }
        public string Summary
        {
            get { return Row["Summary"].ToString(); }
            set { Row["Summary"] = value; }
        }
        public string BuyLink
        {
            get { return Row["BuyLink"].ToString(); }
            set { Row["BuyLink"] = value; }
        }
        public string MainLanguage
        {
            get { return Row["MainLanguage"].ToString(); }
            set { Row["MainLanguage"] = value; }
        }
        public string Rating
        {
            get { return Row["Rating"].ToString(); }
            set { Row["Rating"] = value; }
        }
        public string RatingComment
        {
            get { return Row["RatingComment"].ToString(); }
            set { Row["RatingComment"] = value; }
        }
        public int MovieRuntimeMinute
        {
            get { return (int)Row["MovieRuntimeMinute"]; }
            set { Row["MovieRuntimeMinute"] = value; }
        }
        public string OfficialSite
        {
            get { return Row["OfficialSite"].ToString(); }
            set { Row["OfficialSite"] = value; }
        }
        public string MovieCountries
        {
            get { return Row["MovieCountries"].ToString(); }
            set { Row["MovieCountries"] = value; }
        }
        public byte TVSeason
        {
            get { return (byte)Row["TVSeason"]; }
            set { Row["TVSeason"] = value; }
        }
        public decimal Budget
        {
            get { return (decimal)Row["Budget"]; }
            set { Row["Budget"] = value; }
        }
        public string TrailerLink
        {
            get { return Row["TrailerLink"].ToString(); }
            set { Row["TrailerLink"] = value; }
        }

    }
}
