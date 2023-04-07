using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kör
{
     class circle
    {
        class IllegalRadiusException : Exception { };
        double r;
        point C;//centre

        public circle(point p,double a)
        {
            if (a < 0) throw new IllegalRadiusException();
            C = p;//kör középpontja
            r = a;
        }

        public bool contains(point p)
        {
            return C.distance(p) <= r;
        }
    }
}
