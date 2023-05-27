using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando
{
     class Konyv
    {
        public string cim;
        public string szerzo;
        public string azonosito=null;
        public string ISBN;
        public int oldal;
        public bool ritkasage;
        public string mufaj;

        public Konyv(string cim, string szerzo, string ISBN, int oldal, bool ritkasage,string mufaj )
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.ISBN = ISBN;
            this.oldal = oldal;
            this.ritkasage = ritkasage;
            this.mufaj = mufaj;
            

        }
        public Konyv(string cim, string szerzo,string azonosito, string ISBN, int oldal, bool ritkasage, string mufaj)
        {
            
            this.cim = cim;
            this.szerzo = szerzo;
            this.azonosito = azonosito;
            this.ISBN = ISBN;
            this.oldal = oldal;
            this.ritkasage = ritkasage;
            this.mufaj = mufaj;
        }

    }
}
