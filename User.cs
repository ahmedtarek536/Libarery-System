using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibarerySystem
{
    internal class User
    {
        public string FullName;
        public string Id;
        public User(string fullName, string id)
        {
            FullName = fullName;
            Id = id;
        }
    }
}
