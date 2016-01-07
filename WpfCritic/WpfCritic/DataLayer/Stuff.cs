using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    public class Stuff : Entity<Stuff>
    {
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public byte[] Poster { get; set; }
        public string Summary { get; set; }
        public string Name { get; set; }
        public string BuyLink { get; set; }
        public string MainLanguage { get; set; }
    }
}
