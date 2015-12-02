using System;
using System.Collections.Generic;

namespace Critic.Data
{
    public class BaseType<T>
        where T : BaseType<T>
    {
        public Guid Id { get; set; }
        public static Dictionary<Guid,T> _items = new Dictionary<Guid, T>();
        public static Dictionary<Guid, T> Items { get { return _items; } }

        public BaseType()
        {
            Id = Guid.NewGuid();
            Items.Add(Id, (T)this);
        }
    }
}
