using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarBead
{
    public class Kolcsonzes
    {
        public DateTime datum { get; private set; }
        public int potdij { get; private set; }
        public int id { get; private set; }
        public string azon { get; private set; }


        public Kolcsonzes(int id,string azon)
        {
            this.datum = DateTime.Now;
            this.id = id;
            this.azon = azon;

            
        }

        public Kolcsonzes(DateTime datum, int id, string azon)
        {
            this.datum = datum;
            this.id = id;
            this.azon = azon;
            
        }



    }
}
