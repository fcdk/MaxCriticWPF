using System;

namespace WpfCritic.DataLayer
{
    public class Entertainment : Entity<Entertainment>
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
