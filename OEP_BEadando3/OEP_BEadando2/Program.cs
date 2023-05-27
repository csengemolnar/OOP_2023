namespace OEP_BEadando3
{
    class Program
    {
        static void Main(string[] args)
        {
            File f = new(3);
            File f2 = new(2);
            File f3 = new(213);
            File f4 = new(24);
            Folder folder = new Folder();
            Folder folder2 = new Folder();


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
            folder.Add(f3);
            Console.WriteLine(folder.GetSize());
            folder.Remove(f);
            folder.Add(f4);
            folder2.Add(f3);
            folder.Add(folder2);
            Console.WriteLine(folder.GetSize());

            //f.GetSize();



        }
    }
}