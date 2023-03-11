namespace OEP_Beadando1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Complex complex1=new Complex();
            Complex complex2=new Complex(5,7);
            Complex complex3=new Complex(6.74,6);
            Complex complex4=new Complex(7.9953,8);

            Console.WriteLine(complex1 + complex2);
            Console.WriteLine(complex3 - complex4);
            Console.WriteLine(complex4 * complex2);
            Console.WriteLine(complex4 / complex2);




        }
    }
}