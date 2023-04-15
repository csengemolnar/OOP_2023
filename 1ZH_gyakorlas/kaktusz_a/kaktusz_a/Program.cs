using TextFile;
namespace kaktusz_a
{
    struct Kaktusz
    {
        public string nev;
        public string os;
        public string szin;
        public int meret;

    }
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                TextFileReader reader = new TextFileReader("input.txt");
                int db = 0;
                while (ReadCactus(ref reader,out Kaktusz cactus))
                {
                    if (cactus.szin == "piros")
                    {
                        db++;
                        
                    }

                    
                    

                }
                Console.WriteLine($"piros színű kaktuszok darabszáma: {db}");

            }
			catch (System.IO.FileNotFoundException)
			{

                Console.WriteLine("Nem jó fájlnév!");
            }
        }

        private static bool ReadCactus(ref TextFileReader reader, out Kaktusz cactus)
        {
            bool l = reader.ReadString(out cactus.nev);
            reader.ReadString(out cactus.os);
            reader.ReadString(out cactus.szin);
            reader.ReadInt(out cactus.meret);
            return l;
            
        }
    }
}