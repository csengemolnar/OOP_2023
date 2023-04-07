namespace Ractip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational();
            Rational b = new Rational(3,1);
            Rational c = new Rational(5,4);
            Console.WriteLine(a+b);
            Console.WriteLine(b*c);
            Console.WriteLine(c/a);
        }
    }
}