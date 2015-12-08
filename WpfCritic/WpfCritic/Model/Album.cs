using System;
using System.Drawing;

namespace WpfCritic.Model
{
    public class Album : BaseStuff<Album>
    {
        public string Name { get; set; }
        // и т.д.

        public Album(string name, DateTime releaseDate, string company, string poster) : base(releaseDate, company, poster)
        {
            Name = name;
        }
    }
}
