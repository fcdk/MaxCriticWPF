using System;
using System.Drawing;

namespace Critic.Data
{
    public class Game : BaseStuff<Game>
    {
        public string Name { get; set; }
        public string OfficialSite { get; set; }
        public string Developer { get; set; }
        // и т.д.

        public Game(string name, string officialSite, string developer, DateTime releaseDate, string company, string poster) : base(releaseDate, company, poster)
        {
            Name = name;
            OfficialSite = officialSite;
            Developer = developer;
        } 
    }
}
