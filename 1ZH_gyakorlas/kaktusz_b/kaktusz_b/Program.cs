
//Van-e piros színű kaktusz
using TextFile;

namespace kaktusz_b
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

                bool vanE = false;

                while (vanE==false && ReadCactus(ref reader, out Cactus kaktusz))
                {
                    if (kaktusz.szin == "piros")
                    {
                        vanE = true;
                    }

                }
                if (vanE)
                {
                    Console.WriteLine("Van piros színű kaktusz.");
                }
                else
                {
                    Console.WriteLine("Nincs piros színű kaktusz.");
                }
                

            }
			catch (System.IO.FileNotFoundException)
			{

                Console.WriteLine("Hibás fájlnév.");
            }
        }

        private static bool ReadCactus(ref TextFileReader reader, out Cactus kaktusz)
        {
            bool l =reader.ReadString(out kaktusz.nev);
            reader.ReadString(out kaktusz.os);
            reader.ReadString(out kaktusz.szin);
            reader.ReadInt(out kaktusz.meret);

            return l;
        }
    }
}