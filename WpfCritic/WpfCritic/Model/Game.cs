using System;
using System.Drawing;

namespace WpfCritic.Model
{
    public class Game : BaseStuff<Game>
    {
        public string Name { get; set; }
        public string OfficialSite { get; set; }
        public string Developer { get; set; }
        public string Trailer { get; set; }
        // и т.д.

        public Game() : base()
        {
            Name = string.Empty;
            OfficialSite = string.Empty;
            Developer = string.Empty;
            Trailer = string.Empty;
        }

        public Game(string name, string officialSite, string developer, string trailer, DateTime releaseDate, string company, string poster) : base(releaseDate, company, poster)
        {
            Name = name;
            OfficialSite = officialSite;
            Developer = developer;
            Trailer = trailer;
        }

        public override string ToString()
        {
            return Name + " (" + ReleaseDate.Year + ")";
        }
    }
}
