using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunapark
{
    class Cellovolde
    {

        public class NincsVendegException : Exception { }
        public class FoglaltAjandekException : Exception { }

        public class LetezoAjandekException : Exception { }

        public readonly string hely;

        public List<Ajandek> Ajandekok { get; private set; }
        public List<Vendeg> Vendegek { get; private set; }

        public Cellovolde(string hely)
        {
            this.hely = hely;
            Ajandekok = new();
            Vendegek = new();

        }

        public void Kiallit(Ajandek ajandek)
        {
            if(ajandek.Cellovolde!=null) throw new FoglaltAjandekException();
            if (Ajandekok.Contains(ajandek)) throw new LetezoAjandekException();
            ajandek.Cellovolde = this;
            Ajandekok.Add(ajandek);
        }

        public void Regisztral(Vendeg v)
        {
            Vendegek.Add(v);
        }

        public string Legjobb()
        {
            if (Vendegek.Count==0) throw new NincsVendegException();
            int max = Vendegek[0].Eredmeny(this);
            Vendeg elem = Vendegek[0];
            foreach (var e in Vendegek)
            {
                int p = e.Eredmeny(this);
                if (p > max) {max= p;elem = e; }

            }
            return elem.nev;


        }

    }
}
