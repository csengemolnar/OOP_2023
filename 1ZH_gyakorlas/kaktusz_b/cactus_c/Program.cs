//Válogassuk ki egy outputfájlba a piros virágú kaktuszok neveit!

using TextFile;
namespace cactus_c
{

    struct Cactus
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
                FileStream f = new FileStream("output.txt", FileMode.OpenOrCreate);
                StreamWriter writer = new StreamWriter(f);

                while(ReadCactus(ref reader, out Cactus cactus))
                {
                    if (cactus.szin =="piros")
                    {
                        writer.WriteLine(cactus.nev);
                    }
                }

                writer.Close(); 

            }
            catch (System.IO.FileNotFoundException)
            {

                Console.WriteLine("Hibás fájlnév!");
            }
            
        }

        private static bool ReadCactus(ref TextFileReader reader, out Cactus cactus)
        {
            bool l = reader.ReadString(out cactus.nev);
            reader.ReadString(out cactus.os);
            reader.ReadString(out cactus.szin);
            reader.ReadInt(out cactus.meret);
            return l;
        }
    }
}