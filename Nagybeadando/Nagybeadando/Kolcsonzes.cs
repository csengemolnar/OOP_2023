using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagybeadando
{
    class Kolcsonzes
    {
        public DateTime datum { get; private set; }
        public int potdij { get; private set; }
        public Szemely szemely { get; private set; }
        public Konyv konyv { get; private set; }


        public Kolcsonzes(Szemely sz,Konyv k)
        {
            this.datum = DateTime.Now;
            this.potdij = 0;
            this.szemely = sz;
            this.konyv = k;

            
        }

        public Kolcsonzes(DateTime datum,Szemely sz, Konyv k)
        {
            this.datum = datum;
            this.potdij = 0;
            this.szemely = sz;
            this.konyv = k;
            
        }




        public int Potdijfizet()
        {
            if (DateTime.Now > datum.AddDays(14))
            {
                int elteltido=(DateTime.Now-datum).Days;
                potdij = PotdijSzamol(elteltido);
            }
            Console.WriteLine($"Személy: {szemely.nev}\tKönyv: {konyv.cim}\tFizetendő pótdíj: {potdij.ToString()}");
            return potdij;
        }

        private int PotdijSzamol(int elteltido)
        {
            int osszeg = 0;
            if(this.konyv.mufaj=="természettudományi" && this.konyv.ritkasage)
            {
                osszeg = 100 * elteltido;
            }
            if(this.konyv.mufaj =="természettudományi" && !this.konyv.ritkasage)
            {
                osszeg=20 * elteltido;
            }
            if(this.konyv.mufaj =="szépirodalmi" && this.konyv.ritkasage)
            {
                osszeg = 50 * elteltido;
            }
            if (this.konyv.mufaj == "szépirodalmi" && !this.konyv.ritkasage)
            {
                osszeg = 10 * elteltido;
            }
            if(this.konyv.mufaj == "ifjúsági" && this.konyv.ritkasage)
            {
                osszeg = 30 * elteltido;
            }
            if (this.konyv.mufaj == "ifjúsági" && !this.konyv.ritkasage)
            {
                osszeg = 10 * elteltido;
            }

            return osszeg;

        }
    }
}
