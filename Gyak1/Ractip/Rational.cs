using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ractip
{
     class Rational
    {
        int n;
        int d;

        public Rational(int n=0, int d=1)
        {
            if (d == 0)
            {
                throw new DivideByZeroException();
            }
            this.n = n;
            this.d = d;

        }
        public override string ToString()
        {
            return (d!=1) ? $"({n}/{d})":n.ToString();
        }
        static int lnko(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a * b != 0)
            {
                while (a != b)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    if (b > a)
                    {
                        b -= a;
                    }
                    
                }
                return a;
            }
            else
            {
                return 1;
            }

        }

        static public Rational operator+(Rational a, Rational b)
        {
            Rational c = new Rational();
            c.n = a.n * b.d + a.d * b.n;
            c.d = a.d * b.d;
            var t = lnko(c.n, c.d);
            return new Rational(c.n/t,c.d/t);

        }
        static public Rational operator*(Rational a, Rational b)
        {
            Rational c = new Rational();
            c.n = a.n * b.n;
            c.d = a.d * b.d;
            var t = lnko(c.n, c.d);
            return new Rational(c.n / t, c.d / t);


        }
        static public Rational operator-(Rational a, Rational b)
        {
            Rational c = new Rational();
            c.n = a.n * b.d - a.d * b.n;
            c.d = a.d * b.d;
            var t = lnko(c.n, c.d);
            return new Rational(c.n / t, c.d / t);

        }

        static public Rational operator/(Rational a, Rational b)
        {
            Rational c = new Rational();
            c.n = a.n * b.d;
            c.d = a.d * b.d;
            var t = lnko(c.n, c.d);
            return new Rational(c.n / t, c.d / t);

        }

    }
}
