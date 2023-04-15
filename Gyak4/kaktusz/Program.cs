using TextFile;

namespace kaktusz
{
    internal class Program
    {
        struct Cactus
        {
            public string name;
            public string country;
            public string color;
            public int height;
        }
        static void Main(string[] args)
        {
            TextFileReader reader = new("In.txt");
            using TextWriter writer1 = new StreamWriter("piros.txt");
            using TextWriter writer2 = new StreamWriter("mexico.txt");
            using TextWriter writer3 = new StreamWriter("pirosmexico.txt");

            while (ReadCactus(ref reader, out Cactus cactus))
            {
                if (cactus.color == "piros")
                {
                    writer1.WriteLine(cactus.name);

                }
                if (cactus.country == "mexico")
                {
                    writer2.WriteLine(cactus.name);
                }
                if(cactus.country=="mexico" && cactus.color == "piros")
                {
                    writer3.WriteLine(cactus.name);
                }
            }
        }

        private static bool ReadCactus(ref TextFileReader reader, out Cactus cactus)
        {
            bool l = reader.ReadString(out cactus.name);
            reader.ReadString(out cactus.country);
            reader.ReadString(out cactus.color);
            reader.ReadInt(out cactus.height);
            return l;

        }
    }
}