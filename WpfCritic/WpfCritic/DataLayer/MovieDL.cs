using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    public class MovieDL
    {
        private DataRow _row;

        public DataRow Row
        {
            get { return _row; }
        }

        public int MovieID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Company { get; set; }
        public string Poster { get; set; }
        public string Name { get; set; }
        public uint Runtime { get; set; }
        public string OfficialSite { get; set; }
        public string Trailer { get; set; }

        public MovieDL(DataRow row)
        {
            _row = row;
        }

        internal void SetRow(DataRow dataRow)
        {
            if (_row == null)
                _row = dataRow;
        }
    }
}
