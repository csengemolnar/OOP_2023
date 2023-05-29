using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace KonyvtarBead
{
     public class Szemely
    {
        public int id;
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
