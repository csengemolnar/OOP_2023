using System.Globalization;
using System.Threading;
namespace OEPhorgaszat
{
     class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			try
			{
				var x = new Infile("input.txt");
				bool l = SearchFisher(x, out string name);
                Console.WriteLine(l?$"Sok pontyot fogott: {name}":"nincs olyan horgász aki sok pontyot fogott");


			}
			catch (System.IO.FileNotFoundException)
			{

				Console.WriteLine("Hibás fájlnév\n");
			}
        }

        private static bool SearchFisher(Infile x, out string name)
        {
            bool l=false;
            name = null;
            while (!l&&x.ReadFisher(out Fisher e))
            {
                if (Psúly(e.Fogások) >= 10.0)
                {
                    l = true;name = e.name;
                }

            }
            return l;
        }

        private static double Psúly(List<Fogás> fogások)
        {
            double s = 0;
            foreach (var f in fogások)
            {
                if (f.fish == "ponty" && f.height > 0.5)
                {
                    s += f.weight;
                }
            }
            return s;
        }
    }
}