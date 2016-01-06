using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    public class Entity<T> where T : Entity<T>
    {
        private DataRow _row;
        public DataRow Row
        {
            get { return _row; }
            set
            {
                if (_row == null)
                    _row = value;
            }
        }

        public Guid Id { get; }
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public byte[] Poster { get; set; }
        public string Summary { get; set; }
        public string Name { get; set; }
        public string BuyLink { get; set; }
        public string MainLanguage { get; set; }

    }
}
