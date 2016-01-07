﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCritic.DataLayer
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class ConnectionStringAttribute : Attribute
    {
        public string Name;
        public ConnectionStringAttribute(string name)
        {
            Name = name;
        }
    }
}