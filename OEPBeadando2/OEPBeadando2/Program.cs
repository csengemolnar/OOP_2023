using System.Globalization;
using TextFile;

namespace OEPBeadando2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                TextFileReader reader = new TextFileReader("input.txt");

                double s = 0.0;
                int db = 0;
                while (reader.ReadInt(out int e) && e >= 0)
                {
                    s = s + e;
                    db += 1;

                }
                double a = s / db;

                Console.WriteLine($"Elso fagypont alatti erteket megelozo napok homersekleteinek atlaga: {a} \n");

                bool l = true;
                double min = 0.0;
                while (reader.ReadInt(out int e))
                {
                    l = l && e < 0;

                    if (min > e)
                    {
                        min = e;
                    }

                }

                if (l == true)
                {
                    Console.WriteLine("Fagypont alatt maradt a homerseklet!");
                }
                else
                {
                    Console.WriteLine("Nem maradt fagypont alatt a homerseklet!");
                }

                Console.WriteLine($"A legalacsonyabb homerseklet: {min} \n");





            }
            catch (Exception h)
            {

                Console.WriteLine($"Hiba: {h.Message}"); ;
            }
        }
    }
}