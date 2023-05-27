using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunapark
{
    class Vendeg
    {

        public class MarVanIlyenAjandekException: Exception { }
        public class NincsIlyenAjandekException:Exception { }

        public readonly string nev;

        public List<Ajandek> Nyeremenyek { get; private set; }

        public Vendeg(string r)
        {
            this.nev = r;
            Nyeremenyek = new();

        }

        public void Latogat(Cellovolde c) => c.Regisztral(this);

        public void Nyer(Ajandek a)
        {
            if(Nyeremenyek.Contains(a)) throw new MarVanIlyenAjandekException();
            if(a.Cellovolde==null) throw new NincsIlyenAjandekException();
            a.Cellovolde.Ajandekok.Remove(a);
            Nyeremenyek.Add(a);
        }

        public int Eredmeny(Cellovolde c)
        {
            return Nyeremenyek.Sum(a => a.Ertek);
        }
    }
}
