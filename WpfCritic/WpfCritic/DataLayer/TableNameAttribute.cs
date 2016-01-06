using System;

namespace WpfCritic.DataLayer
{
    public sealed class TableNameAttribute : Attribute
    {
        public string Name;
        public TableNameAttribute(string name)
        {
            Name = name;
        }
    }
}
