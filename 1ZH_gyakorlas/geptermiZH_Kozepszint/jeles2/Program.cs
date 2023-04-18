using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using TextFile;

namespace jeles2
{
    /*public struct Korhaz
    {
        public string nev;
        public int beteg;
        public int gep;
    }*/

    public class Nap
    {
        public string datum;
        public int uj;
        public int össz;

        public Nap(string datum, int uj, int ossz)
        {
            this.datum = datum;
            this.uj = uj;
            this.össz=ossz;
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
                
                
                while (ReadNap(ref reader, out Nap nap)&& nap.össz<=100)
                {



                }
                int db = 0;
                int max = 0;
                string mikor = "";

                while (ReadNap(ref reader, out Nap nap))
                {
                    
                    if (nap.össz > max)
                    {
                        max = nap.össz;
                        mikor = nap.datum;
                    }
                    db += nap.uj;

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
            //A napi lista összegzését rejtsük el majd egy nap beolvasásában. Ennélfogva a főprogramban a nap 
            //típusa már Nap = rec(dátum:𝕊, új: ℕ, össz: ℕ) lesz, ahol össz az összegzés eredménye.

            nap = null;
            char[] sep = new char[] { '\t', ' ' };
            int összeg=0;
            

            if (reader.ReadLine(out string line))
            {
                var tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 2; i < tokens.Length; i += 3)
                {
                    összeg += int.Parse(tokens[i + 1]);
                }

                nap = new Nap(tokens[0], int.Parse(tokens[1]), összeg);
                return true;

            }
            else
            {
                return false;

            }

        }
    }
}