using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using TextFile;

namespace jeles
{
    public struct Korhaz
    {
        public string nev;
        public int beteg;
        public int gep;
    }

    public class Nap
    {
        public string datum;
        public int uj;
        public List<Korhaz> korhazak;

        public Nap(string datum, int uj, List<Korhaz> korhazak)
        {
            this.datum = datum;
            this.uj = uj;
            this.korhazak = korhazak;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("inp.txt");
                //Összesen hány új fertőzöttet regisztráltak azzal kezdődően, hogy a kórházakban 
                //együttesen 1000 - nél is több beteget ápoltak, és ebben az időszakban melyik napon volt a legtöbb
                //beteg a kórházakban együttesen, és mennyi?
                int db = 0;
                int max = 0;
                string mikor = "";
                bool flag = false;
                while (ReadNap(ref reader, out Nap nap))
                {

                    int sum = 0;
                    for (int i = 0; i < nap.korhazak.Count; i++)
                    {
                        sum += nap.korhazak[i].beteg;


                    }
                    if (flag)
                    {
                        db += nap.uj;
                        if (sum > max)
                        {
                            max = sum;
                            mikor = nap.datum;
                        }

                    }
                    if (sum >= 1000)
                    {
                        flag= true;
                    }
                    

                }

                //70 2021.10.13 870

                Console.WriteLine($"{db} {mikor} {max}");



            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás fájlnév!");
            }

        }

        private static bool ReadNap(ref TextFileReader reader, out Nap nap)
        {
            nap = null;
            char[] sep = new char[] { '\t', ' ' };
            var tömb = new List<Korhaz>();

            if (reader.ReadLine(out string line))
            {
                var tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 2; i < tokens.Length; i += 3)
                {
                    tömb.Add(new Korhaz
                    {
                        nev = tokens[i],
                        beteg = int.Parse(tokens[i + 1]),
                        gep = int.Parse(tokens[i + 2]),

                    }


                    );
                }

                nap = new Nap(tokens[0], int.Parse(tokens[1]), tömb);
                return true;

            }
            else
            {
                return false;

            }

        }
    }
}