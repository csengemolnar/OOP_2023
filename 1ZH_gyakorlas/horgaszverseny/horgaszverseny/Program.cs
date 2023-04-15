using System.Xml.Linq;
using TextFile;
//Keressünk olyan horgászt, aki 50cm-nél hosszabb pontyokból legalább 10 kg-ot fogott.

namespace horgaszverseny
{
    struct Fogas
    {
        public string ido;
        public string hal;
        public double suly;
        public double meret;
    }
    class Horgasz
    {
       public readonly string nev;
       public readonly List<Fogas> fogas;

        public Horgasz(string nev, List<Fogas> fogas)
        {
            this.nev = nev;
            this.fogas = new List<Fogas>();
        }

    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("input.txt");
                //Keressünk olyan horgászt, aki 50cm-nél hosszabb pontyokból legalább 10 kg-ot fogott.

                bool l = SearchHorgasz(ref reader, out string nev);
                Console.WriteLine(l ? $"Sok pontyot fogott: {nev}" : "nincs olyan horgász aki sok pontyot fogott");

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hibas fájlnév");

            }
            
        }

        private static bool SearchHorgasz(ref TextFileReader reader, out string nev)
        {
            bool van = false;
            nev = null;

            while (van==false && ReadHorgasz(ref reader, out Horgasz horgasz))
            {
               
                if(Psuly(horgasz.fogas)>=10)
                {
                    van = true;
                    nev=horgasz.nev;

                }
            }
            return van;
        }

        private static double Psuly(List<Fogas> fogas)
        {

            double s = 0;
            foreach (var f in fogas)
            {
                if (f.hal == "ponty" && f.meret > 0.5)
                {
                    s += f.suly;
                }
            }
            return s;
        }

        private static bool ReadHorgasz(ref TextFileReader reader, out Horgasz horgasz)
        {
            horgasz = null;

           var f = new List<Fogas>();


            char[] sep = new char[]{ ' ', '\t' };
            if(reader.ReadLine(out string line))
            {
                var tokens=line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                string nev = tokens[0];
                for (int i=1; i<tokens.Length;i+=4)
                {
                    f.Add(new Fogas
                    {
                        ido= tokens[i],
                        hal= tokens[i+1],
                        suly = double.Parse(tokens[i+2]),
                        meret = double.Parse(tokens[i+3]),

                    });
                    



                }
                horgasz=new Horgasz(nev,f);
                return true;




            } else return false;
           
        }
    }
}