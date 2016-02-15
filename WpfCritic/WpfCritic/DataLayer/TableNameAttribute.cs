using System;
using WpfCritic.Core;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class TableNameAttribute : Attribute
    {
        public string Name;
        public TableNameAttribute(string name)
        {
            Name = name;

            Logger.Info("TableNameAttribute.TableNameAttribute", "Створено екземпляр атрибута TableNameAttribute.");
        }
    }
}
