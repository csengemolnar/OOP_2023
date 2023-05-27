using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunapark
{
    abstract class Ajandek
    {

        public Cellovolde Cellovolde { get; set; }

        public IMeret Meret { get; private set; }

        public Ajandek( IMeret meret)
        {
            Meret = meret;
        }

        public abstract int Pont();
        public virtual int Ertek()=> Pont()*Meret.Szorzo();

    }

    class Plüss : Ajandek
    {
        public Plüss(IMeret meret):base(meret)
        {

        }

        public override int Pont()
        {
            return 2;
        }

    }

    class Figura : Ajandek
    {
        public Figura(IMeret meret) : base(meret)
        {

        }

        public override int Pont()
        {
            return 3;
        }

    }


    class Labda : Ajandek
    {
        public Labda(IMeret meret) : base(meret)
        {

        }

        public override int Pont()
        {
            return 1;
        }

    }
}
