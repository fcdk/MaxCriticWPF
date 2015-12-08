using System;
using System.Drawing;

namespace WpfCritic.Model
{
    public class TVSeries : BaseStuff<TVSeries>
    {
        public string Name { get; set; }
        public uint Season { get; set; }
        public string Network { get; set; }
        // и т.д.

        public TVSeries(string name, uint season, string network, DateTime releaseDate, string company, string poster) : base(releaseDate, company, poster)
        {
            Name = name;
            Season = season;
            Network = network;
        }

    }
}
