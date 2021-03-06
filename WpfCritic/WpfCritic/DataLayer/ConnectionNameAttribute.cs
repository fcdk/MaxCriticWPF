﻿using System;
using WpfCritic.Core;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class ConnectionNameAttribute : Attribute
    {
        public string Name;
        public ConnectionNameAttribute(string name)
        {
            Name = name;

            Logger.Info("ConnectionNameAttribute.ConnectionNameAttribute", "Створено екземпляр атрибута ConnectionNameAttribute.");
        }
    }
}
