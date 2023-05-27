using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Nagybeadando
{
     class Szemely
    {
        public int id { get; private set; }
        public string nev { get; private set; }

        public Szemely(int id, string n)
        {
            this.id = id;
            this.nev = n;
            
        }
        public Szemely(string n)
        {
            
            this.nev = n;

        }


    }
}
