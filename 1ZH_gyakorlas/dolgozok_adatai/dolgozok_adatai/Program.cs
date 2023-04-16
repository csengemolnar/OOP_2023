
/*Egy szekvenciális inputfájl (megengedett művelet: read) egy vállalat dolgozóinak adatait 
tartalmazza: név, munka típus (fizikai, adminisztratív, vezető), havi bér, család nagysága, 
túlóraszám. 
*/
using System.Diagnostics.CodeAnalysis;
using TextFile;
namespace dolgozok_adatai
{
    struct Dolgozo
    {
        public string nev;
        public string tipus;
        public int ber;
        public int csalad;
        public int tuloraszam;
    }

     class Program
    {        
        static void Main(string[] args)
        {
            //Válasszuk ki azoknak a fizikai dolgozóknak a nevét, akiknél a túlóraszám 
            //meghaladja a 20 - at, és családtagok száma nagyobb 4 - nél; adjuk meg a fizikai, adminisztratív,
            //vezető beosztású dolgozók átlagos havi bérét!
            try
            {
                TextFileReader reader = new TextFileReader("Textfile1.txt");
                List<string> nevek= new List<string>();
                int sum = 0;
                int db = 0;
                while (ReadAdat(ref reader,out Dolgozo dolg))
                {
                    if (dolg.tipus=="fizikai" && dolg.tuloraszam>20 && dolg.csalad > 4)
                    {
                        nevek.Add(dolg.nev);

                    }
                    sum += dolg.ber;
                    db++;
                
                }
                double atlag=sum/db;
                for (int i = 0; i < nevek.Count; i++)
                {

                    Console.WriteLine($"{i+1} Dolgozó: {nevek[i]}");
                }

                Console.WriteLine($"Az átlagos havi bér {atlag}");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Hibás fájlnév!"); ;
            }
            
        }

        private static bool ReadAdat(ref TextFileReader reader, out Dolgozo dolg)
        {

            dolg = new();

            if(reader.ReadLine(out string line))
            {
                var tokens=line.Split(' ');

                dolg.nev = tokens[0];
                dolg.tipus = tokens[1];
                dolg.ber = int.Parse(tokens[2]);
                dolg.csalad = int.Parse(tokens[3]);
                dolg.tuloraszam = int.Parse(tokens[4]);
                
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}