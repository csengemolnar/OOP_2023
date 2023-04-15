
//Keressük meg a legnagyobb számot és döntük el, hogy van-e páros szám
using System.ComponentModel.DataAnnotations;
using TextFile;
namespace legnagyobb_szam
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                TextFileReader reader = new TextFileReader("input.txt");

                bool paros = false;
                reader.ReadInt(out int max);
                
                while (reader.ReadInt(out int szam))
                {
                    if (max < szam)
                    {
                        max = szam;
                    }
                    if (szam % 2 == 0)
                    {
                        paros = true;
                    }
                }
                if (paros)
                {
                    Console.WriteLine("A fileban van páros szám");
                }
                else {
                    Console.WriteLine("A fileban nincs páros szám");}


                Console.WriteLine($"A legnagyobb szám: {max}");


            }
			catch (System.IO.FileNotFoundException)
			{

                Console.WriteLine("Hiba, a file nem található!");
			}  
        }
    }
}