using TextFile;
//Adjuk meg annak az azonosítóját, akinek nincs tartozása, de legkisebb a számlaegyenlege

namespace bankszamla
{
    struct Szamla
    {
        public string azonosito;
        public int egyenleg;

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader= new TextFileReader("input.txt");

                bool vanE = false;
                int min = 0;
                string az="";

                while(Readszamla(ref reader, out Szamla szamla))
                {
                    if (szamla.egyenleg >= 0 && vanE==false)
                    {
                        vanE= true;
                        min= szamla.egyenleg;
                        az = szamla.azonosito;

                    } 
                    
                    if (szamla.egyenleg >= 0 && vanE == true)
                    {
                        if (szamla.egyenleg < min)
                        {
                            min=szamla.egyenleg;
                            az= szamla.azonosito;
                        }
                    }


                }

                Console.WriteLine($"A legkisebb egyenlege a(z) {az} azonosítóval rendelkező ügyfelünknek van.");


            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("hibás filenév!");

            }
        }

        private static bool Readszamla(ref TextFileReader reader, out Szamla szamla)
        {
            bool beolvasas = reader.ReadString(out szamla.azonosito);
            reader.ReadInt(out szamla.egyenleg);
            return beolvasas;
        }
    }
}