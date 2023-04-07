using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrSor
{
    public class Element
    {
        public int pr { get; set; }
        public string data { get; set; }
        public override string ToString() => $"({pr},{data})";  //return helyett

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Element other = obj as Element;
            return ((other.pr==pr)&&(other.data==data));
        }
        public void Read()
        {
            Console.WriteLine("Elembe kerülő adat");
            data = Console.ReadLine()!;
            bool ok;
            do
            {
                Console.WriteLine("Az elem prioritása");
                try
                {
                    pr = int.Parse(Console.ReadLine()!);
                    ok=true;
                }
                catch (FormatException)
                {

                    ok = false;
                }
            } while (!ok);

        }

    }
}
