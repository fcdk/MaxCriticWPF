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

    }
}
