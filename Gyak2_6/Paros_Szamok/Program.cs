using TextFile;

namespace Paros_Szamok
{
     class Program
    {


        static void Main(string[] args)
        {
            try
            {

                //D megoldás : Beleveszi a negatív számot is

                TextFileReader reader = new("input.txt");
                int dbe, dbu, e;
                dbe = 0;
                while (reader.ReadInt(out e) && e>=0)
                {
                    if (e % 2 == 0)
                    {
                        ++dbe;
                    }

                }

                dbu = e%2==0?1:0;
                while (reader.ReadInt(out e))
                {
                    if (e % 2 == 0)
                    {
                        ++dbu;
                    }

                }
                Console.WriteLine($"Előtte: {dbe} Utána: {dbu}");


            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás filenév");
            }
        }
    }
}