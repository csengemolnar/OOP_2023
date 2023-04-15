using TextFile;

namespace geptermi_kozepszint
{

    public struct Pingvin
    {
        public string fajta;
        public string szarmazas;
        public int darab;

    }
    public class Megfigyelesek
    {
        public readonly string datum;
        public readonly int becsles;
        public readonly List<Pingvin> pingvinek;

        public Megfigyelesek(string d, int b, List<Pingvin> p)
        {
            this.datum = d;
            this.becsles = b;
            this.pingvinek = p;
        }

    }
     class Program
    {
        static void Main(string[] args)
        {

            try
            {
                TextFileReader reader = new TextFileReader("TextFile1.txt");


                bool VanE = true;
                int max = 0;
                //Igaz-e, hogy minden megfigyelésen nagyobb volt a becslés a pingvinek tényleges számánál? Mennyi 
                //volt a maximális eltérés egy becslés és a tényleges szám között.
                while (ReadMegfigy(ref reader, out Megfigyelesek megfigyel))
                {
                    int s = 0;
                    for (int i = 0; i < megfigyel.pingvinek.Count; i++)
                    {
                        s = s + megfigyel.pingvinek[i].darab;


                    }
                    VanE = VanE && megfigyel.becsles>s;
                    int kul = Math.Abs(s - megfigyel.becsles);
                    if (kul > max)
                    {
                        max = kul;
                    }



                }
                if (VanE) {
                    Console.Write("Igaz ");
                }
                else
                {
                    Console.Write("Hamis ");
                }
                Console.Write(max);


            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás fájlnév!"); ;
            }
            
        }



        private static bool ReadMegfigy(ref TextFileReader reader, out Megfigyelesek megfigyel)
        {
            megfigyel = null;
            var list= new List<Pingvin>();

            char[] separator= new char[]{' ', '\t'};
            if(reader.ReadLine(out string line))
            {
                var tokens = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 2; i < tokens.Length; i += 3)
                {
                    list.Add(new Pingvin
                    {
                        fajta = tokens[i],
                        szarmazas = tokens[i + 1],
                        darab = int.Parse(tokens[i + 2]),


                    });

                }
                megfigyel = new Megfigyelesek(tokens[0], int.Parse(tokens[1]), list);
                return true;

            }
            else
            {
                return false;
            }



           
        }
    }
}