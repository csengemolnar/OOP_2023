using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kör
{
     class point
    {
        double X { get; set;}
        double Y { get; set;}

        public point(double x=0, double y=0)
        {
            this.X = x;
            this.Y = y;     
        }

        public double distance(point p)
        {
            return Math.Sqrt(Math.Pow(this.X - p.X,2) + Math.Pow(this.Y - p.Y,2));
        }

        public override string ToString()
        {
            return $"({X},{Y})"; 
        }
    }
}
