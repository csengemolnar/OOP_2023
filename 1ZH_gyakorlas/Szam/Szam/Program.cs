//Hány páros szám előzi meg az első negatívat?
//Hány páros szám követi az első negatívat?
using TextFile;
namespace Szam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");
            try
            {
                int db = 0;
                bool vanE = false;
                int dbu = 0;
                while(reader.ReadInt(out int szam))
                {
                    if (szam < 0)
                    {
                        vanE = true;
                    }
                    if (szam % 2 == 0 && vanE==false)
                    {
                        db++;
                    }
                    if (vanE == true && szam % 2 == 0)
                    {
                        dbu++;
                    }


                    


                }
                Console.WriteLine($"{db} db páros szám előzi meg az első negatív számot!");
                Console.WriteLine($"{dbu} db páros szám követi az első negatív számot!");

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Nem létező fájl!");
            }
        }
    }
}