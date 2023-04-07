using System.Globalization;

namespace OEP6_fishingcontest
{
     class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            try
            {
                Console.WriteLine("Ügyes horgászok: ");
                foreach (string e in Collect(new infile("InputFile.txt")))
                {
                    Console.WriteLine(e);

                }
            }
            catch (Exception h)
            {

                Console.WriteLine($"Hiba:{h.Message}");
            }
            
        }

        private static List<string> Collect(infile infile)
        {
            List<string> list = new List<string>();
            while (infile.ReadFisher(out fisher fisher))
            {
                if (fisher.OK) list.Add(fisher.Name);
            }
            return list;
        }
    }
}