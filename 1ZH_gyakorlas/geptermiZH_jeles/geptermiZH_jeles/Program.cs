using TextFile;

namespace geptermiZH_jeles
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
        //public readonly List<Pingvin> pingvinek;
        public readonly int össz;
        public readonly int antarktisz;

        public Megfigyelesek(string d, int becs,int ossz,int a)
        {
            this.datum = d;
            this.becsles = becs;
            this.össz = ossz;
            this.antarktisz = a;
           
        }


    }

    //Összesen hány antarktiszi pingvint számoltak meg azt követően, hogy egy megfigyelés befejeztével a 
   // becslésénél több pingvint számoltak meg, és ebben az időszakban melyik megfigyelésen volt a
   //legkevesebb pingvin megszámlálva és mennyi? (Tudjuk, hogy legalább egy olyan megfigyelés szerepel
    //a nyilvántartásban, ahol a becslésnél több pingvint számoltak.)
     class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("inp.txt");
               

                int db = 0;
                int min =Int32.MaxValue;
                bool flag = false;
                string mikor="";
                while(ReadMegfigyeles(ref reader, out Megfigyelesek megfigyeles))
                {
                    //és ebben az időszakban melyik megfigyelésen volt a 
                    //legkevesebb pingvin megszámlálva és mennyi?
                    if (flag)
                    {

                        db += megfigyeles.antarktisz;

                        if (megfigyeles.össz < min)
                        {
                            min = megfigyeles.össz;
                            mikor = megfigyeles.datum;
                        }
                    }

                    if (megfigyeles.össz > megfigyeles.becsles)
                    {
                        flag = true;
                    }
                }
                Console.WriteLine($"{db} {mikor} {min}");

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás fájlnév!");
            }
            
        }

        private static bool ReadMegfigyeles(ref TextFileReader reader, out Megfigyelesek megfigyeles)
        {
            //Megfigyelés = rec(dátum:𝕊, becslés:ℕ, össz:ℕ, antarktisz:ℕ) 
            megfigyeles = null;
            var lista= new List<Pingvin>();
            char[] sep = new char[] {' ','\t'};
            
            if (reader.ReadLine(out string line))
            {
                var tokens=line.Split(sep,StringSplitOptions.RemoveEmptyEntries);
                int antarktisz = 0;
                int össz = 0;
                for (int i = 2; i < tokens.Length; i+=3)
                {

                    if (tokens[i+1] == "Antarktisz")
                    {
                        antarktisz += int.Parse(tokens[i + 2]);
                    }

                    össz += int.Parse(tokens[i + 2]);

                    /*lista.Add(new Pingvin
                    {
                        fajta = tokens[i],
                        szarmazas= tokens[i+1],
                        darab = int.Parse(tokens[i+2])
                    });*/

                    

                }
                megfigyeles = new Megfigyelesek(tokens[0], int.Parse(tokens[1]), össz, antarktisz);
                return true;


            }
            else
            {
                return false;
            }
        }
    }
}