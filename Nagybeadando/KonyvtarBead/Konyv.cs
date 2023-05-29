using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarBead
{
     public class Konyv
    {
        public string cim;
        public string szerzo;
        public string azonosito=null;
        public string ISBN;
        public int oldal;
        public bool ritkasage;
        public string mufaj;
        public bool kolcsonk;

        public Konyv(string cim, string szerzo, string ISBN, int oldal, bool ritkasage,string mufaj)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.ISBN = ISBN;
            this.oldal = oldal;
            this.ritkasage = ritkasage;
            this.mufaj = mufaj;
            
            

        }
        public Konyv(string cim, string szerzo,string azonosito, string ISBN, int oldal, bool ritkasage, string mufaj,bool kolcsonk)
        {
            
            this.cim = cim;
            this.szerzo = szerzo;
            this.azonosito = azonosito;
            this.ISBN = ISBN;
            this.oldal = oldal;
            this.ritkasage = ritkasage;
            this.mufaj = mufaj;
            this.kolcsonk = kolcsonk;



        }

    }
}
