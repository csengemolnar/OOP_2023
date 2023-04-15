using TextFile;
namespace bevetel
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                var s = new ReadFile("input.txt");
                int sum = 0;
                while (s.ReadSzamla(out Szamla szamla))
                {
                    for (int i = 0; i< szamla.vasarlas.Count; i++)
                    {
                        sum += szamla.vasarlas[i].ar;
                    }
                }
                
                Console.WriteLine($"A szaküzlet mai bevétele: {sum}");

			}
			catch (System.IO.FileNotFoundException)
			{

                Console.WriteLine("A filenév nem létezik!");
            }
        }

      
    }
}