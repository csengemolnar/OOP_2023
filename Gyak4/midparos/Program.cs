using TextFile;
namespace midparos
{
     class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new("input.txt");
            bool l = true;
            while(reader.ReadInt(out int e))
            {
                if (!(l = e % 2 == 0)) break;
                
              
            }
            Console.WriteLine(l ? "igaz" : "hamis");
        }
    }
}