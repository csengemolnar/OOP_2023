using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunapark
{
    interface IMeret
    {
        int Szorzo();
    }

    class S : IMeret
    {
        private static S instance;

        public static S Instance
        {
            get
            {
                if(instance==null) instance= new S();
                return instance;
            }
        }

        public int Szorzo() => 1;
        
    }

    class M : IMeret
    {
        private static M instance;

        public static M Instance
        {
            get
            {
                if (instance == null) instance = new M();
                return instance;
            }
        }

        public int Szorzo() => 2;

    }

    class L : IMeret
    {
        private static L instance;

        public static L Instance
        {
            get
            {
                if (instance == null) instance = new L();
                return instance;
            }
        }

        public int Szorzo() => 3;

    }
    class XL : IMeret
    {
        private static XL instance;

        public static XL Instance
        {
            get
            {
                if (instance == null) instance = new XL();
                return instance;
            }
        }

        public int Szorzo() => 4;

    }
}
