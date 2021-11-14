using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp.Models
{
    public class Account
    {
        public Account(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }
}
