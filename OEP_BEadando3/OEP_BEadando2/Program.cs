namespace OEP_BEadando3
{
    class Program
    {
        static void Main(string[] args)
        {
            File f = new(3);
            File f2 = new(2);
            Folder folder = new Folder();
            
            Console.WriteLine("Első file nagysága");
            Console.WriteLine(f.GetSize());
            Console.WriteLine("Második file nagysága");
            Console.WriteLine(f2.GetSize());

            
            Console.WriteLine("Folder nagysága");
            Console.WriteLine(folder.GetSize());
            folder.Add(f2);
            Console.WriteLine("Folder nagysága a második file-val");
            Console.WriteLine(folder.GetSize());
            folder.Add(f);
            Console.WriteLine("Folder nagysága a mindkét file-val");
            Console.WriteLine(folder.GetSize());

            //f.GetSize();



        }
    }
}