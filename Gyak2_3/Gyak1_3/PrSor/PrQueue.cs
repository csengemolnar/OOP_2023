using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrSor
{
    public class PrQueue
    {
        readonly List<Element> seq=new List<Element>();
        public class PrQueueEmpty : Exception { }

        public bool isEmpty() => seq.Count == 0;

        public void Add(Element e)
        {
            seq.Add(e);
        }

        public void SetEmpty()
        {
            seq.Clear();
        }

        public Element GetMax()
        {
            if (seq.Count == 0) throw new PrQueueEmpty();
            int ind = MaxIndex();
            return seq[ind];
        }

        private int MaxIndex()
        {
            int ind=0;
            int maxkey = seq[0].pr;
            for (int i = 1; i < seq.Count; i++)
            {
                if (seq[i].pr>maxkey)
                {
                    ind = i;
                    maxkey = seq[i].pr;
                }
            }
            return ind;
        }

        public int GetCapacity() => seq.Capacity;

        public Element RemMax()
        {
            if (seq.Count==0) throw new PrQueueEmpty();
            int ind=MaxIndex();
            var best = seq[ind];
            seq.RemoveAt(ind);
            return best;
        }

        public void Write()
        {
            if (seq.Count == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write($"PrQueue: <{seq[0]}");
                for (int i = 1; i < seq.Count; i++)
                {
                    Console.Write($",{seq[i]}");
                }
                Console.WriteLine(">");
            }
        }
    }
}
