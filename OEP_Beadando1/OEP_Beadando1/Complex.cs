using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OEP_Beadando1
{
     class Complex
    {
        private double x { get; set; }
        private double y { get; set; }

        public Complex(double a=0, double b=0)
        {
           
            this.x = a;
            this.y = b;

        }

        public override string ToString()
        {
            if (y < 0)
            {
                return $"{x}{y}i";
            }
            return $"{x}+{y}i";


        }

        static public Complex operator+(Complex a , Complex b)
        {
            
            double X = a.x + b.x;
            double Y = a.y + b.y;
            Complex c = new Complex(X, Y);

            return c;


        }

        static public Complex operator -(Complex a, Complex b)
        {
            
            double X = a.x - b.x;
            double Y = a.y - b.y;
            Complex c = new Complex(X, Y);

            return c;


        }
        static public Complex operator *(Complex a, Complex b)
        {
            
            double X = a.x * b.x - a.y * b.y;
            double Y = a.x * b.y + a.y * b.x;
            Complex c = new Complex(X, Y);


            return c;


        }
        static public Complex operator /(Complex a, Complex b)
        {
            
            if (b.x == 0 && b.y == 0)
            {
                throw new DivideByZeroException();
            }

            double X = (a.x * b.x + a.y * b.y) / (Math.Pow(b.x,2)+ Math.Pow(b.y, 2));
            double Y = (a.y * b.x + a.x * b.y) / (Math.Pow(b.x, 2) + Math.Pow(b.y, 2));
            Complex c = new Complex(X,Y);
            return c;


        }

    }
}
