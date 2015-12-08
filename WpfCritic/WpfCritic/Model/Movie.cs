using System;
using System.Drawing;

namespace WpfCritic.Model
{
    public class Movie : BaseStuff<Movie>
    {
        public string Name { get; set; }
        public uint Runtime { get; set; }
        public string OfficialSite{ get; set; }
        public string Trailer { get; set; }
        // и т.д.

        public Movie(string name, uint runtime, string officialSite, string trailer, DateTime releaseDate, string company, string poster) : base(releaseDate, company, poster)
        {
            Name = name;
            Runtime = runtime;
            OfficialSite = officialSite;
            Trailer = trailer;
        }

        public override string ToString()
        {
            return Name + " (" + ReleaseDate.Year + ")";
        }
    }
}
