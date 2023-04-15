//Igaz-e, hogy minden szám páros!
using TextFile;
namespace mind_paros
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                TextFileReader reader = new TextFileReader("input.txt");
                bool mind=true;
                while(mind && reader.ReadInt(out int number))
                {
                    if (number % 2 != 0)
                    {
                        mind = false;break;
                    }
                }

                if (mind)
                {
                    Console.WriteLine("Minden szám páros");
                }
                else
                {
                    Console.WriteLine("Nem minden szám páros");
                }
               
                

			}
			catch (System.IO.FileNotFoundException)
			{

                Console.WriteLine("Hibás fájlnév!");
            }
        }

      
    }
}