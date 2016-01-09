using System;
using System.Data;

namespace WpfCritic.DataLayer
{
    [TableName("Entertainment")]
    [IdColumnName("EntertainmentId")]
    [NameColumnName("Name")]
    public class Entertainment : Entity<Entertainment>
    {
        public Entertainment.Type EntertainmentType
        {
            get { return (Entertainment.Type)Enum.Parse(typeof(Entertainment.Type), Row["EntertainmentType"].ToString()); }
            set { Row["EntertainmentType"] = value.ToString(); }
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

        public Entertainment(DataRow row) : base(row) { }
        public Entertainment(Entertainment.Type entertainmentType, string name, DateTime releaseDate, string company, byte[] poster,
        string summary, string buyLink, string mainLanguage, string rating, string ratingComment, int movieRuntimeMinute,
        string officialSite, string movieCountries, byte tVSeason, decimal budget, string trailerLink) : base()
        {
            EntertainmentType = entertainmentType;
            Name = name;
            ReleaseDate = releaseDate;
            Company = company;
            Poster = poster;
            Summary = summary;
            BuyLink = buyLink;
            MainLanguage = mainLanguage;
            Rating = rating;
            RatingComment = ratingComment;
            MovieRuntimeMinute = movieRuntimeMinute;
            OfficialSite = officialSite;
            MovieCountries = movieCountries;
            TVSeason = tVSeason;
            Budget = budget;
            TrailerLink = trailerLink;
        }

        public enum Type { Movie, Game, TVSeries, Album }

    }
}
