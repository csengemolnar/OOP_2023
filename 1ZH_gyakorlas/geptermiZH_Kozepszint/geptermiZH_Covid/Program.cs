using System.Diagnostics.Tracing;
using TextFile;

namespace geptermiZH_Covid
{
    public struct Korhaz
    {
        public string nev;
        public int beteg;
        public int gep;
    }

    public class Nap
    {
        public  string datum;
        public  int uj;
        public  List<Korhaz> korhazak;

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
                //t: Volt-e olyan nap, amikor 5000 felett volt az újonnan regisztráltak száma, és melyik nap 
                //ápolták a kórházakban együttesen a legtöbb beteget ? (Legalább egy napról vannak adataink.) 
                bool l = false;
                int max = 0;
                string mikor = "";
                int sum = 0;

                while (ReadNap(ref reader,out Nap nap))
                {
                    l = l && nap.uj > 5000;

                    for (int i = 0; i < nap.korhazak.Count; i++)
                    {
                        sum = sum + nap.korhazak[i].beteg;

                    }

                    if (sum > max)
                    {
                        max = sum;
                        mikor = nap.datum;

                    }


                }

                if (l==true)
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
                Console.WriteLine(mikor);

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás fájlnév!");
            }
            
        }

        private static bool ReadNap(ref TextFileReader reader, out Nap nap)
        {
            nap = null;
            char[] sep=new char[] { '\t', ' '};
            var tömb=new List<Korhaz>();

            if (reader.ReadLine(out string line))
            {
                var tokens=line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 2; i < tokens.Length; i+=3)
                {
                    tömb.Add(new Korhaz
                    {
                        nev = tokens[i],
                        beteg = int.Parse(tokens[i+1]),
                        gep = int.Parse(tokens[i+2]),

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