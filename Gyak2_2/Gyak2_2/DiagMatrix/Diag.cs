using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagMatrix
{
    public class Diag
    {
        public class ReferenceToNullPartException : Exception { }
        public class DifferentSizeException: Exception { }

        List<int> x;
        public Diag()
        {
            x = new();
        }
        public Diag(int k)
        {
            x = new();
            for (int i = 0; i < k; i++)
            {
                x.Add(0);
            }
        }

        public void reSize(int k) { x = new List<int>(k); }

        
        // indexer
        public int this[int i, int j]
        {
            get { 
                    if(i<0 || i >= x.Count || j<0 || j>=x.Count) throw new IndexOutOfRangeException();
                    return (i == j) ? x[i] : 0;
                 }
            set {
                if (i < 0 || i >= x.Count || j < 0 || j >= x.Count) throw new IndexOutOfRangeException();
                if (i == j) x[i] = value; else throw new ReferenceToNullPartException();
            }
        }

        public static Diag operator+(Diag a, Diag b)
        {
            if(a.x.Count!=b.x.Count) throw new DifferentSizeException();
            Diag c = new Diag(a.x.Count);
            for (int i = 0; i < c.x.Count; i++)
            {
                c.x[i] = a.x[i] + b.x[i];
            }
            return c;
        }
        public static Diag operator*(Diag a, Diag b)
        {
            if(a.x.Count!=b.x.Count) throw new DifferentSizeException();
            Diag c = new Diag(a.x.Count);
            for (int i = 0; i < c.x.Count; i++)
            {
                c.x[i] = a.x[i] * b.x[i];
            }
            return c;
        }
        public override string ToString()
        {
            var str = String.Empty;
            for (int i = 0; i < x.Count; i++)
            {
                for (int j = 0; j < x.Count; j++)
                {
                    str += $"\t{this[i,j]}";
                }
                str+="\n";
            }

            return str;
        }

    }
}
